using ModSettings;

namespace PineNeedleTeaMod
{
    internal class Settings : JsonModSettings
    {
        internal static Settings instance = new Settings();

        [Section("Pine Needle Settings")]

        [Name("Pine Needle Spawn Chance")]
        [Description("Adjust the chance for pine needles to spawn under trees. Default 15%.")]
        [Slider(0f,25f,51)]
        public float NeedleChance = 15f;
    }
}
