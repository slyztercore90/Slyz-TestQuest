//--- Melia Script ----------------------------------------------------------
// Test Zone
//--- Description -----------------------------------------------------------
// NPCs found in and around Test Zone.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class TestZoneNpcScript : GeneralScript
{
	public override void Load()
	{
		
		// TP Shop
		//-------------------------------------------------------------------------
		AddNpc(20113, "TP Shop", "test_zone", -35, 81, 90, "TEST_TP_SHOP");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20113, "", "test_zone", -40, 126, 90, "TEST_RANK");
		
		// Statue of Goddess Ausrine
		//-------------------------------------------------------------------------
		AddNpc(40130, "Statue of Goddess Ausrine", "test_zone", 38, 190, 90, "SKILLPOINTUP2");
		
		// IMC_Guard
		//-------------------------------------------------------------------------
		AddNpc(20016, "IMC_Guard", "test_zone", -713, -611, 90, "IMC_GUARD");
	}
}
