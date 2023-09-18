//--- Melia Script ----------------------------------------------------------
// Tenet Church B1
//--- Description -----------------------------------------------------------
// NPCs found in and around Tenet Church B1.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DChapel575NpcScript : GeneralScript
{
	public override void Load()
	{
		// Tenet Garden
		//-------------------------------------------------------------------------
		AddNpc(40001, "Tenet Garden", "d_chapel_57_5", -1258, 1163, 180, "", "CHAPEL575_GELE574", "");
		
		// Tenet Church 1F
		//-------------------------------------------------------------------------
		AddNpc(40001, "Tenet Church 1F", "d_chapel_57_5", 627, -565, 180, "", "CHAPEL575_CHAPEL576", "");
		
		// Follower Tomas
		//-------------------------------------------------------------------------
		AddNpc(147399, "Follower Tomas", "d_chapel_57_5", -489, 618, 0, "CHAPEL_TOMAS");
		
		// Follower Tiberius
		//-------------------------------------------------------------------------
		AddNpc(147400, "Follower Tiberius", "d_chapel_57_5", 140.07, 588.18, 0, "CHAPEL_TABERIJUS");
		
		// Follower Vaidas
		//-------------------------------------------------------------------------
		AddNpc(147400, "Follower Vaidas", "d_chapel_57_5", -359.66, -94.15, 34, "CHAPEL_VIDAS");
		
		// Underground Central Altar
		//-------------------------------------------------------------------------
		AddNpc(147358, "Underground Central Altar", "d_chapel_57_5", -600, 422, 45, "", "CHAPEL575_BASIC_1", "CHAPEL575_BASIC_1");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(147456, "", "d_chapel_57_5", -572, 418, 90, "", "CHAPLE575_MQ_04", "");
		
		// Demon Army Barrier
		//-------------------------------------------------------------------------
		AddNpc(40071, "Demon Army Barrier", "d_chapel_57_5", 363, -782, 90, "CHAPLE575_MQ_09");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "d_chapel_57_5", -1429.68, 1033.58, 76, "WARP_D_CHAPEL_57_5", "STOUP_CAMP", "STOUP_CAMP");
		
		// Altar of Purification
		//-------------------------------------------------------------------------
		AddNpc(147357, "Altar of Purification", "d_chapel_57_5", 439.29, -108.8, 45, "CHAPLE575_MQ_05");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "d_chapel_57_5", 814.34, -988.18, 90, "TREASUREBOX_LV_D_CHAPEL_57_533");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "d_chapel_57_5", -1036.696, -166.6513, 90, "", "EXPLORER_MISLE6", "");
	}
}
