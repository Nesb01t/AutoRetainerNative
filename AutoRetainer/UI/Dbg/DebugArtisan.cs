﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRetainer.UI.Dbg
{
    internal static class DebugArtisan
    {
        internal static void Draw()
        {
            foreach (var d in C.OfflineData)
            {
                foreach (var r in d.RetainerData)
                {
                    ImGuiEx.Text($"Retainer {r.Name}: {r.VentureEndsAt}");
                    ImGui.SameLine();
                    if (ImGui.Button($"1m##{r.Identity}"))
                    {
                        r.VentureEndsAt = P.Time + 60;
                    }
                    ImGui.SameLine();
                    if (ImGui.Button($"15s##{r.Identity}"))
                    {
                        r.VentureEndsAt = P.Time + 15;
                    }
                }
            }
            ImGui.Separator();
            ImGui.Checkbox(nameof(Artisan.WasPaused), ref Artisan.WasPaused);
            {
                var r = SchedulerMain.Reason;
                if (ImGuiEx.EnumCombo(nameof(SchedulerMain.Reason), ref r)) SchedulerMain.Reason = r;
                try
                {
                    if (ImGui.Button(nameof(Artisan.SetEnduranceStatus) + " true")) Artisan.SetEnduranceStatus(true);
                    if (ImGui.Button(nameof(Artisan.SetEnduranceStatus) + " false")) Artisan.SetEnduranceStatus(false);
                    if (ImGui.Button(nameof(Artisan.SetListPause) + " true")) Artisan.SetListPause(true);
                    if (ImGui.Button(nameof(Artisan.SetListPause) + " false")) Artisan.SetListPause(false);
                    if (ImGui.Button(nameof(Artisan.SetStopRequest) + " true")) Artisan.SetStopRequest(true);
                    if (ImGui.Button(nameof(Artisan.SetStopRequest) + " false")) Artisan.SetStopRequest(false);
                    ImGuiEx.Text($"{nameof(Artisan.IsListPaused)}: {Artisan.IsListPaused}");
                    ImGuiEx.Text($"{nameof(Artisan.IsListRunning)}: {Artisan.IsListRunning}");
                    ImGuiEx.Text($"{nameof(Artisan.GetEnduranceStatus)}: {Artisan.GetEnduranceStatus}");
                    ImGuiEx.Text($"{nameof(Artisan.GetStopRequest)}: {Artisan.GetStopRequest}");
                }
                catch (Exception e)
                {
                    ImGuiEx.Text(Colors.Red, $"{e.Message}");
                }
            }
        }
    }
}
