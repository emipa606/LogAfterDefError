using Verse;

namespace LogAfterDefError;

public class LogAfterDefErrorModSettings : ModSettings
{
    public static bool Enabled = true;

    public override void ExposeData()
    {
        Scribe_Values.Look(ref Enabled, "enabled", true);
    }
}