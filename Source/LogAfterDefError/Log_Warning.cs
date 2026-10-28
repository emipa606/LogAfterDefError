using System;
using HarmonyLib;
using Verse;

namespace LogAfterDefError;

[HarmonyPatch(typeof(Log), nameof(Log.Warning), typeof(string))]
public static class Log_Warning
{
    public static void Prefix(string text)
    {
        if (!LogAfterDefErrorModSettings.Enabled || string.IsNullOrWhiteSpace(text))
        {
            return;
        }

        if (!DirectXmlLoader_DefFromNode.TryGetCurrentLoadingAsset(out var loadingAsset))
        {
            return;
        }

        var mod = loadingAsset.mod;
        var rootDir = mod?.RootDir;
        var relativePath = loadingAsset.FullFilePath;
        if (!string.IsNullOrEmpty(rootDir) && !string.IsNullOrEmpty(relativePath))
        {
            relativePath = relativePath.Replace(rootDir, "");
        }

        Log.Message($"[Def Error]: {text}{Environment.NewLine}{mod?.Name}{relativePath}");
    }
}