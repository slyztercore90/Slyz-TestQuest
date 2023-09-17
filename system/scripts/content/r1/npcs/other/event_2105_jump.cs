//--- Melia Script ----------------------------------------------------------
// TOS Summer Campfire
//--- Description -----------------------------------------------------------
// NPCs found in and around TOS Summer Campfire.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class Event2105JumpNpcScript : GeneralScript
{
	public override void Load()
	{
		
		// [Event]{nl}Check Point 1
		//-------------------------------------------------------------------------
		AddNpc(160078, "[Event]{nl}Check Point 1", "Event_2105_JUMP", -33.93657, 69.69286, 90, "EVENT_2204_CAMPING_JUMP_CHECK_NPC");
		
		// [Event]{nl}Check Point 3
		//-------------------------------------------------------------------------
		AddNpc(160078, "[Event]{nl}Check Point 3", "Event_2105_JUMP", 283.5598, 907.8119, 90, "EVENT_2204_CAMPING_JUMP_CHECK_NPC");
		
		// [Event]{nl}Check Point 2
		//-------------------------------------------------------------------------
		AddNpc(160078, "[Event]{nl}Check Point 2", "Event_2105_JUMP", 1121.474, 743.6895, -90, "EVENT_2204_CAMPING_JUMP_CHECK_NPC");
		
		// [Event]{nl}Check Point 4
		//-------------------------------------------------------------------------
		AddNpc(160078, "[Event]{nl}Check Point 4", "Event_2105_JUMP", -390.5694, 911.08, 90, "EVENT_2204_CAMPING_JUMP_CHECK_NPC");
		
		// [Event] Information Board
		//-------------------------------------------------------------------------
		AddNpc(40090, "[Event] Information Board", "Event_2105_JUMP", 48.40788, -1041.968, 90, "EVENT_2204_CAMPING_JUMP_BOARD_NPC");
		
		// Return to City
		//-------------------------------------------------------------------------
		AddNpc(160065, "Return to City", "Event_2105_JUMP", 48.40788, -1105.968, 90, "EVENT_2204_CAMPING_JUMP_RETURN_NPC");
		
		// [Event]{nl}Hidden Secret Token
		//-------------------------------------------------------------------------
		AddNpc(160125, "[Event]{nl}Hidden Secret Token", "Event_2105_JUMP", 48.40788, -1105.968, 90, "EVENT_2204_CAMPING_JUMP_HIDDEN_NPC");
	}
}
