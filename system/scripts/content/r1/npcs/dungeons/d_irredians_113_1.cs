//--- Melia Script ----------------------------------------------------------
// Irredian Shelter
//--- Description -----------------------------------------------------------
// NPCs found in and around Irredian Shelter.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DIrredians1131NpcScript : GeneralScript
{
	public override void Load()
	{
		// Spell Tome Town
		//-------------------------------------------------------------------------
		AddNpc(147507, "Spell Tome Town", "d_irredians_113_1", -569.6205, -1383.483, 90, "IRREDIANS1131_TO_NICO813");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "d_irredians_113_1", -517.5229, -981.6158, 54, "WARP_D_IRREDIANS113_1", "STOUP_CAMP", "STOUP_CAMP");
		
		// Portal to Checkpoint
		//-------------------------------------------------------------------------
		AddNpc(154069, "Portal to Checkpoint", "d_irredians_113_1", -4.8335, 261.7278, 90, "IRREDIANS1131_ENTRANCE");
		
		// Exit
		//-------------------------------------------------------------------------
		AddNpc(154069, "Exit", "d_irredians_113_1", 1057.289, -373.9422, 90, "IRREDIANS1131_ESCAPE_EAST");
		
		// Exit
		//-------------------------------------------------------------------------
		AddNpc(154069, "Exit", "d_irredians_113_1", -1102.984, -664.1795, 90, "IRREDIANS1131_ESCAPE_WEST");
		
		// Abandoned Book
		//-------------------------------------------------------------------------
		AddNpc(147311, "Abandoned Book", "d_irredians_113_1", -441.1452, -919.5415, 90, "IRREDIANS1131_BOOK_1_NPC");
		
		// Blackened Diary
		//-------------------------------------------------------------------------
		AddNpc(153014, "Blackened Diary", "d_irredians_113_1", -274.447, 577.2573, 90, "IRREDIANS1131_BOOK_2_NPC");
		
		// Wrinkled Paper
		//-------------------------------------------------------------------------
		AddNpc(151121, "Wrinkled Paper", "d_irredians_113_1", -1044.864, 862.3054, 260, "IRREDIANS1131_BOOK_3_NPC");
		
		// Scribbled Paper
		//-------------------------------------------------------------------------
		AddNpc(151121, "Scribbled Paper", "d_irredians_113_1", 1346.778, 461.4918, 90, "IRREDIANS1131_SCROLL_1_NPC");
		
		// Scribbled Paper
		//-------------------------------------------------------------------------
		AddNpc(151121, "Scribbled Paper", "d_irredians_113_1", -654.9801, 1045.385, 90, "IRREDIANS1131_SCROLL_2_NPC");
		
		// Scribbled Paper
		//-------------------------------------------------------------------------
		AddNpc(151121, "Scribbled Paper", "d_irredians_113_1", -1170.398, -811.7021, 90, "IRREDIANS1131_SCROLL_3_NPC");
		
		// Scribbled Paper
		//-------------------------------------------------------------------------
		AddNpc(151121, "Scribbled Paper", "d_irredians_113_1", 1352.553, -363.1545, 90, "IRREDIANS1131_SCROLL_4_NPC");
		
		// [Portal] Madon Maid
		//-------------------------------------------------------------------------
		AddNpc(154069, "[Portal] Madon Maid", "d_irredians_113_1", -55.85426, -401.3149, 90, "IRREDIAN1131_CLP_NPC");
		
		// [Portal] Amiss Dog
		//-------------------------------------------------------------------------
		AddNpc(154069, "[Portal] Amiss Dog", "d_irredians_113_1", 78.44424, -402.6823, 90, "IRREDIAN1131_CRP_NPC");
		
		// Tel Harsha
		//-------------------------------------------------------------------------
		AddNpc(160030, "Tel Harsha", "d_irredians_113_1", 23.01482, -478.0077, 360, "RAID_TELHARSHA_ENTER");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "d_irredians_113_1", 827.8661, -343.0114, 90, "", "EXPLORER_MISLE16", "");
	}
}
