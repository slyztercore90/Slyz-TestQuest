//--- Melia Script ----------------------------------------------------------
// Seven Valley Mission
//--- Description -----------------------------------------------------------
// NPCs found in and around Seven Valley Mission.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class MissionHuevillage01NpcScript : GeneralScript
{
	public override void Load()
	{
		// Innocent Spirit
		//-------------------------------------------------------------------------
		AddNpc(147407, "Innocent Spirit", "mission_huevillage_01", 0.4355431, 1172.895, 90, "HUEVILLAGE_58_3_HQ01_NPC03");
	}
}
