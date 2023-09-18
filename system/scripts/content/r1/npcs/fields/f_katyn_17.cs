//--- Melia Script ----------------------------------------------------------
// Bladelight Basin
//--- Description -----------------------------------------------------------
// NPCs found in and around Bladelight Basin.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FKatyn17NpcScript : GeneralScript
{
	public override void Load()
	{
		// Woods of the Linked Bridges
		//-------------------------------------------------------------------------
		AddNpc(40001, "Woods of the Linked Bridges", "f_katyn_17", 1988, -4112, 360, "", "KATYN17_SIAUL15", "");
		
		// Zachariel Crossroads
		//-------------------------------------------------------------------------
		AddNpc(40001, "Zachariel Crossroads", "f_katyn_17", -3653, 441, 360, "", "KATYN17_ROKAS31", "");
		
		// Rukas Plateau
		//-------------------------------------------------------------------------
		AddNpc(40001, "Rukas Plateau", "f_katyn_17", 421, -678, 90, "", "KATYN17_ROKAS29", "");
		
		// Stele Road
		//-------------------------------------------------------------------------
		AddNpc(40001, "Stele Road", "f_katyn_17", -2400, 410, 270, "", "KATYN17_REMAINS37", "");
	}
}
