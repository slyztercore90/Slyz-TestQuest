//--- Melia Script ----------------------------------------------------------
// Earth Tower Lolopanther Area
//--- Description -----------------------------------------------------------
// NPCs found in and around Earth Tower Lolopanther Area.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class MissionGroundtower1NpcScript : GeneralScript
{
	public override void Load()
	{
		
		// Kupole Ruta
		//-------------------------------------------------------------------------
		AddNpc(154013, "Kupole Ruta", "mission_groundtower_1", 3079.993, -6288.347, 68, "GT_LUTHA_NPC");
	}
}
