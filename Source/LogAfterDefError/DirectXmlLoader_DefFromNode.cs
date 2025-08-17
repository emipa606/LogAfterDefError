using System;
using System.Reflection;
using HarmonyLib;
using Verse;

namespace LogAfterDefError;

[HarmonyPatch]
public static class DirectXmlLoader_DefFromNode
{
    private static readonly FieldInfo messageQueueFieldInfo = AccessTools.Field(typeof(Log), "messageQueue");
    private static readonly FieldInfo messageCountFieldInfo = AccessTools.Field(typeof(Log), "messageCount");
    private static readonly FieldInfo lastMessageFieldInfo = AccessTools.Field(typeof(LogMessageQueue), "lastMessage");

    public static MethodBase[] TargetMethods()
    {
        return
        [
            AccessTools.Method(typeof(DirectXmlLoader), nameof(DirectXmlLoader.DefFromNode)),
            AccessTools.Method(typeof(DirectXmlToObjectNew), nameof(DirectXmlToObjectNew.DefFromNodeNew))
        ];
    }

    public static void Prefix(ref LogMessage __state)
    {
        var messageQueue = (LogMessageQueue)messageQueueFieldInfo.GetValue(null);
        if (messageQueue == null)
        {
            __state = null;
            return;
        }

        __state = (LogMessage)lastMessageFieldInfo.GetValue(messageQueue);
    }

    public static void Postfix(Def __result, LoadableXmlAsset loadingAsset, LogMessage __state)
    {
        if (__result == null || !LogAfterDefErrorModSettings.Enabled)
        {
            return;
        }

        var messageQueue = (LogMessageQueue)messageQueueFieldInfo.GetValue(null);
        if (messageQueue == null)
        {
            return;
        }

        var lastMessage = (LogMessage)lastMessageFieldInfo.GetValue(messageQueue);
        if (lastMessage == __state)
        {
            return;
        }

        var mod = loadingAsset?.mod;
        if ((int)messageCountFieldInfo.GetValue(null) > 900)
        {
            Log.ResetMessageCount();
        }

        Log.Message(
            $"[Def Error]: {__result.defName}{Environment.NewLine}{mod?.Name}{loadingAsset?.FullFilePath?.Replace(mod?.RootDir, "")}");
    }
}