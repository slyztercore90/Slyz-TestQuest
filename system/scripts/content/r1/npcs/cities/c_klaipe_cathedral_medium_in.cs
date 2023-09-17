//--- Melia Script ----------------------------------------------------------
// Laima's Sanctuary Interior
//--- Description -----------------------------------------------------------
// NPCs found in and around Laima's Sanctuary Interior.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class CKlaipeCathedralMediumInNpcScript : GeneralScript
{
	public override void Load()
	{
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "c_klaipe_cathedral_medium_in", -63.57682, 7.541009, 90, "", "GIVEHOLYTHING_Q_1_TRACK", "");
		
		// Laima's Sanctuary
		//-------------------------------------------------------------------------
		AddNpc(40001, "Laima's Sanctuary", "c_klaipe_cathedral_medium_in", 188.9748, 6.096366, 90, "", "WARP_C_KLAIPE_CATHEDRAL_MEDIUM", "");
	}
}
