//--- Melia Script ----------------------------------------------------------
// Laima's Sanctuary
//--- Description -----------------------------------------------------------
// NPCs found in and around Laima's Sanctuary.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class CKlaipeCathedralMediumNpcScript : GeneralScript
{
	public override void Load()
	{
		// Laima
		//-------------------------------------------------------------------------
		AddNpc(47236, "Laima", "c_klaipe_cathedral_medium", 46.24644, 13.83598, 90, "NPC_LITTLEGIRL_01");
		
		// Mulia
		//-------------------------------------------------------------------------
		AddNpc(150238, "Mulia", "c_klaipe_cathedral_medium", 43.72981, -19.68866, 90, "NPC_RANGDAGIRL_02");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "c_klaipe_cathedral_medium", 441.8155, 290.5834, 49, "WARP_C_KLAIPE_CATHEDRAL_MEDIUM", "STOUP_CAMP", "STOUP_CAMP");
		
		// Goddess Lada
		//-------------------------------------------------------------------------
		AddNpc(156043, "Goddess Lada", "c_klaipe_cathedral_medium", 12.21679, 163.2583, 80, "EP13_GODDESS_LADA4TO5");
		
		// Goddess Lada
		//-------------------------------------------------------------------------
		AddNpc(156043, "Goddess Lada", "c_klaipe_cathedral_medium", 12.21679, 163.2583, 80, "GODDESS_LADA_1");
	}
}
