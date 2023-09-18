//--- Melia Script ----------------------------------------------------------
// Royal Mausoleum 1F
//--- Description -----------------------------------------------------------
// NPCs found in and around Royal Mausoleum 1F.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DZachariel32NpcScript : GeneralScript
{
	public override void Load()
	{
		// Zachariel Crossroads
		//-------------------------------------------------------------------------
		AddNpc(40001, "Zachariel Crossroads", "d_zachariel_32", 30, -2423, 0, "", "ZACHARIEL32_ROKAS31", "");
		
		// Royal Mausoleum 2F
		//-------------------------------------------------------------------------
		AddNpc(40001, "Royal Mausoleum 2F", "d_zachariel_32", 32, 2863, 179, "", "ZACHARIEL32_ZACHARIEL33", "");
		
		// Ramstis Ridge
		//-------------------------------------------------------------------------
		AddNpc(40001, "Ramstis Ridge", "d_zachariel_32", -1418, -2199, 262, "", "ZACHARIEL32_ROKAS25", "");
		
		// Tiltas Valley
		//-------------------------------------------------------------------------
		AddNpc(40001, "Tiltas Valley", "d_zachariel_32", 1080, -2192, -86, "", "ZACHARIEL32_ROKAS28", "");
		
		// Power Source Consecration Container
		//-------------------------------------------------------------------------
		AddNpc(40064, "Power Source Consecration Container", "d_zachariel_32", 57, 332, 90, "ZACHA32_MQ_04_D");
		
		// Power Source Consecration Container
		//-------------------------------------------------------------------------
		AddNpc(40064, "Power Source Consecration Container", "d_zachariel_32", 43, -70, 90, "ZACHA32_MQ_04_D");
		
		// Royal Mausoleum Foundation Stone
		//-------------------------------------------------------------------------
		AddNpc(147467, "Royal Mausoleum Foundation Stone", "d_zachariel_32", 37.35041, -2046.595, 0, "ZACHA1F_MQ_01");
		
		// Sleeping Boowook
		//-------------------------------------------------------------------------
		AddNpc(57565, "Sleeping Boowook", "d_zachariel_32", -11, -1206, 90, "ZACHA1F_MQ_01_MON");
		
		// Sleeping Boowook
		//-------------------------------------------------------------------------
		AddNpc(57565, "Sleeping Boowook", "d_zachariel_32", -106.3332, -1012.227, 90, "ZACHA1F_MQ_01_MON");
		
		// Sleeping Boowook
		//-------------------------------------------------------------------------
		AddNpc(57565, "Sleeping Boowook", "d_zachariel_32", 46.2577, -551.9203, 90, "ZACHA1F_MQ_01_MON");
		
		// Sleeping Boowook
		//-------------------------------------------------------------------------
		AddNpc(57565, "Sleeping Boowook", "d_zachariel_32", 88.2622, -1006.387, 90, "ZACHA1F_MQ_01_MON");
		
		// Sleeping Boowook
		//-------------------------------------------------------------------------
		AddNpc(57565, "Sleeping Boowook", "d_zachariel_32", -2.184027, -690.2549, 90, "ZACHA1F_MQ_01_MON");
		
		// Sleeping Boowook
		//-------------------------------------------------------------------------
		AddNpc(57565, "Sleeping Boowook", "d_zachariel_32", 167.8412, -1061.869, 90, "ZACHA1F_MQ_01_MON");
		
		// Sleeping Boowook
		//-------------------------------------------------------------------------
		AddNpc(57565, "Sleeping Boowook", "d_zachariel_32", 27.68333, -1397.34, 90, "ZACHA1F_MQ_01_MON");
		
		// Sleeping Boowook
		//-------------------------------------------------------------------------
		AddNpc(57565, "Sleeping Boowook", "d_zachariel_32", 333.2809, -978.3303, 90, "ZACHA1F_MQ_01_MON");
		
		// Royal Mausoleum Cube Manual
		//-------------------------------------------------------------------------
		AddNpc(47252, "Royal Mausoleum Cube Manual", "d_zachariel_32", -567, -929, 0, "ZACHA1F_MQ_02");
		
		// Royal Mausoleum Guard Cube
		//-------------------------------------------------------------------------
		AddNpc(47262, "Royal Mausoleum Guard Cube", "d_zachariel_32", -871.8037, -844.1492, 90, "ZACHA1F_MQ_01_MON");
		
		// Royal Mausoleum Guard Cube
		//-------------------------------------------------------------------------
		AddNpc(47262, "Royal Mausoleum Guard Cube", "d_zachariel_32", -1145.665, -840.3893, 178, "ZACHA1F_MQ_01_MON");
		
		// Royal Mausoleum Guard Cube
		//-------------------------------------------------------------------------
		AddNpc(47262, "Royal Mausoleum Guard Cube", "d_zachariel_32", -1154.03, -1105.388, 178, "ZACHA1F_MQ_01_MON");
		
		// Royal Mausoleum Guard Cube
		//-------------------------------------------------------------------------
		AddNpc(47262, "Royal Mausoleum Guard Cube", "d_zachariel_32", -869.8099, -1113.928, 177, "ZACHA1F_MQ_01_MON");
		
		// Hidden Chest
		//-------------------------------------------------------------------------
		AddNpc(45324, "Hidden Chest", "d_zachariel_32", 1474.38, -2200.65, 268, "ZACHA32_DEVICE_1_2");
		
		// Hidden Sanctum Seal
		//-------------------------------------------------------------------------
		AddNpc(47102, "Hidden Sanctum Seal", "d_zachariel_32", -1031, -2204, 90, "ZACHA32_DEVICE02");
		
		// Defense System Manual
		//-------------------------------------------------------------------------
		AddNpc(47252, "Defense System Manual", "d_zachariel_32", -1020, -477, 0, "ZACHA1F_MQ_03");
		
		// Gate Guardian's Role
		//-------------------------------------------------------------------------
		AddNpc(47252, "Gate Guardian's Role", "d_zachariel_32", -530, 176, 10, "ZACHA1F_MQ_04");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20026, "", "d_zachariel_32", 50, 1191, 90, "", "ZACHA1F_MQ_05", "");
		
		// Royal Mausoleum Blueprint
		//-------------------------------------------------------------------------
		AddNpc(47254, "Royal Mausoleum Blueprint", "d_zachariel_32", 856, 222, 40, "ZACHA1F_SQ_01");
		
		// Royal Mausoleum Stone Lantern
		//-------------------------------------------------------------------------
		AddNpc(47253, "Royal Mausoleum Stone Lantern", "d_zachariel_32", 1111, -757, 0, "ZACHA1F_SQ_02");
		
		// Royal Mausoleum Regulatory Magic Manual
		//-------------------------------------------------------------------------
		AddNpc(47254, "Royal Mausoleum Regulatory Magic Manual", "d_zachariel_32", -95, 280, 0, "ZACHA1F_SQ_03");
		
		// Royal Mausoleum Magic Regulator
		//-------------------------------------------------------------------------
		AddNpc(47261, "Royal Mausoleum Magic Regulator", "d_zachariel_32", -1006, 1408, 90, "ZACHA1F_SQ_04");
		
		// Royal Mausoleum Magic Regulator
		//-------------------------------------------------------------------------
		AddNpc(47261, "Royal Mausoleum Magic Regulator", "d_zachariel_32", 1112, 1408, 90, "ZACHA1F_SQ_05");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "d_zachariel_32", -68.32312, -2170.473, 57, "WARP_D_ZACHARIEL_32", "STOUP_CAMP", "STOUP_CAMP");
		
		// Royal Mausoleum Tombstone
		//-------------------------------------------------------------------------
		AddNpc(47251, "Royal Mausoleum Tombstone", "d_zachariel_32", 159.718, 762.7321, 6, "ZACHA1F_MQ_05_NPC");
		
		// Malfunctioning Guardian Device
		//-------------------------------------------------------------------------
		AddNpc(47253, "Malfunctioning Guardian Device", "d_zachariel_32", -1054, 383, 0, "", "ZACHA1F_MQ_03_LANTERN", "");
		
		// Malfunctioning Guardian Device
		//-------------------------------------------------------------------------
		AddNpc(47253, "Malfunctioning Guardian Device", "d_zachariel_32", -943, 383, 0, "", "ZACHA1F_MQ_03_LANTERN", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "d_zachariel_32", 862.07, 414.35, 90, "TREASUREBOX_LV_D_ZACHARIEL_323023");
		
		// Royal Mausoleum Guardian
		//-------------------------------------------------------------------------
		AddNpc(47260, "Royal Mausoleum Guardian", "d_zachariel_32", 50.28388, 1806.078, -1, "ZACHA32_RP_1_NPC");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "d_zachariel_32", -1271.534, 1422.721, 90, "", "EXPLORER_MISLE44", "");
	}
}
