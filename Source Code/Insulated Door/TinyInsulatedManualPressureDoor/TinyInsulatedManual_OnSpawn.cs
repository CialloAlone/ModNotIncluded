﻿using Harmony;


[HarmonyPatch(typeof(BuildingComplete), "OnSpawn")]
public class TinyInsulatedManualPressureDoor_BuildingComplete_OnSpawn
{
    public static void Postfix(ref BuildingComplete __instance)
    {
        
        if (string.Compare(__instance.name, "TinyInsulatedManualPressureDoorComplete") == 0)
        {
            __instance.gameObject.AddOrGet<InsulatingDoor>();
        }

        InsulatingDoor insulatingDoor = __instance.gameObject.GetComponent<InsulatingDoor>();

        if (insulatingDoor != null)
        {
            insulatingDoor.SetInsulation(__instance.gameObject, insulatingDoor.door.building.Def.ThermalConductivity);
        }
    }
}