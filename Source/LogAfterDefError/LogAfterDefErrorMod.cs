using System.Reflection;
using HarmonyLib;
using Mlie;
using UnityEngine;
using Verse;

namespace LogAfterDefError;

public class LogAfterDefErrorMod : Mod
{
    private static string currentVersion;

    public LogAfterDefErrorMod(ModContentPack content) : base(content)
    {
        GetSettings<LogAfterDefErrorModSettings>();
        new Harmony("ordpus.logafterdeferror").PatchAll(Assembly.GetExecutingAssembly());
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        var listing = new Listing_Standard();
        listing.Begin(inRect);
        listing.CheckboxLabeled("LogAfterDefError.Settings.Enabled".Translate(),
            ref LogAfterDefErrorModSettings.Enabled);
        if (currentVersion != null)
        {
            listing.Gap();
            GUI.contentColor = Color.gray;
            listing.Label("LogAfterDefError.CurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing.End();
    }

    public override string SettingsCategory()
    {
        return "LogAfterDefError.Settings".Translate();
    }
}