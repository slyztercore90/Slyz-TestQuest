//--- Melia Script ----------------------------------------------------------
// Mesafasla
//--- Description -----------------------------------------------------------
// NPCs found in and around Mesafasla.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FTableland281NpcScript : GeneralScript
{
	public override void Load()
	{
		// Svalphinghas Forest
		//-------------------------------------------------------------------------
		AddNpc(40001, "Svalphinghas Forest", "f_tableland_28_1", -844.8796, 1762.178, 177, "", "TABLELAND281_TO_MAPLE252", "");
		
		// Stogas Plateau
		//-------------------------------------------------------------------------
		AddNpc(40001, "Stogas Plateau", "f_tableland_28_1", -2888.828, 711.914, 32, "", "TABLELAND281_TO_TABLELAND282", "");
		
		// Mesafasla Assistant Commander Gomen
		//-------------------------------------------------------------------------
		AddNpc(20107, "Mesafasla Assistant Commander Gomen", "f_tableland_28_1", 522.2598, -695.1397, 90, "TABLELAND281_SQ_01");
		
		// Mercenary Higgs
		//-------------------------------------------------------------------------
		AddNpc(20019, "Mercenary Higgs", "f_tableland_28_1", 2256.01, 124.57, 47, "TABLELAND281_SQ_02");
		
		// Soldier Baskez
		//-------------------------------------------------------------------------
		AddNpc(20019, "Soldier Baskez", "f_tableland_28_1", 579.9379, -544.0306, 39, "TABLELAND281_SQ_06");
		
		// Mercenary Higgs
		//-------------------------------------------------------------------------
		AddNpc(20019, "Mercenary Higgs", "f_tableland_28_1", 617.9374, -540.2632, -15, "TABLELAND281_SQ_08");
		
		// Romuva Magic Circle Orb
		//-------------------------------------------------------------------------
		AddNpc(151058, "Romuva Magic Circle Orb", "f_tableland_28_1", 1719.954, 876.0024, 45, "TABLELAND281_SQ_04");
		
		// Neres Magic Circle Orb
		//-------------------------------------------------------------------------
		AddNpc(151058, "Neres Magic Circle Orb", "f_tableland_28_1", -1577.384, -1.928616, 45, "", "TABLELAND281_SQ_05", "");
		
		// UnVisibleName
		//-------------------------------------------------------------------------
		AddNpc(155056, "UnVisibleName", "f_tableland_28_1", -3010.533, 1151.311, 90, "TABLELAND281_SQ_08_STONE");
		
		// UnVisibleName
		//-------------------------------------------------------------------------
		AddNpc(155056, "UnVisibleName", "f_tableland_28_1", -3073.276, 1142.548, 7, "TABLELAND281_SQ_08_STONE");
		
		// UnVisibleName
		//-------------------------------------------------------------------------
		AddNpc(155056, "UnVisibleName", "f_tableland_28_1", -2954.473, 1039.493, 196, "TABLELAND281_SQ_08_STONE");
		
		// UnVisibleName
		//-------------------------------------------------------------------------
		AddNpc(155056, "UnVisibleName", "f_tableland_28_1", -3020.959, 973.7193, -17, "TABLELAND281_SQ_08_STONE");
		
		// UnVisibleName
		//-------------------------------------------------------------------------
		AddNpc(155056, "UnVisibleName", "f_tableland_28_1", -3087.349, 963.5643, 82, "TABLELAND281_SQ_08_STONE");
		
		// UnVisibleName
		//-------------------------------------------------------------------------
		AddNpc(155056, "UnVisibleName", "f_tableland_28_1", -3139.323, 888.3894, 90, "TABLELAND281_SQ_08_STONE");
		
		// UnVisibleName
		//-------------------------------------------------------------------------
		AddNpc(155056, "UnVisibleName", "f_tableland_28_1", -3128.49, 728.0432, 90, "TABLELAND281_SQ_08_STONE");
		
		// UnVisibleName
		//-------------------------------------------------------------------------
		AddNpc(155056, "UnVisibleName", "f_tableland_28_1", -3228.785, 710.4821, 248, "TABLELAND281_SQ_08_STONE");
		
		// UnVisibleName
		//-------------------------------------------------------------------------
		AddNpc(155056, "UnVisibleName", "f_tableland_28_1", -3193.815, 808.7271, 90, "TABLELAND281_SQ_08_STONE");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20026, "", "f_tableland_28_1", 565.3818, -659.5392, 90, "", "TABLELAND281_SQ_02_T", "");
		
		// UnVisibleName
		//-------------------------------------------------------------------------
		AddNpc(46011, "UnVisibleName", "f_tableland_28_1", 599.7849, -564.7748, 90, "", "TABLELAND281_SQ_08_F", "");
		
		// [Shinobi Master]{nl}Yura Swanjone
		//-------------------------------------------------------------------------
		AddNpc(151075, "[Shinobi Master]{nl}Yura Swanjone", "f_tableland_28_1", -214.5343, -662.1505, 90, "SHINOBI_MASTER");
		
		// Shinobi Master Trigger
		//-------------------------------------------------------------------------
		AddNpc(20026, "Shinobi Master Trigger", "f_tableland_28_1", -214.5343, -662.1505, 90, "", "SHINOBI_MASTER_UNHIDE_TRIGGER", "");
		
		// Vedas Plateau
		//-------------------------------------------------------------------------
		AddNpc(40001, "Vedas Plateau", "f_tableland_28_1", 549.7599, -861.6209, -11, "", "TABLELAND28_1_TABLELAND11_1", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "f_tableland_28_1", -3183.61, 1135.78, 90, "TREASUREBOX_LV_F_TABLELAND_28_11000");
	}
}
