using Dalamud.Interface;
using Dalamud.Interface.Colors;
using Dalamud.Interface.Internal.Notifications;
using Dalamud.Logging;
using Dalamud.Plugin;
using ImGuiNET;
using Lumina.Excel.GeneratedSheets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PunishLib.ImGuiMethods
{
    public static class AboutTab
    {
        static string GetImageURL()
        {
            return PunishLibMain.PluginManifest.IconUrl ?? "";
        }

        public static void Draw(IDalamudPlugin P)
        {
            ImGuiEx.ImGuiLineCentered("About1", delegate
            {
                ImGuiEx.Text($"{P.Name} - {PunishLibMain.PluginManifest.AssemblyVersion}");
            });

            PunishLibMain.About.WithLoveBy();

            ImGuiHelpers.ScaledDummy(10f);
            ImGuiEx.ImGuiLineCentered("About2", delegate
            {
                if (ThreadLoadImageHandler.TryGetTextureWrap(GetImageURL(), out var texture))
                {
                    ImGui.Image(texture.ImGuiHandle, new(200f, 200f));
                }
            });
            ImGuiHelpers.ScaledDummy(10f);
            ImGuiEx.ImGuiLineCentered("About3", delegate
            {
                /*if (ImGuiEx.IconButton((FontAwesomeIcon)0xf392))
                {
                    GenericHelpers.ShellStart("https://discord.gg/Zzrcc8kmvy");
                }
                ImGui.SameLine();*/
                ImGui.TextWrapped("Join our Discord community for project announcements, updates, and support.");
            });
            ImGuiEx.ImGuiLineCentered("About4", delegate
            {
                if (ImGui.Button("Discord"))
                {
                    Process.Start(new ProcessStartInfo()
                    {
                        FileName = "https://discord.gg/Zzrcc8kmvy",
                        UseShellExecute = true
                    }); 
                }
                ImGui.SameLine();
                if (ImGui.Button("Repository"))
                {
                    ImGui.SetClipboardText("https://love.puni.sh/ment.json");
                    PunishLibMain.PluginInterface.UiBuilder.AddNotification("Link copied to clipboard", PunishLibMain.PluginName, NotificationType.Success);
                }
                if(PunishLibMain.PluginManifest.RepoUrl != null)
                {
                    ImGui.SameLine();
                    if (ImGui.Button("Source Code"))
                    {
                        Process.Start(new ProcessStartInfo()
                        {
                            FileName = PunishLibMain.PluginManifest.RepoUrl,
                            UseShellExecute = true
                        }); 
                    }
                }
                if (PunishLibMain.About.Sponsor != null)
                {
                    ImGui.SameLine();
                    if (ImGui.Button("Sponsor"))
                    {
                        Process.Start(new ProcessStartInfo()
                        {
                            FileName = PunishLibMain.About.Sponsor,
                            UseShellExecute = true
                        });
                    }
                }
            });
        }
    }
}
