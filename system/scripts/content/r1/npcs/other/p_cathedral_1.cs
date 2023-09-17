//--- Melia Script ----------------------------------------------------------
// Passage of the Recluse
//--- Description -----------------------------------------------------------
// NPCs found in and around Passage of the Recluse.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class PCathedral1NpcScript : GeneralScript
{
	public override void Load()
	{
		// Stele Road
		//-------------------------------------------------------------------------
		AddNpc(40001, "Stele Road", "p_cathedral_1", 61, 363, 180, "", "PCATHEDRAL1_REMAINS37", "");
		
		// Sirdgela Forest
		//-------------------------------------------------------------------------
		AddNpc(40001, "Sirdgela Forest", "p_cathedral_1", -437, -1059, 360, "", "PCATHEDRAL1_THORN20", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "p_cathedral_1", 429.5168, -446.9579, 270, "WARP_P_CATHEDRAL_1", "STOUP_CAMP", "STOUP_CAMP");
		
		// Warning
		//-------------------------------------------------------------------------
		AddNpc(40070, "Warning", "p_cathedral_1", 10.10509, 295.0023, 90, "UPPER_WARNING_P_CATHEDRAL_1");
		
		// [Miko Master]{nl}Hitomiko
		//-------------------------------------------------------------------------
		AddNpc(153173, "[Miko Master]{nl}Hitomiko", "p_cathedral_1", 580.6166, -320.2625, 0, "MIKO_MASTER");
		
		// Divine Spirit
		//-------------------------------------------------------------------------
		AddNpc(151018, "Divine Spirit", "p_cathedral_1", 541.7883, -321.3452, 90, "MIKO_SOUL_SPIRIT");
	}
}
