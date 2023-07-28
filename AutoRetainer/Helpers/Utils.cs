﻿using AutoRetainer.Configuration;
using AutoRetainerAPI.Configuration;
using ClickLib.Clicks;
using Dalamud;
using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.Objects.Enums;
using Dalamud.Game.ClientState.Objects.Types;
using Dalamud.Memory;
using Dalamud.Utility;
using ECommons.Events;
using ECommons.ExcelServices.TerritoryEnumeration;
using ECommons.GameFunctions;
using ECommons.GameHelpers;
using ECommons.Interop;
using ECommons.MathHelpers;
using ECommons.Reflection;
using ECommons.Throttlers;
using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Component.GUI;
using Lumina.Excel.GeneratedSheets;
using PInvoke;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ValueType = FFXIVClientStructs.FFXIV.Component.GUI.ValueType;

namespace AutoRetainer.Helpers;

internal static unsafe class Utils
{
    internal static bool MultiModeOrArtisan => MultiMode.Active || (SchedulerMain.PluginEnabled && SchedulerMain.Reason == PluginEnableReason.Artisan);

    internal static void FixKeys()
    {
        Fix(ref C.EntrustKey);
        Fix(ref C.RetrieveKey);
        Fix(ref C.SellKey);
        Fix(ref C.SellMarketKey);
        Fix(ref C.TempCollectB);
        Fix(ref C.Suppress);
        static void Fix(ref LimitedKeys key)
        {
            if (((Keys)key).EqualsAny(Keys.Control, Keys.ControlKey)) key = LimitedKeys.LeftControlKey;
            if (((Keys)key).EqualsAny(Keys.Shift, Keys.ShiftKey)) key = LimitedKeys.LeftShiftKey;
            if (((Keys)key).EqualsAny(Keys.Alt, Keys.Menu)) key = LimitedKeys.LeftAltKey;
        }
    }

    internal static IEnumerable<string> GetEObjNames(params uint[] values)
    {
        foreach(var x in values)
        {
            yield return Svc.Data.GetExcelSheet<EObjName>().GetRow(x).Singular.ToDalamudString().ExtractText();
        }
    }

    internal static float GetGCSealMultiplier()
    {
        var ret = 1f;
        if (Player.Available)
        {
            if (Player.Object.StatusList.TryGetFirst(x => x.StatusId == 414, out var s)) ret = 1f + (float)s.StackCount / 100f;
            if (Player.Object.StatusList.Any(x => x.StatusId == 1078)) ret = 1.15f;
        }
        return ret > 1f?ret:1f;
    }

    internal static bool TryGetCharacterIndex(string name, out int index)
    {
        index = GetCharacterNames().IndexOf(name);
        return index >= 0;
    }

    internal static List<string> GetCharacterNames()
    {
        List<string> ret = new();
        var data = CSFramework.Instance()->UIModule->GetRaptureAtkModule()->AtkModule.GetStringArrayData(1);
        if (data != null)
        {
            for (int i = 60; i < data->AtkArrayData.Size; i++)
            {
                if (data->StringArray[i] == null) break;
                var item = data->StringArray[i];
                if (item != null)
                {
                    var str = MemoryHelper.ReadSeStringNullTerminated((nint)item).ExtractText();
                    if (str == "") break;
                    ret.Add(str);
                }
            }
        }
        return ret;
    }

    internal static string FancyDigits(this int n)
    {
        return n.ToString().ReplaceByChar(Lang.Digits.Normal, Lang.Digits.GameFont);
    }

    internal static int GetJobLevel(this OfflineCharacterData data, uint job)
    {
        var d = Svc.Data.GetExcelSheet<ClassJob>().GetRow(job);
        if(d != null)
        {
            try
            {
                return data.ClassJobLevelArray[d.ExpArrayIndex];
            }
            catch (Exception) { }
        }
        return 0;
    }

    internal static OfflineCharacterData GetCurrentCharacterData()
    {
        return C.OfflineData.FirstOrDefault(x => x.CID == Player.CID);
    }

    internal static bool CanAutoLogin()
    {
        return !Svc.ClientState.IsLoggedIn 
            && !Svc.Condition.Any() 
            && !P.TaskManager.IsBusy 
            && !AutoLogin.Instance.IsRunning 
            && TryGetAddonByName<AtkUnitBase>("_TitleMenu", out var title) 
            && IsAddonReady(title) 
            && title->UldManager.NodeListCount > 3 
            && title->UldManager.NodeList[3]->Color.A == 0xFF 
            && !TryGetAddonByName<AtkUnitBase>("TitleDCWorldMap", out _) 
            && !TryGetAddonByName<AtkUnitBase>("TitleConnect", out _);
    }

    internal static OfflineCharacterData GetOfflineCharacterDataFromAdditionalRetainerDataKey(string key)
    {
        var cid = ulong.Parse(key.Split(" ")[0].Replace("#", ""), System.Globalization.NumberStyles.HexNumber);
        return C.OfflineData.FirstOrDefault(x => x.CID == cid);
    }

    internal static OfflineRetainerData GetOfflineRetainerDataFromAdditionalRetainerDataKey(string key)
    {
        return GetOfflineCharacterDataFromAdditionalRetainerDataKey(key).RetainerData.FirstOrDefault(x => x.Name == key.Split(" ")[1]);
    }

    internal static uint GetNextPlannedVenture(this AdditionalRetainerData data)
    {
        var index = data.GetNextPlannedVentureIndex();
        if(index == -1)
        {
            return 0;
        }
        else
        {
            return data.VenturePlan.ListUnwrapped[index];
        }
    }

    internal static int GetNextPlannedVentureIndex(this AdditionalRetainerData data)
    {
        if (data.VenturePlan.ListUnwrapped.Count == 0)
        {
            return -1;
        }
        else
        {
            if(data.VenturePlanIndex >= data.VenturePlan.ListUnwrapped.Count)
            {
                if(data.VenturePlan.PlanCompleteBehavior == PlanCompleteBehavior.Restart_plan)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return (int)data.VenturePlanIndex;
            }
        }
    }

    internal static bool IsLastPlannedVenture(this AdditionalRetainerData data)
    {
        return data.VenturePlanIndex >= data.VenturePlan.ListUnwrapped.Count;
    }

    internal static bool IsVenturePlannerActive(this AdditionalRetainerData data)
    {
        return data.EnablePlanner && data.VenturePlan.ListUnwrapped.Count > 0;
    }

    internal static DateTime DateFromTimeStamp(uint timeStamp)
    {
        const long timeFromEpoch = 62135596800;
        return timeStamp == 0u
            ? DateTime.MinValue
            : new DateTime((timeStamp + timeFromEpoch) * TimeSpan.TicksPerSecond, DateTimeKind.Utc);
    }

    internal static bool IsAnyRetainersCompletedVenture()
    {
        if (!ProperOnLogin.PlayerPresent) return false;
        if (C.OfflineData.TryGetFirst(x => x.CID == Svc.ClientState.LocalContentId, out var data))
        {
            var selectedRetainers = data.GetEnabledRetainers().Where(z => z.HasVenture);
            return selectedRetainers.Any(z => z.GetVentureSecondsRemaining() <= 10);
        }
        return false;
    }

    internal static bool IsAllCurrentCharacterRetainersHaveMoreThan5Mins()
    {
        if (C.OfflineData.TryGetFirst(x => x.CID == Svc.ClientState.LocalContentId, out var data))
        {
            foreach (var z in data.GetEnabledRetainers())
            {
                if (z.GetVentureSecondsRemaining() < 5 * 60) return false;
            }
        }
        return true;
    }

    internal static string GetActivePlayerInventoryName()
    {
        {
            if (TryGetAddonByName<AtkUnitBase>("InventoryLarge", out var addon) && addon->IsVisible)
            {
                return "InventoryLarge";
            }
        }
        {
            if (TryGetAddonByName<AtkUnitBase>("InventoryExpansion", out var addon) && addon->IsVisible)
            {
                return "InventoryExpansion";
            }
        }
        return "Inventory";
    }
    internal static (string Name, int EntrustDuplicatesIndex) GetActiveRetainerInventoryName()
    {
        if (TryGetAddonByName<AtkUnitBase>("InventoryRetainerLarge", out var addon) && addon->IsVisible)
        {
            return ("InventoryRetainerLarge", 8);
        }
        return ("InventoryRetainer", 5);
    }

    internal static GameObject GetReachableRetainerBell()
    {
        foreach (var x in Svc.Objects)
        {
            if ((x.ObjectKind == ObjectKind.Housing || x.ObjectKind == ObjectKind.EventObj) && x.Name.ToString().EqualsIgnoreCaseAny(Lang.BellName, "リテイナーベル"))
            {
                if (Vector3.Distance(x.Position, Svc.ClientState.LocalPlayer.Position) < GetValidInteractionDistance(x) && x.IsTargetable())
                {
                    return x;
                }
            }
        }
        return null;
    }



    internal static bool AnyRetainersAvailableCurrentChara()
    {
        if (C.OfflineData.TryGetFirst(x => x.CID == Svc.ClientState.LocalContentId, out var data))
        {
            return data.GetEnabledRetainers().Any(z => z.GetVentureSecondsRemaining() <= C.UnsyncCompensation);
        }
        return false;
    }

    internal static AdditionalRetainerData GetAdditionalData(ulong cid, string name)
    {
        var key = GetAdditionalDataKey(cid, name, true);
        return C.AdditionalData[key];
    }

    internal static string GetAdditionalDataKey(ulong cid, string name, bool create = true)
    {
        var key = $"#{cid:X16} {name}";
        if (create && !C.AdditionalData.ContainsKey(key))
        {
            C.AdditionalData[key] = new();
        }
        return key;
    }

    internal static bool GenericThrottle => EzThrottler.Throttle("AutoRetainerGenericThrottle", C.Delay);
    internal static void RethrottleGeneric(int num) => EzThrottler.Throttle("AutoRetainerGenericThrottle", num, true);
    internal static void RethrottleGeneric() => EzThrottler.Throttle("AutoRetainerGenericThrottle", C.Delay, true);

    internal static bool TrySelectSpecificEntry(string text)
    {
        return TrySelectSpecificEntry(new string[] { text });
    }

    internal static bool TrySelectSpecificEntry(IEnumerable<string> text)
    {
        if (TryGetAddonByName<AddonSelectString>("SelectString", out var addon) && IsAddonReady(&addon->AtkUnitBase))
        {
            var entry = GetEntries(addon).FirstOrDefault(x => x.EqualsAny(text));
            if (entry != null)
            {
                var index = GetEntries(addon).IndexOf(entry);
                if (index >= 0 && IsSelectItemEnabled(addon, index) && GenericThrottle)
                {
                    ClickSelectString.Using((nint)addon).SelectItem((ushort)index);
                    P.DebugLog($"SelectAssignVenture: selecting {entry}/{index} as requested by {text.Print()}");
                    return true;
                }
            }
        }
        else
        {
            RethrottleGeneric();
        }
        return false;
    }

    internal static bool IsSelectItemEnabled(AddonSelectString* addon, int index)
    {
        var step1 = (AtkTextNode*)addon->AtkUnitBase
                    .UldManager.NodeList[2]
                    ->GetComponent()->UldManager.NodeList[index + 1]
                    ->GetComponent()->UldManager.NodeList[3];
        return GenericHelpers.IsSelectItemEnabled(step1);
    }

    internal static List<string> GetEntries(AddonSelectString* addon)
    {
        var list = new List<string>();
        for (int i = 0; i < addon->PopupMenu.PopupMenu.EntryCount; i++)
        {
            list.Add(MemoryHelper.ReadSeStringNullTerminated((nint)addon->PopupMenu.PopupMenu.EntryNames[i]).ExtractText());
        }
        return list;
    }

    internal static void TryNotify(string s)
    {
        if (DalamudReflector.TryGetDalamudPlugin("NotificationMaster", out var instance, true, true))
        {
            Safe(delegate
            {
                instance.GetType().Assembly.GetType("NotificationMaster.TrayIconManager", true).GetMethod("ShowToast").Invoke(null, new object[] { s, P.Name });
            }, true);
        }
    }

    internal static float GetValidInteractionDistance(GameObject bell)
    {
        if (bell.ObjectKind == ObjectKind.Housing)
        {
            return 6.5f;
        }
        else if (Inns.List.Contains(Svc.ClientState.TerritoryType))
        {
            return 4.75f;
        }
        else
        {
            return 4.6f;
        }
    }

    internal static float GetAngleTo(Vector2 pos)
    {
        return (MathHelper.GetRelativeAngle(Svc.ClientState.LocalPlayer.Position.ToVector2(), pos) + Svc.ClientState.LocalPlayer.Rotation.RadToDeg()) % 360;
    }

    internal static GameObject GetNearestEntrance(out float Distance)
    {
        var currentDistance = float.MaxValue;
        GameObject currentObject = null;
        foreach (var x in Svc.Objects)
        {
            if (x.IsTargetable() && x.Name.ToString().EqualsAny(Lang.Entrance))
            {
                var distance = Vector3.Distance(Svc.ClientState.LocalPlayer.Position, x.Position);
                if (distance < currentDistance)
                {
                    currentDistance = distance;
                    currentObject = x;
                }
            }
        }
        Distance = currentDistance;
        return currentObject;
    }

    internal static AtkUnitBase* GetSpecificYesno(Predicate<string> compare)
    {
        for (int i = 1; i < 100; i++)
        {
            try
            {
                var addon = (AtkUnitBase*)Svc.GameGui.GetAddonByName("SelectYesno", i);
                if (addon == null) return null;
                if (IsAddonReady(addon))
                {
                    var textNode = addon->UldManager.NodeList[15]->GetAsAtkTextNode();
                    var text = MemoryHelper.ReadSeString(&textNode->NodeText).ExtractText().Replace(" ", "");
                    if (compare(text))
                    {
                        PluginLog.Verbose($"SelectYesno {text} addon {i} by predicate");
                        return addon;
                    }
                }
            }
            catch (Exception e)
            {
                e.Log();
                return null;
            }
        }
        return null;
    }

    internal static AtkUnitBase* GetSpecificYesno(params string[] s)
    {
        for (int i = 1; i < 100; i++)
        {
            try
            {
                var addon = (AtkUnitBase*)Svc.GameGui.GetAddonByName("SelectYesno", i);
                if (addon == null) return null;
                if (IsAddonReady(addon))
                {
                    var textNode = addon->UldManager.NodeList[15]->GetAsAtkTextNode();
                    var text = MemoryHelper.ReadSeString(&textNode->NodeText).ExtractText().Replace(" ", "");
                    if (text.EqualsAny(s.Select(x => x.Replace(" ", ""))))
                    {
                        PluginLog.Verbose($"SelectYesno {s.Print()} addon {i}");
                        return addon;
                    }
                }
            }
            catch (Exception e)
            {
                e.Log();
                return null;
            }
        }
        return null;
    }

    internal static bool TryMatch(this string s, string pattern, out Match match)
    {
        var m = Regex.Match(s, pattern);
        if (m.Success)
        {
            match = m;
            return true;
        }
        else
        {
            match = null;
            return false;
        }
    }

    internal static bool IsCurrentRetainerEnabled()
    {
        return TryGetCurrentRetainer(out var ret) && C.SelectedRetainers.TryGetValue(Svc.ClientState.LocalContentId, out var rets) && rets.Contains(ret);
    }

    internal static bool TryGetCurrentRetainer(out string name)
    {
        if (Svc.Condition[ConditionFlag.OccupiedSummoningBell] && ProperOnLogin.PlayerPresent && Svc.Objects.Where(x => x.ObjectKind == ObjectKind.Retainer).OrderBy(x => Vector3.Distance(Svc.ClientState.LocalPlayer.Position, x.Position)).TryGetFirst(out var obj))
        {
            name = obj.Name.ToString();
            return true;
        }
        name = default;
        return false;
    }

    internal static uint GetVenturesAmount()
    {
        return (uint)InventoryManager.Instance()->GetInventoryItemCount(21072);
    }

    internal static bool IsInventoryFree()
    {
        return GetInventoryFreeSlotCount() >= 2;
    }

    internal static string ToTimeString(long seconds)
    {
        var t = TimeSpan.FromSeconds(seconds);
        var d = ":";
        return $"{t.Hours:D2}{d}{t.Minutes:D2}{d}{t.Seconds:D2}";
    }

    internal static string GetAddonText(uint num)
    {
        return Svc.Data.GetExcelSheet<Addon>().GetRow(num).Text.ToString();
    }

    internal static bool IsRetainerBell(this GameObject o)
    {
        return o != null &&
            (o.ObjectKind == ObjectKind.EventObj || o.ObjectKind == ObjectKind.Housing)
            && o.Name.ToString().EqualsIgnoreCaseAny(Lang.BellName, "リテイナーベル");
    }

    internal static long GetVentureSecondsRemaining(this SeRetainer ret, bool allowNegative = true)
    {
        var x = ret.VentureCompleteTimeStamp - P.Time;
        return allowNegative ? x : Math.Max(0, x);
    }

    internal static long GetVentureSecondsRemaining(this OfflineRetainerData ret, bool allowNegative = true)
    {
        var x = ret.VentureEndsAt - P.Time;
        return allowNegative ? x : Math.Max(0, x);
    }

    internal static bool TryGetRetainerByName(string name, out SeRetainer retainer)
    {
        if (!P.retainerManager.Ready)
        {
            retainer = default;
            return false;
        }
        for (var i = 0; i < P.retainerManager.Count; i++)
        {
            var r = P.retainerManager.Retainer(i);
            if (r.Name.ToString() == name)
            {
                retainer = r;
                return true;
            }
        }
        retainer = default;
        return false;
    }

    internal static int GetInventoryFreeSlotCount()
    {
        InventoryType[] types = new InventoryType[] { InventoryType.Inventory1, InventoryType.Inventory2, InventoryType.Inventory3, InventoryType.Inventory4 };
        var c = InventoryManager.Instance();
        var slots = 0;
        foreach (var x in types)
        {
            var inv = c->GetInventoryContainer(x);
            for (var i = 0; i < inv->Size; i++)
            {
                if (inv->Items[i].ItemID == 0)
                {
                    slots++;
                }
            }
        }
        return slots;
    }



    internal static bool TryParseRetainerName(string s, out string retainer)
    {
        retainer = default;
        if (!P.retainerManager.Ready)
        {
            return false;
        }
        for (var i = 0; i < P.retainerManager.Count; i++)
        {
            var r = P.retainerManager.Retainer(i);
            var rname = r.Name.ToString();
            if (s.Contains(rname) && (retainer == null || rname.Length > retainer.Length))
            {
                retainer = rname;
            }
        }
        return retainer != default;
    }

    static bool PopupContains(string source, string name)
    {
        if (Svc.Data.Language == ClientLanguage.Japanese)
        {
            return source.Contains($"（{name}）");
        }
        else if (Svc.Data.Language == ClientLanguage.French)
        {
            return source.Contains($"Menu de {name}");
        }
        else if (Svc.Data.Language == ClientLanguage.German)
        {
            return source.Contains($"Du hast {name}");
        }
        else
        {
            return source.Contains($"Retainer: {name}");
        }
    }
}
