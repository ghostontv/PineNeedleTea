using ModSettings;

namespace PineNeedleTeaMod
{
    internal class Settings : JsonModSettings
    {
        internal static Settings instance = new Settings();

        [Section("Rose Hips Settings")]

        [Name("Pine Needle Spawn Chance")]
        [Description("Adjust the chance for pine needles to spawn under trees. Default 18%.")]
        [Slider(0f,30f,61)]
        public float NeedleChance = 18f;
    }
}
