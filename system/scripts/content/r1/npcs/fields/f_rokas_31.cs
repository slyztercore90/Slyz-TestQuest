//--- Melia Script ----------------------------------------------------------
// Zachariel Crossroads
//--- Description -----------------------------------------------------------
// NPCs found in and around Zachariel Crossroads.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FRokas31NpcScript : GeneralScript
{
	public override void Load()
	{
		// King's Plateau
		//-------------------------------------------------------------------------
		AddNpc(40001, "King's Plateau", "f_rokas_31", 940, -998, 139, "", "ROKAS31_ROKAS30", "");
		
		// Royal Mausoleum 1F
		//-------------------------------------------------------------------------
		AddNpc(40001, "Royal Mausoleum 1F", "f_rokas_31", -1271, 715, 225, "", "ROKAS31_ZACHARIEL32", "");
		
		// Stele Road
		//-------------------------------------------------------------------------
		AddNpc(40001, "Stele Road", "f_rokas_31", 470, -1399, -49, "", "ROKAS31_REMAINS37", "");
		
		// Rexipher
		//-------------------------------------------------------------------------
		AddNpc(47413, "Rexipher", "f_rokas_31", 656, -1211, 90, "ROKAS31_PACT_END");
		
		// Rexipher
		//-------------------------------------------------------------------------
		AddNpc(47413, "Rexipher", "f_rokas_31", -159.3123, -501.1689, 90, "ROKAS31_REXITHER2");
		
		// REXITHER3
		//-------------------------------------------------------------------------
		AddNpc(20026, "REXITHER3", "f_rokas_31", -1100, 280, 90, "", "ROKAS31_REXITHER3TRACK", "");
		
		// Varkis' Records
		//-------------------------------------------------------------------------
		AddNpc(47192, "Varkis' Records", "f_rokas_31", -1229, 576, 200, "ROKAS31_RECORD");
		
		// Historian Cyrenia Odell
		//-------------------------------------------------------------------------
		AddNpc(147345, "Historian Cyrenia Odell", "f_rokas_31", -127.13, -373.19, 0, "ROKAS31_ODEL2");
		
		// Royal Mausoleum Guardian Device
		//-------------------------------------------------------------------------
		AddNpc(47107, "Royal Mausoleum Guardian Device", "f_rokas_31", 57.36679, -750.577, 90, "ROKAS31_REXITHER1");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "f_rokas_31", -765.7032, -870.5676, 0, "ROKAS31_SUB_01_BOX");
		
		// Powerless Security Guard
		//-------------------------------------------------------------------------
		AddNpc(147410, "Powerless Security Guard", "f_rokas_31", 508.9426, 84.36481, 4, "ROKAS31_SUB");
		
		// Statue of Goddess Zemyna
		//-------------------------------------------------------------------------
		AddNpc(40110, "Statue of Goddess Zemyna", "f_rokas_31", 496, -27, -10, "F_ROKAS_31_EV_55_001", "F_ROKAS_31_EV_55_001", "F_ROKAS_31_EV_55_001");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "f_rokas_31", -736, -1088, 90, "TREASUREBOX_LV_F_ROKAS_31629");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "f_rokas_31", -381.6117, 143.3963, 90, "", "EXPLORER_MISLE30", "");
	}
}
