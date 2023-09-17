//--- Melia Script ----------------------------------------------------------
// Natarh Watchtower
//--- Description -----------------------------------------------------------
// NPCs found in and around Natarh Watchtower.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DStartower761NpcScript : GeneralScript
{
	public override void Load()
	{
		// Dina Bee Farm
		//-------------------------------------------------------------------------
		AddNpc(147507, "Dina Bee Farm", "d_startower_76_1", -1099.635, 778.5563, 90, "STARTOWER_76_1_TO_SIAULIAI_46_4");
		
		// Nazarene Tower
		//-------------------------------------------------------------------------
		AddNpc(147507, "Nazarene Tower", "d_startower_76_1", 2771.767, 249.7847, 90, "D_STARTOWER_76_1_TO_D_STARTOWER_76_2");
	}
}
