using Dalamud.Interface.Components;
using PunishLib.ImGuiMethods;

namespace AutoRetainer.UI.Settings;

internal static class Beta
{
    internal static void Draw()
    {
        ImGuiEx.Text(ImGuiColors.DalamudOrange, $"These features might be incomplete, cause problems, or simply not work.");
        //ImGui.Checkbox($"Retry item search if it was too fast", ref C.RetryItemSearch);
    }
}
