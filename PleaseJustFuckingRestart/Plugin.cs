using HarmonyLib;
using LabApi.Features.Wrappers;
using LabApi.Loader.Features.Plugins;

namespace PleaseJustFuckingRestart;

internal class PleaseJustFuckingRestartPlugin : Plugin
{
    private readonly Harmony harmony = new("PleaseJustFuckingRestart");

    public override string Name { get; } = "PleaseJustFuckingRestart";

    public override string Description { get; } = "makes the restart command not take 10 gazillion years to restart";

    public override string Author { get; } = "Rue <3";

    public override Version Version { get; } = new(1, 0, 0);

    public override Version RequiredApiVersion { get; } = typeof(Player).Assembly.GetName().Version;

    public override void Enable()
    {
        harmony.PatchAll();
    }

    public override void Disable()
    {
        harmony.UnpatchAll();
    }
}