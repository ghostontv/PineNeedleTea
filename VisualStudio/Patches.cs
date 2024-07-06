using UnityEngine;
using Il2Cpp;
using MelonLoader;





namespace PineNeedleTeaMod
{
    //Patch RadialObjectSpawner to spawn Pine Needles.

    [HarmonyPatch(typeof(RadialObjectSpawner), "GetNextPrefabToSpawn")]
    internal class AddNeedleSpawns
    {
        private static void Postfix(RadialObjectSpawner __instance, ref GameObject __result)
        {

            if (__instance != null && __instance.name.Contains("RadialSpawn_sticks") && PineNeedleTeaUtils.Needles != null)
            {
                if (Utils.RollChance(Settings.instance.NeedleChance))
                {
                    __result = PineNeedleTeaUtils.Needles;
                }
            }
        }
    }
}

