//--- Melia Script ----------------------------------------------------------
// Ruklys Hall of Fame
//--- Description -----------------------------------------------------------
// NPCs found in and around Ruklys Hall of Fame.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DUnderfortress301NpcScript : GeneralScript
{
	public override void Load()
	{
		// Resident Quarter
		//-------------------------------------------------------------------------
		AddNpc(40001, "Resident Quarter", "d_underfortress_30_1", -105.1161, 1942.654, 171, "", "UNDERFORTRESS30_1_UNDERFORTRESS67", "");
		
		// Extension
		//-------------------------------------------------------------------------
		AddNpc(40001, "Extension", "d_underfortress_30_1", 1030.448, -954.5347, 94, "", "UNDERFORTRESS30_1_UNDERFORTRESS30_2", "");
		
		// Unidentified Stone
		//-------------------------------------------------------------------------
		AddNpc(153061, "Unidentified Stone", "d_underfortress_30_1", 492.6606, 516.9103, 90, "UNDER301_HI_LOW");
	}
}
