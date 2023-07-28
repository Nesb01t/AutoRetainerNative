﻿using AutoRetainerAPI;
using AutoRetainerAPI.Configuration;
using Dalamud.Interface.Components;
using ECommons;
using ECommons.GameHelpers;
using ECommons.MathHelpers;
using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace AutoRetainer.UI;

internal unsafe static class MultiModeUI
{
    internal static bool JustRelogged = false;
    static Dictionary<string, (Vector2 start, Vector2 end)> bars = new();
    internal static void Draw()
    {
        C.OfflineData.RemoveAll(x => C.Blacklist.Any(z => z.CID == x.CID));
        var sortedData = new List<OfflineCharacterData>();
        var shouldExpand = false;
        var doExpand = JustRelogged && !C.NoCurrentCharaOnTop;
        JustRelogged = false;
        if (C.NoCurrentCharaOnTop)
        {
            sortedData = C.OfflineData;
        }
        else
        {
            if (C.OfflineData.TryGetFirst(x => x.CID == Svc.ClientState.LocalContentId, out var cdata))
            {
                sortedData.Add(cdata);
                shouldExpand = true;
            }
            foreach (var x in C.OfflineData)
            {
                if (x.CID != Svc.ClientState.LocalContentId)
                {
                    sortedData.Add(x);
                }
            }
        }
        ulong deleteData = 0;
        for (var index = 0; index < sortedData.Count; index++)
        {
            var data = sortedData[index];
            if (data.World.IsNullOrEmpty()) continue;
            ImGui.PushID(data.CID.ToString());
            var rCurPos = ImGui.GetCursorPos();
            var colen = false;
            if (data.Enabled)
            {
                ImGui.PushStyleColor(ImGuiCol.Button, 0xFF097000);
                colen = true;
            }
            if (ImGuiEx.IconButton(Lang.IconMultiMode))
            {
                data.Enabled = !data.Enabled;
                /*if (data.Enabled && !data.Index.InRange(1, 9))
                {
                    data.Enabled = false;
                    Svc.Chat.PrintError("[AutoRetainer] Error: Please set the character index and service account for this character before enabling multi mode.");
                }*/
            }
            if (colen) ImGui.PopStyleColor();
            ImGuiEx.Tooltip($"Enable multi-mode for this character");
            ImGui.SameLine(0, 3);
            if (ImGuiEx.IconButton(FontAwesomeIcon.DoorOpen))
            {
                if (MultiMode.Active)
                {
                    foreach(var z in C.OfflineData)
                    {
                        z.Preferred = false;
                    }
                    Notify.Warning("Preferred character has been reset");
                }
                if(MultiMode.Relog(data, out var error))
                {
                    Notify.Success("Relogging...");
                }
                else
                {
                    Notify.Error(error);
                }
            }
            if (ImGui.IsItemClicked(ImGuiMouseButton.Right))
            {
                ImGui.SetClipboardText($"/ays relog {data.Name}@{data.World}");
            }
            ImGuiEx.Tooltip($"Left click - relog to this character\nRight click - copy relog command into clipboard");
            ImGui.SameLine(0, 3);
            if (ImGuiEx.IconButton(FontAwesomeIcon.Cog))
            {
                ImGui.OpenPopup($"popup{data.CID}");
            }
            ImGuiEx.Tooltip($"Configure Character");
            ImGui.SameLine(0, 3);

            if (ImGui.BeginPopup($"popup{data.CID}"))
            {
                var b = true;
                ImGui.CollapsingHeader($"{Censor.Character(data.Name)} Configuration##conf", ref b, ImGuiTreeNodeFlags.DefaultOpen | ImGuiTreeNodeFlags.Bullet | ImGuiTreeNodeFlags.OpenOnArrow);
                if(b == false)
                {
                    ImGui.CloseCurrentPopup();
                }
                /*ImGuiEx.TextV("Character index:");
                ImGui.SameLine();
                ImGui.SetNextItemWidth(100);
                if (ImGui.BeginCombo("##index", data.Index == 0 ? "n/a" : data.Index.ToString()))
                {
                    for (var i = 1; i <= 8; i++)
                    {
                        if (ImGui.Selectable($"{i}"))
                        {
                            data.Index = i;
                        }
                    }
                    ImGui.EndCombo();
                }*/

                //if (C.MultipleServiceAccounts)
                {
                    //ImGui.SameLine();
                    ImGui.SetNextItemWidth(150);
                    if (ImGui.BeginCombo("##sindex", $"服务器 {data.ServiceAccount + 1}"))
                    {
                        for (var i = 1; i <= 10; i++)
                        {
                            if (ImGui.Selectable($"服务器 {i}"))
                            {
                                data.ServiceAccount = i - 1;
                            }
                        }
                        ImGui.EndCombo();
                    }
                }

                if (ImGui.Checkbox("Preferred Character", ref data.Preferred))
                {
                    foreach (var z in C.OfflineData)
                    {
                        if (z.CID != data.CID)
                        {
                            z.Preferred = false;
                        }
                    }
                }
                ImGuiComponents.HelpMarker("When operating in multi mode, if there are no other characters with imminent ventures to collect, it will relog back to your preferred character.");

                ImGui.Checkbox("Show Retainers in Display Order", ref data.ShowRetainersInDisplayOrder);

                ImGuiEx.Text($"Automatic Grand Company Expert Delivery:");
                if (!AutoGCHandin.Operation)
                {
                    ImGui.SetNextItemWidth(200f);
                    ImGuiEx.EnumCombo("##gcHandin", ref data.GCDeliveryType);
                }
                else
                {
                    ImGuiEx.Text($"Can't change this now");
                }
                ImGui.Separator();
                if (ImGui.Button("Exclude Character"))
                {
                    C.Blacklist.Add((data.CID, data.Name));
                }
                ImGuiComponents.HelpMarker("Excluding this character will immediately reset it's settings, remove it from this list and exclude all retainers from being processed. You can still run manual tasks on it's retainers. You can cancel this action in settings.");
                if (ImGui.Button("Reset character data"))
                {
                    deleteData = data.CID;
                }
                ImGuiComponents.HelpMarker("Character's saved data will be removed without excluding it. Character data will be regenerated once you log back into this character.");
                ImGui.EndPopup();
            }

            var initCurpos = ImGui.GetCursorPos();
            var lowestRetainer = C.MultiWaitForAll? data.GetEnabledRetainers().OrderBy(z => z.GetVentureSecondsRemaining()).LastOrDefault() : data.GetEnabledRetainers().OrderBy(z => z.GetVentureSecondsRemaining()).FirstOrDefault();
            if (lowestRetainer != default)
            {
                ImGui.PushStyleColor(ImGuiCol.PlotHistogram, 0xbb500000);
                ImGui.ProgressBar(Math.Max(0, (float)(3600 - lowestRetainer.GetVentureSecondsRemaining(false)) / 3600f), new(ImGui.GetContentRegionAvail().X, ImGui.CalcTextSize("A").Y + ImGui.GetStyle().FramePadding.Y*2), "");
                ImGui.PopStyleColor();
                ImGui.SetCursorPos(initCurpos);
            }
            float pad = 0;
            var col = data.Preferred;
            if (col)
            {
                ImGui.PushStyleColor(ImGuiCol.Text, GradientColor.Get(ImGui.GetStyle().Colors[(int)ImGuiCol.Text], ImGuiColors.ParsedGreen));
            }
            if (shouldExpand && doExpand)
            {
                ImGui.SetNextItemOpen(index == 0);
            }
            if (ImGui.CollapsingHeader($"{(data.WorldOverride == null ? "" : $"{Lang.StrDCV} ")}" + Censor.Character(data.Name, data.World) +$"###chara{data.CID}"))
            {
                SetAsPreferred(data);
                if (col)
                {
                    ImGui.PopStyleColor();
                    col = false;
                }
                pad = ImGui.GetStyle().FramePadding.Y;
                var enabledRetainers = data.GetEnabledRetainers();
                ImGui.PushID(data.CID.ToString());

                var storePos = ImGui.GetCursorPos();
                for (var i = 0; i < data.RetainerData.Count; i++)
                {
                    if (bars.TryGetValue($"{data.CID}{data.RetainerData[i].Name}", out var v))
                    {
                        var ret = data.RetainerData[i];
                        if (!ret.HasVenture || ret.Level == 0 || ret.Name.ToString().IsNullOrEmpty()) continue;
                        ImGui.SetCursorPos(v.start - ImGui.GetStyle().CellPadding with { Y = 0 });
                        ImGui.PushStyleColor(ImGuiCol.PlotHistogram, 0xbb500000);
                        ImGui.PushStyleColor(ImGuiCol.FrameBg, 0);
                        ImGui.ProgressBar(1f - Math.Min(1f, (float)ret.GetVentureSecondsRemaining(false) / (60f * 60f)),
                            new(ImGui.GetContentRegionAvail().X, v.end.Y - v.start.Y - ImGui.GetStyle().CellPadding.Y), "");
                        ImGui.PopStyleColor(2);
                    }
                }
                ImGui.SetCursorPos(storePos);
                if (ImGui.BeginTable("##retainertable", 4, ImGuiTableFlags.SizingFixedFit | ImGuiTableFlags.Borders))
                {
                    ImGui.TableSetupColumn("Name", ImGuiTableColumnFlags.WidthStretch);
                    ImGui.TableSetupColumn("Job");
                    ImGui.TableSetupColumn("Venture");
                    ImGui.TableSetupColumn("");
                    ImGui.TableHeadersRow();
                    var retainers = P.GetSelectedRetainers(data.CID);
                    var retainerData = data.RetainerData;
                    if (data.ShowRetainersInDisplayOrder)
                    {
                        retainerData = retainerData.OrderBy(x => x.DisplayOrder).ToList();
                    }
                    for (var i = 0; i < retainerData.Count; i++)
                    {
                        var ret = retainerData[i];
                        if (ret.Level == 0 || ret.Name.ToString().IsNullOrEmpty()) continue;
                        var adata = Utils.GetAdditionalData(data.CID, ret.Name);
                        ImGui.TableNextRow();
                        ImGui.TableNextColumn();
                        ImGui.TableSetBgColor(ImGuiTableBgTarget.CellBg, 0);
                        var start = ImGui.GetCursorPos();
                        var selected = retainers.Contains(ret.Name.ToString());
                        if (ImGui.Checkbox($"{Censor.Retainer(ret.Name)}", ref selected))
                        {
                            if (selected)
                            {
                                retainers.Add(ret.Name.ToString());
                            }
                            else
                            {
                                retainers.Remove(ret.Name.ToString());
                            }
                        }
                        if (adata.EntrustDuplicates)
                        {
                            ImGui.SameLine();
                            ImGui.PushFont(UiBuilder.IconFont);
                            ImGuiEx.Text(Lang.IconDuplicate);
                            ImGui.PopFont();
                        }
                        if (adata.WithdrawGil)
                        {
                            ImGui.SameLine();
                            ImGui.PushFont(UiBuilder.IconFont);
                            ImGuiEx.Text(Lang.IconGil);
                            ImGui.PopFont();
                        }
                        Svc.PluginInterface.GetIpcProvider<ulong, string, object>(ApiConsts.OnRetainerPostVentureTaskDraw).SendMessage(data.CID, ret.Name);
                        if (adata.IsVenturePlannerActive())
                        {
                            ImGui.SameLine();
                            ImGui.PushFont(UiBuilder.IconFont);
                            ImGuiEx.Text(Lang.IconPlanner);
                            ImGui.PopFont();
                            if (ImGui.IsItemHovered())
                            {
                                ImGui.BeginTooltip();
                                for (int j = 0; j < adata.VenturePlan.ListUnwrapped.Count; j++)
                                {
                                    var v = adata.VenturePlan.ListUnwrapped[j];
                                    if (j == adata.VenturePlanIndex - 1)
                                    {
                                        ImGuiEx.Text(ImGuiColors.ParsedGreen, $"{VentureUtils.GetFancyVentureName(v, data, ret, out _)}");
                                    }
                                    else if (j == adata.VenturePlanIndex || (j == 0 && adata.VenturePlan.PlanCompleteBehavior == PlanCompleteBehavior.Restart_plan && adata.VenturePlanIndex >= adata.VenturePlan.ListUnwrapped.Count))
                                    {
                                        ImGuiEx.Text(ImGuiColors.DalamudYellow, $"{VentureUtils.GetFancyVentureName(v, data, ret, out _)}");
                                    }
                                    else
                                    {
                                        ImGuiEx.Text($"{VentureUtils.GetFancyVentureName(v, data, ret, out _)}");
                                    }
                                }
                                ImGui.EndTooltip();
                            }
                        }
                        var end = ImGui.GetCursorPos();
                        bars[$"{data.CID}{data.RetainerData[i].Name}"] = (start, end);
                        ImGui.TableNextColumn();
                        ImGui.TableSetBgColor(ImGuiTableBgTarget.CellBg, 0);

                        if (ThreadLoadImageHandler.TryGetIconTextureWrap(ret.Job == 0 ? 62143 : (062100 + ret.Job), true, out var t))
                        {
                            ImGui.Image(t.ImGuiHandle, new(24, 24));
                        }
                        else
                        {
                            ImGui.Dummy(new(24, 24));
                        }
                        if (ret.Level > 0)
                        {
                            ImGui.SameLine(0, 2);
                            var level = $"{Lang.CharLevel}{ret.Level}";
                            var add = "";
                            if (adata.Ilvl > -1 && !VentureUtils.IsDoL(ret.Job))
                            {
                                add += $"{Lang.CharItemLevel}{adata.Ilvl}";
                            }
                            if ((adata.Gathering > -1 || adata.Perception > -1) && VentureUtils.IsDoL(ret.Job))
                            {
                                add += $"{Lang.CharPlant}{adata.Gathering}/{adata.Perception}";
                            }
                            bool cap = ret.Level < 90 && data.GetJobLevel(ret.Job) == ret.Level;
                            if (cap) ImGui.PushStyleColor(ImGuiCol.Text, ImGuiColors.DalamudRed);
                            ImGuiEx.TextV(level.ReplaceByChar(Lang.Digits.Normal, Lang.Digits.GameFont));
                            if (cap) ImGui.PopStyleColor();
                            if(C.ShowAdditionalInfo && add != "")
                            {
                                ImGui.SameLine();
                                ImGuiEx.Text(add);
                            }
                        }
                        ImGui.TableNextColumn();
                        ImGui.TableSetBgColor(ImGuiTableBgTarget.CellBg, 0);
                        if (ret.VentureID != 0 && C.ShowAdditionalInfo)
                        {
                            var parts = VentureUtils.GetVentureById(ret.VentureID).GetFancyVentureNameParts(data, ret, out _);
                            if (!parts.Name.IsNullOrEmpty())
                            {
                                var c = parts.YieldRate == 4 ? ImGuiColors.ParsedGreen : ImGui.GetStyle().Colors[(int)ImGuiCol.Text];
                                ImGuiEx.Text(c, $"{(parts.Level != 0?$"{Lang.CharLevel}{parts.Level} ":"")}{parts.Name}");
                                ImGui.SameLine();
                            }
                        }
                        ImGuiEx.Text($"{(!ret.HasVenture ? "No Venture" : Utils.ToTimeString(ret.GetVentureSecondsRemaining(C.TimerAllowNegative)))}");
                        ImGui.TableNextColumn();
                        ImGui.TableSetBgColor(ImGuiTableBgTarget.CellBg, 0);
                        var n = $"{data.CID} {ret.Name} settings";
                        if (ImGuiEx.IconButton(FontAwesomeIcon.Cogs, $"{data.CID} {ret.Name}"))
                        {
                            ImGui.OpenPopup(n);
                        }
                        if (ImGuiEx.BeginPopupNextToElement(n))
                        {
                            ImGui.CollapsingHeader($"{Censor.Retainer(ret.Name)} - {Censor.Character(data.Name)} Configuration  ##conf", ImGuiTreeNodeFlags.DefaultOpen | ImGuiTreeNodeFlags.Bullet | ImGuiTreeNodeFlags.OpenOnArrow);
                            ImGuiEx.Text($"Additional Post-venture Tasks:");
                            ImGui.Checkbox($"Entrust Duplicates", ref adata.EntrustDuplicates);
                            ImGui.Checkbox($"Withdraw/Deposit Gil", ref adata.WithdrawGil);
                            if (adata.WithdrawGil)
                            {
                                if (ImGui.RadioButton("Withdraw", !adata.Deposit)) adata.Deposit = false;
                                if (ImGui.RadioButton("Deposit", adata.Deposit)) adata.Deposit = true;
                                ImGui.SetNextItemWidth(200f);
                                ImGui.InputInt($"Amount, %", ref adata.WithdrawGilPercent.ValidateRange(1, 100), 1, 10);
                            }
                            ImGui.Separator();
                            Svc.PluginInterface.GetIpcProvider<ulong, string, object>(ApiConsts.OnRetainerSettingsDraw).SendMessage(data.CID, ret.Name);
                            ImGui.EndPopup();
                        }
                        ImGui.SameLine();
                        if(ImGuiEx.IconButton(Lang.IconPlanner, $"{data.CID} {ret.Name} planner"))
                        {
                            P.VenturePlanner.Open(data, ret);
                        }
                    }
                    ImGui.EndTable();
                }
                ImGui.Dummy(new(2, 2));
                ImGui.PopID();
            }
            else
            {
                SetAsPreferred(data);
                if (col)
                {
                    ImGui.PopStyleColor();
                    col = false;
                }
            }
            var rightText = ((C.CharEqualize && MultiMode.Enabled) ? $"C: {MultiMode.CharaCnt.GetOrDefault(data.CID)} | " : "") + $"V: {data.Ventures} | I: {data.InventorySpace}";
            var cur = ImGui.GetCursorPos();
            ImGui.SameLine();
            ImGui.SetCursorPos(new(ImGui.GetContentRegionMax().X - ImGui.CalcTextSize(rightText).X - ImGui.GetStyle().FramePadding.X, rCurPos.Y + pad));
            ImGuiEx.Text(rightText);
            ImGui.PopID();
        }

        if(deleteData > 0)
        {
            C.OfflineData.RemoveAll(x => x.CID == deleteData);
        }

        if (C.Verbose && ImGui.CollapsingHeader("Debug"))
        {
            ImGuiEx.Text($"GetCurrentTargetCharacter: {MultiMode.GetCurrentTargetCharacter()}");
            ImGuiEx.Text($"Yes Already: {YesAlready.IsEnabled()}");
            ImGuiEx.Text($"IsCurrentCharacterDone: {MultiMode.IsCurrentCharacterDone()}");
            ImGuiEx.Text($"NextInteraction: {Math.Max(0, MultiMode.NextInteractionAt - Environment.TickCount64)}");
            ImGuiEx.Text($"EnsureCharacterValidity: {MultiMode.EnsureCharacterValidity(true)}");
            ImGuiEx.Text($"GetNearbyBell: {MultiMode.GetNearbyBell()}");
            ImGuiEx.Text($"IsInteractionAllowed: {MultiMode.IsInteractionAllowed()}");
            ImGuiEx.Text($"GetPreferredCharacter: {MultiMode.GetPreferredCharacter()}");
            ImGuiEx.Text($"IsAllRetainersHaveMoreThan15Mins: {MultiMode.IsAllRetainersHaveMoreThan15Mins()}");
            ImGuiEx.Text($"Target ?? Preferred: {MultiMode.GetCurrentTargetCharacter() ?? MultiMode.GetPreferredCharacter()}");
            ImGuiEx.Text($"GetAutoAfkOpt: {MultiMode.GetAutoAfkOpt()}");
            ImGuiEx.Text($"AutoAfkValue: {ConfigModule.Instance()->GetIntValue(145)}");
            ImGuiEx.Text($"LastLongin: {MultiMode.LastLogin:X16}");
            ImGuiEx.Text($"AnyRetainersAvailable: {MultiMode.AnyRetainersAvailable()}");
            ImGuiEx.Text($"IsAnySelectedRetainerFinishesWithin, 60: {MultiMode.IsAnySelectedRetainerFinishesWithin(60)}");
            ImGuiEx.Text($"IsAnySelectedRetainerFinishesWithin, 5*60: {MultiMode.IsAnySelectedRetainerFinishesWithin(5*60)}");
            foreach(var data in C.OfflineData)
            {
                ImGuiEx.Text($"Chatacter {data}\n  GetNeededVentureAmount: {data.GetNeededVentureAmount()}");
            }
        }
    }

    static void SetAsPreferred(OfflineCharacterData x)
    {
        if (ImGui.IsItemClicked(ImGuiMouseButton.Right))
        {
            if (x.Preferred)
            {
                x.Preferred = false;
            }
            else
            {
                C.OfflineData.Each(x => x.Preferred = false);
                x.Preferred = true;
            }
        }
    }
}
