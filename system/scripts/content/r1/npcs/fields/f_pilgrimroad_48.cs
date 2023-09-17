//--- Melia Script ----------------------------------------------------------
// Manahas
//--- Description -----------------------------------------------------------
// NPCs found in and around Manahas.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FPilgrimroad48NpcScript : GeneralScript
{
	public override void Load()
	{
		// Fasika Plateau
		//-------------------------------------------------------------------------
		AddNpc(40001, "Fasika Plateau", "f_pilgrimroad_48", -560.6875, 1498.365, 206, "", "PILGRIM_48_TO_PILGRIM_36_2", "");
		
		// Genar Field
		//-------------------------------------------------------------------------
		AddNpc(40001, "Genar Field", "f_pilgrimroad_48", -1470.036, -2171.64, -6, "", "PILGRIM_48_TO_PILGRIM_49", "");
		
		// [Kedoran Merchant Alliance]{nl}Leopoldas
		//-------------------------------------------------------------------------
		AddNpc(147484, "[Kedoran Merchant Alliance]{nl}Leopoldas", "f_pilgrimroad_48", -165.5285, 1501.194, 6, "PILGRIM_48_LEOPOLDAS");
		
		// [Kedoran Merchant Alliance]{nl}Merrisa
		//-------------------------------------------------------------------------
		AddNpc(152064, "[Kedoran Merchant Alliance]{nl}Merrisa", "f_pilgrimroad_48", -174.2117, -205.1203, 90, "PILGRIM_48_JURATE");
		
		// [Kedoran Merchant Alliance]{nl}Margellius
		//-------------------------------------------------------------------------
		AddNpc(147485, "[Kedoran Merchant Alliance]{nl}Margellius", "f_pilgrimroad_48", -6.034502, -138.5854, -34, "PILGRIM_48_MARCELIJUS");
		
		// [Kedoran Merchant Alliance]{nl}Gerda
		//-------------------------------------------------------------------------
		AddNpc(147473, "[Kedoran Merchant Alliance]{nl}Gerda", "f_pilgrimroad_48", -53.00045, 1594.12, 90, "PILGRIM_48_GERDA");
		
		// [Kedoran Merchant Alliance]{nl}Serapinas
		//-------------------------------------------------------------------------
		AddNpc(147483, "[Kedoran Merchant Alliance]{nl}Serapinas", "f_pilgrimroad_48", 5.860531, 1596.749, -25, "PILGRIM_48_SERAPINAS");
		
		// Record Member
		//-------------------------------------------------------------------------
		AddNpc(20114, "Record Member", "f_pilgrimroad_48", 90.37851, -214.3848, 74, "PILGRIM_48_NPC02");
		
		// Collection Member
		//-------------------------------------------------------------------------
		AddNpc(20158, "Collection Member", "f_pilgrimroad_48", -271.4866, -311.0471, 90, "PILGRIM_48_NPC01");
		
		// Record Member
		//-------------------------------------------------------------------------
		AddNpc(20156, "Record Member", "f_pilgrimroad_48", 148.3876, -199.5782, -47, "PILGRIM_48_NPC03");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40070, " ", "f_pilgrimroad_48", 676.2576, 1285.715, 35, "PILGRIM_48_BOARD");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "f_pilgrimroad_48", 687.7766, 1288.692, 90, "PILGRIM_48_BOARDPLACE");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "f_pilgrimroad_48", -705.6685, -1357.29, 90, "PILGRIM_48_EXCAVATION01");
		
		// PILGRIM_48_SQ_050Trigger for quest
		//-------------------------------------------------------------------------
		AddNpc(20026, "PILGRIM_48_SQ_050Trigger for quest", "f_pilgrimroad_48", 1030.004, 1347.188, 90, "", "PILGRIM_48_SQ_050_TRIGGER", "");
		
		// PILGRIM_48_SQ_060For quest
		//-------------------------------------------------------------------------
		AddNpc(20026, "PILGRIM_48_SQ_060For quest", "f_pilgrimroad_48", -1078.692, 585.9547, 90, "PILGRIM_48_EXCAVATION03");
		
		// PILGRIM_48_SQ_060_DISTANCE_CHECK
		//-------------------------------------------------------------------------
		AddNpc(20026, "PILGRIM_48_SQ_060_DISTANCE_CHECK", "f_pilgrimroad_48", -870.4012, 356.5185, 90, "", "PILGRIM_48_SQ_060_E", "");
		
		// PILGRIM_48_SQ_090_DISTANCE_CHECK
		//-------------------------------------------------------------------------
		AddNpc(20026, "PILGRIM_48_SQ_090_DISTANCE_CHECK", "f_pilgrimroad_48", 1638.641, 239.7801, 90, "", "PILGRIM_48_SQ_090_E", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "f_pilgrimroad_48", -260.2179, 19.69579, 45, "WARP_F_PILGRIMROAD_48", "STOUP_CAMP", "STOUP_CAMP");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "f_pilgrimroad_48", 234, 1479, 90, "TREASUREBOX_LV_F_PILGRIMROAD_4826");
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(155026, "Pile of Soil", "f_pilgrimroad_48", 310.2977, -1497.419, 90, "PILGRIM48_RP_1_OBJ");
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(155026, "Pile of Soil", "f_pilgrimroad_48", 70.58665, -1515.514, 90, "PILGRIM48_RP_1_OBJ");
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(155026, "Pile of Soil", "f_pilgrimroad_48", -115.1053, -1355.233, 90, "PILGRIM48_RP_1_OBJ");
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(155026, "Pile of Soil", "f_pilgrimroad_48", -117.0158, -1158.186, 90, "PILGRIM48_RP_1_OBJ");
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(155026, "Pile of Soil", "f_pilgrimroad_48", -116.0068, -967.9064, 90, "PILGRIM48_RP_1_OBJ");
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(155026, "Pile of Soil", "f_pilgrimroad_48", 120.8987, -1110.406, 90, "PILGRIM48_RP_1_OBJ");
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(155026, "Pile of Soil", "f_pilgrimroad_48", 253.4272, -1164.96, 90, "PILGRIM48_RP_1_OBJ");
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(155026, "Pile of Soil", "f_pilgrimroad_48", 429.037, -1266.777, 90, "PILGRIM48_RP_1_OBJ");
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(155026, "Pile of Soil", "f_pilgrimroad_48", 695.1608, -1366.195, 90, "PILGRIM48_RP_1_OBJ");
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(155026, "Pile of Soil", "f_pilgrimroad_48", 526.9686, -1433.375, 90, "PILGRIM48_RP_1_OBJ");
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(155026, "Pile of Soil", "f_pilgrimroad_48", 637.7759, -1152.961, 90, "PILGRIM48_RP_1_OBJ");
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(155026, "Pile of Soil", "f_pilgrimroad_48", 651.275, -1005.753, 90, "PILGRIM48_RP_1_OBJ");
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(155026, "Pile of Soil", "f_pilgrimroad_48", 574.7047, -820.0602, 90, "PILGRIM48_RP_1_OBJ");
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(155026, "Pile of Soil", "f_pilgrimroad_48", 390.1572, -776.9429, 90, "PILGRIM48_RP_1_OBJ");
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(155026, "Pile of Soil", "f_pilgrimroad_48", 204.1524, -853.7637, 90, "PILGRIM48_RP_1_OBJ");
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(155026, "Pile of Soil", "f_pilgrimroad_48", 353.8049, -1007.111, 90, "PILGRIM48_RP_1_OBJ");
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(155026, "Pile of Soil", "f_pilgrimroad_48", 683.2675, -898.1469, 90, "PILGRIM48_RP_1_OBJ");
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(155026, "Pile of Soil", "f_pilgrimroad_48", 219.7955, -1335.437, 90, "PILGRIM48_RP_1_OBJ");
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(155026, "Pile of Soil", "f_pilgrimroad_48", 534.6473, -933.1989, 90, "PILGRIM48_RP_1_OBJ");
		
		// [Inquisitor Master]{nl}Thomas Iquinostasys
		//-------------------------------------------------------------------------
		AddNpc(153169, "[Inquisitor Master]{nl}Thomas Iquinostasys", "f_pilgrimroad_48", -510.8484, -319.2973, 90, "INQUISITOR_MASTER");
	}
}
