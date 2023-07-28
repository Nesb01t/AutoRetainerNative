using Dalamud.Logging;
using Dalamud.Plugin;
using Newtonsoft.Json;
using PunishLib.ImGuiMethods;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace PunishLib
{
    public class PunishLibMain
    {
        internal static string PluginName = "";
        internal static DalamudPluginInterface PluginInterface;
        internal static PluginManifest PluginManifest;
        internal static AboutPlugin About;

        public static void Init(DalamudPluginInterface pluginInterface, IDalamudPlugin instance, AboutPlugin about = null, params PunishOption[] opts)
        {
            PluginName = instance.Name;
            PluginInterface = pluginInterface;
            PluginManifest = new();
            About = about ?? new();
            GenericHelpers.Safe(delegate
            {
                var path = Path.Combine(PunishLibMain.PluginInterface.AssemblyLocation.DirectoryName,
                    $"{Path.GetFileNameWithoutExtension(PunishLibMain.PluginInterface.AssemblyLocation.FullName)}.json");
                PluginLog.Debug($"Path: {path}");
                PluginManifest = JsonConvert.DeserializeObject<PluginManifest>(File.ReadAllText(path));
            });
            if (opts.Contains(PunishOption.DefaultKoFi))
            {
                About.Sponsor = "https://ko-fi.com/spetsnaz";
            }
        }

        public static void Init(DalamudPluginInterface pluginInterface, IDalamudPlugin instance, params PunishOption[] opts) => Init(pluginInterface, instance, null, opts);

        public static void Dispose() { }
    }
}
