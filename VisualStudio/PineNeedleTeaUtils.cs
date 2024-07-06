using UnityEngine;
using Il2Cpp;
using MelonLoader;
using UnityEngine.AddressableAssets;





namespace PineNeedleTeaMod
{
    internal static class PineNeedleTeaUtils
    {

        public static bool IsScenePlayable(string scene)
        {
            return !(string.IsNullOrEmpty(scene) || scene.Contains("MainMenu") || scene == "Boot" || scene == "Empty");
        }
        
        
        public static GameObject Needles = Addressables.LoadAssetAsync<GameObject>("GEAR_PineNeedle").WaitForCompletion();




    }






}


