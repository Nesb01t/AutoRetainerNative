using Dalamud.Logging;
using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PunishLib
{
    public static class GenericHelpers
    {
        public static uint ToUint(this Vector4 color)
        {
            return ImGui.ColorConvertFloat4ToU32(color);
        }

        public static void Safe(System.Action a, bool suppressErrors = false)
        {
            try
            {
                a();
            }
            catch (Exception e)
            {
                if (!suppressErrors) PluginLog.Error($"{e.Message}\n{e.StackTrace ?? ""}");
            }
        }
        public static bool TryGetFirst<K, V>(this IDictionary<K, V> dictionary, Func<KeyValuePair<K, V>, bool> predicate, out KeyValuePair<K, V> keyValuePair)
        {
            try
            {
                keyValuePair = dictionary.First(predicate);
                return true;
            }
            catch (Exception)
            {
                keyValuePair = default;
                return false;
            }
        }
    }
}
