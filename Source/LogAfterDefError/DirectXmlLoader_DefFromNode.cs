using System;
using System.Reflection;
using HarmonyLib;
using Verse;

namespace LogAfterDefError;

[HarmonyPatch]
public static class DirectXmlLoader_DefFromNode
{
    [ThreadStatic] private static int currentDefLoadDepth;
    [ThreadStatic] private static LoadableXmlAsset currentLoadingAsset;

    public static MethodBase[] TargetMethods()
    {
        return
        [
            AccessTools.Method(typeof(DirectXmlLoader), nameof(DirectXmlLoader.DefFromNode)),
            AccessTools.Method(typeof(DirectXmlToObjectNew), nameof(DirectXmlToObjectNew.DefFromNodeNew))
        ];
    }

    public static void Prefix(LoadableXmlAsset loadingAsset, out LoadableXmlAsset __state)
    {
        __state = currentLoadingAsset;
        if (loadingAsset != null)
        {
            currentLoadingAsset = loadingAsset;
        }

        currentDefLoadDepth++;
    }

    public static void Finalizer(LoadableXmlAsset __state)
    {
        currentDefLoadDepth = Math.Max(0, currentDefLoadDepth - 1);
        currentLoadingAsset = __state;
    }

    public static bool TryGetCurrentLoadingAsset(out LoadableXmlAsset loadingAsset)
    {
        loadingAsset = currentLoadingAsset;
        return currentDefLoadDepth > 0 && loadingAsset != null;
    }
}