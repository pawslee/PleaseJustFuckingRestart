using LabApi.Features.Wrappers;
using LabApi.Loader.Features.Plugins;

namespace PleaseJustFuckingRestart;

internal class PleaseJustFuckingRestartPlugin : Plugin
{
    public override string Name { get; } = "PleaseJustFuckingRestart";

    public override string Description { get; } = "makes soft restart actually fucking restart";

    public override string Author { get; } = "Rue <3";

    public override Version Version { get; } = new(1, 0, 0);

    public override Version RequiredApiVersion { get; } = typeof(Player).Assembly.GetName().Version;

    public override void Enable()
    {
        StaticUnityMethods.OnUpdate += CheckForResponses;
    }

    public override void Disable()
    {
        StaticUnityMethods.OnUpdate -= CheckForResponses;
    }

    private static void CheckForResponses()
    {
        if (IdleMode.IdleModeActive)
        {
            while (ServerConsole.PrompterQueue.TryDequeue(out string text))
            {
                if (!string.IsNullOrWhiteSpace(text))
                {
                    ServerConsole.EnterCommand(text, ServerConsole.Scs);
                }
            }
        }
    }
}