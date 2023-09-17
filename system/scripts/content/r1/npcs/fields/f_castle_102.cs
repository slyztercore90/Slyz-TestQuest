//--- Melia Script ----------------------------------------------------------
// Skalda Outskirts
//--- Description -----------------------------------------------------------
// NPCs found in and around Skalda Outskirts.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FCastle102NpcScript : GeneralScript
{
	public override void Load()
	{
		// Rinksmas Ruins
		//-------------------------------------------------------------------------
		AddNpc(40001, "Rinksmas Ruins", "f_castle_102", -3141.893, 277.3966, 260, "", "WARP_CASTLE102_TO_DCAPITAL53_1", "");
		
		// Tvirtumas Fortress
		//-------------------------------------------------------------------------
		AddNpc(40001, "Tvirtumas Fortress", "f_castle_102", -1473.447, -1715.916, 0, "", "WARP_CASTLE102_TO_CASTLE99", "");
		
		// Goddess Austeja
		//-------------------------------------------------------------------------
		AddNpc(151041, "Goddess Austeja", "f_castle_102", -1506, -1612, 45, "CASTLE102_AUSTEJA_01");
		
		// Laima's Wheel
		//-------------------------------------------------------------------------
		AddNpc(150215, "Laima's Wheel", "f_castle_102", -1090.85, 669.7462, 0, "CASTLE102_RAIMA_WHEEL");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "f_castle_102", -966.3862, 710.7999, 90, "", "EXPLORER_MISLE36", "");
	}
}
