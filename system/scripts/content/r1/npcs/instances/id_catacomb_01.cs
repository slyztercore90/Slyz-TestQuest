//--- Melia Script ----------------------------------------------------------
// Guards Graveyard
//--- Description -----------------------------------------------------------
// NPCs found in and around Guards Graveyard.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class IdCatacomb01NpcScript : GeneralScript
{
	public override void Load()
	{
		// Inner Catacombs
		//-------------------------------------------------------------------------
		AddNpc(40001, "Inner Catacombs", "id_catacomb_01", -250, -134, 179, "", "WS_CATACOMB01_1_CATACOMB01_2", "");
		
		// Catacombs Outskirts
		//-------------------------------------------------------------------------
		AddNpc(40001, "Catacombs Outskirts", "id_catacomb_01", -260, 478, 0, "", "WS_CATACOMB01_2_CATACOMB01_1", "");
		
		// Blurred Astral Body
		//-------------------------------------------------------------------------
		AddNpc(147469, "Blurred Astral Body", "id_catacomb_01", -229.1274, -2565.841, 90, "CATACOMB_01_SPIRIT_01");
		
		// Blurred Astral Body
		//-------------------------------------------------------------------------
		AddNpc(147469, "Blurred Astral Body", "id_catacomb_01", -142.8405, -1030.828, 90, "CATACOMB_01_SPIRIT_01");
		
		// Statue guiding the soul
		//-------------------------------------------------------------------------
		AddNpc(20135, "Statue guiding the soul", "id_catacomb_01", 1658.325, -621.8292, 0, "", "CATACOMB_01_SPIRIT_02", "");
		
		// Blurred Box
		//-------------------------------------------------------------------------
		AddNpc(147392, "Blurred Box", "id_catacomb_01", -217.5575, -1804.256, 45, "CATACOMB_01_SPIRIT_03");
		
		// Bleak Shadow
		//-------------------------------------------------------------------------
		AddNpc(20026, "Bleak Shadow", "id_catacomb_01", -535.9864, 867.0446, 90, "", "CATACOMB_01_EVILAURA_01", "");
		
		// Bleak Shadow
		//-------------------------------------------------------------------------
		AddNpc(20026, "Bleak Shadow", "id_catacomb_01", -470.9926, 1145.751, 90, "", "CATACOMB_01_EVILAURA_01", "");
		
		// Bleak Shadow
		//-------------------------------------------------------------------------
		AddNpc(20026, "Bleak Shadow", "id_catacomb_01", -525.5616, 1413.986, 90, "", "CATACOMB_01_EVILAURA_01", "");
		
		// Bleak Shadow
		//-------------------------------------------------------------------------
		AddNpc(20026, "Bleak Shadow", "id_catacomb_01", -235.3258, 826.0167, 90, "", "CATACOMB_01_EVILAURA_01", "");
		
		// Bleak Shadow
		//-------------------------------------------------------------------------
		AddNpc(20026, "Bleak Shadow", "id_catacomb_01", -225.3825, 1121.134, 90, "", "CATACOMB_01_EVILAURA_01", "");
		
		// Bleak Shadow
		//-------------------------------------------------------------------------
		AddNpc(20026, "Bleak Shadow", "id_catacomb_01", -216.222, 1359.507, 90, "", "CATACOMB_01_EVILAURA_01", "");
		
		// Bleak Shadow
		//-------------------------------------------------------------------------
		AddNpc(20026, "Bleak Shadow", "id_catacomb_01", 44.46272, 866.0585, 90, "", "CATACOMB_01_EVILAURA_01", "");
		
		// Bleak Shadow
		//-------------------------------------------------------------------------
		AddNpc(20026, "Bleak Shadow", "id_catacomb_01", 47.69323, 1128.774, 90, "", "CATACOMB_01_EVILAURA_01", "");
		
		// Bleak Shadow
		//-------------------------------------------------------------------------
		AddNpc(20026, "Bleak Shadow", "id_catacomb_01", 79.6908, 1415.757, 90, "", "CATACOMB_01_EVILAURA_01", "");
		
		// Tenet Garden
		//-------------------------------------------------------------------------
		AddNpc(40001, "Tenet Garden", "id_catacomb_01", -247.2492, -3548.954, 0, "", "CATACOMB_01_TO_GELE_57_4", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "id_catacomb_01", 1344.74, -1033.726, 90, "WARP_ID_CATACOMB_01", "STOUP_CAMP", "STOUP_CAMP");
		
		// Watcher's Epitaph
		//-------------------------------------------------------------------------
		AddNpc(152009, "Watcher's Epitaph", "id_catacomb_01", 1611.627, -955.1895, 0, "CATACOMB_01_TOMBSTONE_01");
		
		// Watcher's Epitaph
		//-------------------------------------------------------------------------
		AddNpc(152009, "Watcher's Epitaph", "id_catacomb_01", -641.7699, -615.2181, 0, "CATACOMB_01_TOMBSTONE_02");
		
		// Watcher's Epitaph
		//-------------------------------------------------------------------------
		AddNpc(147463, "Watcher's Epitaph", "id_catacomb_01", 995.5764, 2860.073, 90, "CATACOMB_01_TOMBSTONE_03");
		
		// Notice
		//-------------------------------------------------------------------------
		AddNpc(40070, "Notice", "id_catacomb_01", -174.0962, -2942.402, 45, "CATACOMB_01_BOARD_01");
		
		// Watcher's Epitaph
		//-------------------------------------------------------------------------
		AddNpc(147463, "Watcher's Epitaph", "id_catacomb_01", 99.65654, 1985.888, 90, "CATACOMB_01_TOMBSTONE_04");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "id_catacomb_01", 180.11, -523.76, 90, "TREASUREBOX_LV_ID_CATACOMB_01700");
		
		// Old Diary
		//-------------------------------------------------------------------------
		AddNpc(147311, "Old Diary", "id_catacomb_01", -571.3657, -1099.73, 28, "LOWLV_MASTER_ENCY_SQ_30_BOOK");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "id_catacomb_01", 923.4175, 3010.379, 90, "", "LOWLV_MASTER_ENCY_SQ_40", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "id_catacomb_01", 240.4168, 2901.987, 90, "", "EXPLORER_MISLE9", "");
		
		// Binding Orb
		//-------------------------------------------------------------------------
		AddNpc(147357, "Binding Orb", "id_catacomb_01", -61, -2364, 55, "EXORCIST_JOB_QUEST_OBJ_START");
		
		// Exorcism Site
		//-------------------------------------------------------------------------
		AddNpc(155099, "Exorcism Site", "id_catacomb_01", -91.86, -2376.17, 90, "", "EXORCIST_PLACE_HIDE", "");
	}
}
