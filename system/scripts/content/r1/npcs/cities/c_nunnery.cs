//--- Melia Script ----------------------------------------------------------
// Saalus Convent
//--- Description -----------------------------------------------------------
// NPCs found in and around Saalus Convent.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class CNunneryNpcScript : GeneralScript
{
	public override void Load()
	{
		// Pilgrim Path
		//-------------------------------------------------------------------------
		AddNpc(40001, "Pilgrim Path", "c_nunnery", 591, 146, 90, "", "NUNNERY_PILGRIM47", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "c_nunnery", 105, 4, 405, "WARP_C_NUNNERY", "STOUP_CAMP", "STOUP_CAMP");
		
		// Sister Aiste
		//-------------------------------------------------------------------------
		AddNpc(153142, "Sister Aiste", "c_nunnery", 14, -97, 405, "REQUEST_MISSION_ABBEY", "TUTO_SAALUS_NUNNERY_CHECK");
		
		// Sister Lhasa
		//-------------------------------------------------------------------------
		AddNpc(153143, "Sister Lhasa", "c_nunnery", 201, 37, 405, "C_NUNNERY_NPC1", "TUTO_UPHILL_DEFENSE_CHECK");
		
		// [Enchanter Master]{nl}Yena Havindar
		//-------------------------------------------------------------------------
		AddNpc(153170, "[Enchanter Master]{nl}Yena Havindar", "c_nunnery", 320.9502, 282.7521, -13, "ENCHANTER_MASTER");
		
		// Merchant Running from the Petrifying Frost
		//-------------------------------------------------------------------------
		AddNpc(20103, "Merchant Running from the Petrifying Frost", "c_nunnery", 506.4811, -335.4216, 90, "HT_ESCAPE_MERCHANT");
		
		// Jewelry Collector
		//-------------------------------------------------------------------------
		AddNpc(20156, "Jewelry Collector", "c_nunnery", 331.3597, -188.0778, 90, "KEY_QUEST_NPC_NUNNERY");
		
		// [Matross Master]{nl}Pauline
		//-------------------------------------------------------------------------
		AddNpc(154122, "[Matross Master]{nl}Pauline", "c_nunnery", 93.99258, -332.871, 90, "MASTER_MATROSS_NPC");
		
		// [Ardito Master]{nl}Alexa
		//-------------------------------------------------------------------------
		AddNpc(154123, "[Ardito Master]{nl}Alexa", "c_nunnery", 61.31664, -243.516, 90, "MASTER_ARDITI_NPC");
		
		// [Sheriff Master]{nl}Evan
		//-------------------------------------------------------------------------
		AddNpc(154121, "[Sheriff Master]{nl}Evan", "c_nunnery", 288.4222, -277.403, 13, "MASTER_SHERIFF_NPC");
		
		// [Terramancer Master]{nl}Damir Borkan
		//-------------------------------------------------------------------------
		AddNpc(150208, "[Terramancer Master]{nl}Damir Borkan", "c_nunnery", 128.373, 70.88188, 90, "MASTER_TERRAMANCER_NPC");
		
		// [Blossom Blader Master]{nl}May
		//-------------------------------------------------------------------------
		AddNpc(150209, "[Blossom Blader Master]{nl}May", "c_nunnery", 228.7872, 205.5243, 5, "MASTER_BLOSSOMBLADER_NPC");
		
		// [Rangda Master]{nl}Uolios Wahid
		//-------------------------------------------------------------------------
		AddNpc(150212, "[Rangda Master]{nl}Uolios Wahid", "c_nunnery", 376.8413, 181.2377, -15, "MASTER_RANGDA_NPC");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(150216, "", "c_nunnery", 351.9429, 179.2436, 4, "NPC_MIELAS_01");
		
		// Rangda Girl
		//-------------------------------------------------------------------------
		AddNpc(150230, "Rangda Girl", "c_nunnery", 410.6339, 184.2011, -6, "NPC_RANGDAGIRL_01");
		
		// [Luchador Master]{nl}El Volador Mascaras
		//-------------------------------------------------------------------------
		AddNpc(150257, "[Luchador Master]{nl}El Volador Mascaras", "c_nunnery", 143.5258, 169.2488, 40, "MASTER_LUCHADOR_NPC");
		
		// [Lama Master]{nl}Astius
		//-------------------------------------------------------------------------
		AddNpc(160122, "[Lama Master]{nl}Astius", "c_nunnery", 315.0596, 70.646, 81, "MASTER_LAMA_NPC");
		
		// [Shenji Master] Dana
		//-------------------------------------------------------------------------
		AddNpc(160156, "[Shenji Master] Dana", "c_nunnery", 186.9642, 194.7124, 19, "MASTER_SPE_NPC");
	}
}
