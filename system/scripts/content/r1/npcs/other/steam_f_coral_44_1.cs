//--- Melia Script ----------------------------------------------------------
// [Event] The Cursed Shore
//--- Description -----------------------------------------------------------
// NPCs found in and around [Event] The Cursed Shore.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class SteamFCoral441NpcScript : GeneralScript
{
	public override void Load()
	{
		// Dispatched Soldier
		//-------------------------------------------------------------------------
		AddNpc(15000, "Dispatched Soldier", "Steam_f_coral_44_1", 84.77685, -322.8113, 5, "EVENT_CURSED_COAST");
		
		// Dispatched Soldier
		//-------------------------------------------------------------------------
		AddNpc(15000, "Dispatched Soldier", "Steam_f_coral_44_1", 190.41, 467.01, 120, "EVENT_CURSED_COAST2");
		
		// Cursed Altar
		//-------------------------------------------------------------------------
		AddNpc(155106, "Cursed Altar", "Steam_f_coral_44_1", 185, 753, 90, "CREATE_CURSED_WHALE");
		
		// Eery Waterfall
		//-------------------------------------------------------------------------
		AddNpc(12082, "Eery Waterfall", "Steam_f_coral_44_1", -1690, 885, 90, "EVENT_CURSED_COAST_WARP2");
	}
}
