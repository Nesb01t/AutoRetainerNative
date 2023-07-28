using Dalamud.Interface;
using Dalamud.Interface.Colors;
using ImGuiNET;
using PunishLib.ImGuiMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunishLib
{
    public class AboutPlugin
    {
        public string Sponsor { get; set; }
        public string Developer { get; set; }

        internal Action WithLoveBy => Developer == null ? WithLoveByPunish : WithLoveByOther;

        static void WithLoveByPunish()
        {
            ImGuiEx.ImGuiLineCentered("AboutHeader", delegate
            {
                ImGuiEx.Text($"Published and developed with ");
                ImGui.PushFont(UiBuilder.IconFont);
                ImGui.SameLine(0, 0);
                ImGuiEx.Text(ImGuiColors.DalamudRed, FontAwesomeIcon.Heart.ToIconString());
                ImGui.PopFont();
                ImGui.SameLine(0, 0);
                ImGuiEx.Text($" by Puni.sh");
            });
        }

        static void WithLoveByOther()
        {
            //Developed with ❤️ by {Developer}, published by Puni.sh
            ImGuiEx.ImGuiLineCentered("AboutHeader", delegate
            {
                ImGuiEx.Text($"Developed with ");
                ImGui.PushFont(UiBuilder.IconFont);
                ImGui.SameLine(0, 0);
                ImGuiEx.Text(ImGuiColors.DalamudRed, FontAwesomeIcon.Heart.ToIconString());
                ImGui.PopFont();
                ImGui.SameLine(0, 0);
                ImGuiEx.Text($" by {PunishLibMain.About.Developer}, published by Puni.sh");
            });
        }
    }

}
