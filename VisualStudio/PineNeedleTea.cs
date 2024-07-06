using PineNeedleTeaMod;
using Il2Cpp;
using Il2CppRewired.Utils;
using Il2CppTLD.BigCarry;
using Il2CppTLD.Gear;
using System.Runtime.InteropServices;


namespace PineNeedleTeaMod
{
	public class PineNeedleTea : MelonMod
	{

        private static AssetBundle? assetBundle;

        internal static AssetBundle TeaTexturesBundle
        {
            get => assetBundle ?? throw new System.NullReferenceException(nameof(assetBundle));
        }
        public override void OnInitializeMelon()
		{
			MelonLoader.MelonLogger.Msg(System.ConsoleColor.Green, "Freshly brewed pine needle tea...");
            assetBundle = LoadAssetBundle("PineNeedleTea.pineteaassets");
            Settings.instance.AddToModSettings("Pine Needle Tea");
            //Settings.OnLoad();

        }
		private static bool Done;
		public static bool SceneLoaded;

		public override void OnSceneWasLoaded(int buildIndex, string sceneName) //When scene is loaded
		{
			if(PineNeedleTeaUtils.IsScenePlayable(sceneName))  //Checks if it's not a menu scene
			{
				SceneLoaded = true;

				ChangeItemProperties();
			}


		}
        private static AssetBundle LoadAssetBundle(string path)
        {
            using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            MemoryStream memoryStream = new MemoryStream((int)stream.Length);
            stream.CopyTo(memoryStream);

            return memoryStream.Length != 0
                ? AssetBundle.LoadFromMemory(memoryStream.ToArray())
                : throw new System.Exception("No data loaded!");
        }


        private static void ChangeItemProperties()
        {
            GameObject gear;
            Texture2D LiquidTexture = PineNeedleTea.TeaTexturesBundle.LoadAsset<Texture2D>("T_PineTea_Cooking");
            Material LiquidMaterial = new Material(GearItem.LoadGearItemPrefab("GEAR_CoffeeCup").gameObject.GetComponent<Cookable>().m_CookingPotMaterialsList[0]);
            LiquidMaterial.SetTexture("_Main_texture2", LiquidTexture);

            gear = GearItem.LoadGearItemPrefab("GEAR_PineNeedlePrepared").gameObject;

            gear.GetComponent<Cookable>().m_CookingPotMaterialsList = new Material[1] { LiquidMaterial };

            gear = GearItem.LoadGearItemPrefab("GEAR_PineNeedleTea").gameObject;

            
            gear.GetComponent<FoodItem>().m_HeatedWhenCooked = true;
            gear.GetComponent<Cookable>().m_CookingPotMaterialsList = new Material[1] { LiquidMaterial };





        }
    }
}