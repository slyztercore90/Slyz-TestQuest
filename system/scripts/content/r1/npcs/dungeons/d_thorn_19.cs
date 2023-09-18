//--- Melia Script ----------------------------------------------------------
// Gate Route
//--- Description -----------------------------------------------------------
// NPCs found in and around Gate Route.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DThorn19NpcScript : GeneralScript
{
	public override void Load()
	{
		// Spring Light Woods
		//-------------------------------------------------------------------------
		AddNpc(40001, "Spring Light Woods", "d_thorn_19", 215, 3115, 225, "", "THORN19_SIAULIAI46_1", "");
		
		// Septyni Glen
		//-------------------------------------------------------------------------
		AddNpc(40001, "Septyni Glen", "d_thorn_19", -286, -3924, 259, "", "THORN19_HUEVILLAGE58_4", "");
		
		// Sirdgela Forest
		//-------------------------------------------------------------------------
		AddNpc(40001, "Sirdgela Forest", "d_thorn_19", 1980.25, -1018.94, -79, "", "THORN19_THORN20", "");
		
		// Altar of Harmony
		//-------------------------------------------------------------------------
		AddNpc(47121, "Altar of Harmony", "d_thorn_19", 108, 311, 90, "THORN19_HOLY01");
		
		// The Second Gateway (1) Trigger
		//-------------------------------------------------------------------------
		AddNpc(20041, "The Second Gateway (1) Trigger", "d_thorn_19", -861, -2339, 90, "", "THORN19_GATEWAY_2_TRIGGER", "");
		
		// Believer Domas
		//-------------------------------------------------------------------------
		AddNpc(147398, "Believer Domas", "d_thorn_19", -174.67, -2745.45, 32, "THORN19_BELIEVER");
		
		// Pocket Containing Something
		//-------------------------------------------------------------------------
		AddNpc(47160, "Pocket Containing Something", "d_thorn_19", -733.09, 285.37, -7, "THORN19_CHAFER_LURE");
		
		// Bramble Bush
		//-------------------------------------------------------------------------
		AddNpc(20026, "Bramble Bush", "d_thorn_19", 166.89, 1603.78, 90, "", "THORN19_THORNBUSH", "");
		
		// Thorn Gate
		//-------------------------------------------------------------------------
		AddNpc(47088, "Thorn Gate", "d_thorn_19", 102.9, -1817.39, 0, "", "THORN_GATEWAY_1", "");
		
		// Thorn Gate
		//-------------------------------------------------------------------------
		AddNpc(47090, "Thorn Gate", "d_thorn_19", 189.14, 1387.8, 21, "", "THORN_GATEWAY_2", "");
		
		// Thorn Gate
		//-------------------------------------------------------------------------
		AddNpc(47087, "Thorn Gate", "d_thorn_19", 2122.89, 955.78, 18, "", "THORN_GATEWAY_3", "");
		
		// Altar of Purification
		//-------------------------------------------------------------------------
		AddNpc(46213, "Altar of Purification", "d_thorn_19", 2040, 1670, -7, "THORN19_REFINE");
		
		// Charge RP
		//-------------------------------------------------------------------------
		AddNpc(20025, "Charge RP", "d_thorn_19", 464.79, 2466.54, 90, "THORN19_RECHARGE1");
		
		// Charge RP
		//-------------------------------------------------------------------------
		AddNpc(20025, "Charge RP", "d_thorn_19", 770.84, 2572.05, 90, "THORN19_RECHARGE2");
		
		// Charge RP
		//-------------------------------------------------------------------------
		AddNpc(20025, "Charge RP", "d_thorn_19", 359.2, 2768.04, 90, "THORN19_RECHARGE3");
		
		// Charge RP
		//-------------------------------------------------------------------------
		AddNpc(20025, "Charge RP", "d_thorn_19", 801.03, 2390.66, 90, "THORN19_RECHARGE4");
		
		// Beholder Track
		//-------------------------------------------------------------------------
		AddNpc(20026, "Beholder Track", "d_thorn_19", 151.47, -1553.16, 90, "", "THORN19_BLACKMAN_TRACK", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "d_thorn_19", -208.2775, -3814.656, 35, "WARP_D_THORN_19", "STOUP_CAMP", "STOUP_CAMP");
		
		// Believer Adele
		//-------------------------------------------------------------------------
		AddNpc(147397, "Believer Adele", "d_thorn_19", 163.91, -631.96, 90, "THORN19_BELIEVER02");
		
		// Believer Virgis
		//-------------------------------------------------------------------------
		AddNpc(147389, "Believer Virgis", "d_thorn_19", 637.37, 1949.51, 90, "THORN19_BELIEVER03");
		
		// Believer Nojus
		//-------------------------------------------------------------------------
		AddNpc(147389, "Believer Nojus", "d_thorn_19", 2311.37, 535.67, 8, "THORN_BLACKMAN_TRIGGER2");
		
		// Believer Donata
		//-------------------------------------------------------------------------
		AddNpc(20026, "Believer Donata", "d_thorn_19", 1339.91, 2478.56, 6, "", "THORN_BLACKMAN_TRIGGER1", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20026, "", "d_thorn_19", 2089, 83, 90, "", "THORN19_MQ14_2_TRACK", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "d_thorn_19", 1761.78, 1590.11, 180, "TREASUREBOX_LV_D_THORN_19682");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "d_thorn_19", 100.67, -1852.806, 90, "THORN19_GATE01_OPEN");
		
		// JOB_PSYCHOKINESIST3_1_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(20041, "JOB_PSYCHOKINESIST3_1_TRIGGER", "d_thorn_19", -1007.36, -3248.977, 90, "", "JOB_PSYCHOKINESIST3_1_TRIGGER", "");
		
		// Thorn Forest Guild Mission
		//-------------------------------------------------------------------------
		AddNpc(40001, "Thorn Forest Guild Mission", "d_thorn_19", 1466.946, -3231.437, 180, "", "THORN19_TO_GUILDMISSION", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "d_thorn_19", 627, 1910, 0, "TREASUREBOX_LV_D_THORN_19687");
	}
}
