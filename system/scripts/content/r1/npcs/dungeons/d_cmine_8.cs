//--- Melia Script ----------------------------------------------------------
// Crystal Mine Lot 2 - 1F
//--- Description -----------------------------------------------------------
// NPCs found in and around Crystal Mine Lot 2 - 1F.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DCmine8NpcScript : GeneralScript
{
	public override void Load()
	{
		// Crystal Mine 3F
		//-------------------------------------------------------------------------
		AddNpc(40001, "Crystal Mine 3F", "d_cmine_8", -2956, -328, 251, "", "CMINE_8_CMINE_6", "");
		
		// Crystal Mine Lot 2 - 2F
		//-------------------------------------------------------------------------
		AddNpc(40001, "Crystal Mine Lot 2 - 2F", "d_cmine_8", 972, 1375, 180, "", "WS_CMINE8_CMINE9", "");
		
		// Presences of Mystery
		//-------------------------------------------------------------------------
		AddNpc(20165, "Presences of Mystery", "d_cmine_8", -1376.406, -826.4481, 51, "KLAIPE_HQ_02_NPC");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "d_cmine_8", -1372, -852, 90, "KLAIPE_HQ_01_NPC_D", "KLAIPE_HQ_01_NPC_E");
		
		// Lv3 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147393, "Lv3 Treasure Chest", "d_cmine_8", 2615, 2262, 0, "TREASUREBOX_LV_D_CMINE_81078");
		
		// Crystal Processing Device
		//-------------------------------------------------------------------------
		AddNpc(155000, "Crystal Processing Device", "d_cmine_8", -1455.132, 248.0121, 238, "CRYSTAL_MACHINE");
		
		// Lost bag of Miner
		//-------------------------------------------------------------------------
		AddNpc(47161, "Lost bag of Miner", "d_cmine_8", -2258.282, -393.6159, 68, "D_CMINE_8_BAG");
		
		// Lost bag of Miner
		//-------------------------------------------------------------------------
		AddNpc(47161, "Lost bag of Miner", "d_cmine_8", -1235.447, -1063.333, 68, "D_CMINE_8_BAG");
		
		// Lost bag of Miner
		//-------------------------------------------------------------------------
		AddNpc(47161, "Lost bag of Miner", "d_cmine_8", 281.2496, 172.7688, 68, "D_CMINE_8_BAG");
		
		// Lost bag of Miner
		//-------------------------------------------------------------------------
		AddNpc(47161, "Lost bag of Miner", "d_cmine_8", 1117.186, -80.43308, 68, "D_CMINE_8_BAG");
		
		// Lost bag of Miner
		//-------------------------------------------------------------------------
		AddNpc(47161, "Lost bag of Miner", "d_cmine_8", 1830.758, 1928.846, 68, "D_CMINE_8_BAG");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(40095, "", "d_cmine_8", -1439.498, 889.5071, 90, "D_CMINE_8_JUKEBOX");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(40095, "", "d_cmine_8", -522.6809, 980.5384, 90, "D_CMINE_8_JUKEBOX");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(40095, "", "d_cmine_8", -149.2505, -18.784, 90, "D_CMINE_8_JUKEBOX");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "d_cmine_8", -1590.406, 58.78004, 90, "PARTY_Q_011_CHAMICAL01");
		
		// Special Scent
		//-------------------------------------------------------------------------
		AddNpc(152022, "Special Scent", "d_cmine_8", -1589.046, 60.07848, 90, "PARTY_Q_011_MACHIN01");
		
		// Lv2 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(40030, "Lv2 Treasure Chest", "d_cmine_8", 1805, 1854, 90, "TREASUREBOX_LV_D_CMINE_81109");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "d_cmine_8", 140.29, 191.32, 268, "TREASUREBOX_LV_D_CMINE_8700");
	}
}
