using HarmonyLib;

namespace ValheimBiggerChests.Patches
{
    [HarmonyPatch(typeof(Container), "Awake")]
    public static class ContainerPatches
    {
		public static (uint Width, uint Height) personalChest = (3, 2); 
		public static (uint Width, uint Height) standardChest = (5, 2); 
		public static (uint Width, uint Height) reinforcedChest = (6, 3); 
        private static void Prefix(ref Container __instance)
        {
            applyContainerSizes(__instance);
        }

        private static void applyContainerSizes(Container instance)
        {
			/*
            if (instance.m_wagon)
            {
                instance.m_width = 8;
                instance.m_height = 4;

                return;
            }

            Ship ship = instance.gameObject.transform.parent?.GetComponent<Ship>();

            if (ship)
            {
                if (ship.name.StartsWith("VikingShip"))
                {
                    instance.m_width = 7;
                    instance.m_height = 4;

                    return;
                }

                if (ship.name.StartsWith("Karve"))
                {
                    instance.m_width = 3;
                    instance.m_height = 3;

                    return;
                }

                return;
            }*/

            if (instance.name.StartsWith("piece_chest_wood"))
            {
				instance.m_width = (int)standardChest.Width;
                instance.m_height = (int)standardChest.Height;

                return;
            }

            if (instance.name.StartsWith("piece_chest_private"))
            {
                instance.m_width = (int)personalChest.Width;
                instance.m_height = (int)personalChest.Height;
				
                return;
            }

            if (instance.name.StartsWith("piece_chest"))
            {
                instance.m_width = (int)reinforcedChest.Width;
                instance.m_height = (int)reinforcedChest.Height;
				
                return;
            }
        }
    }

    [HarmonyPatch(typeof(Container), "GetHoverText")]
    public static class DebugHoverText
    {
        private static void Postfix(ref Container __instance, ref string __result)
        {
            //Ship ship = __instance.gameObject.transform.parent?.GetComponent<Ship>();

            //if (ship)
            //{
            //    __result = ship.name;
            //}
            //else {
            //    __result = __instance.name;
            //}
        }
    }


}
