using HarmonyLib;

namespace PleaseJustFuckingRestart;

[HarmonyPatch(typeof(IdleMode), nameof(IdleMode.SetIdleMode), typeof(bool), typeof(bool))]
internal static class IdleModePatch
{
    public static void Postfix(bool state)
    {
        if (state)
        {
            StaticUnityMethods.OnUpdate += CheckForResponses;
        }
        else
        {
            StaticUnityMethods.OnUpdate -= CheckForResponses;
        }
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
