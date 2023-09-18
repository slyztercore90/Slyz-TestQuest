//--- Melia Script ----------------------------------------------------------
// Royal Mausoleum Constructors' Chapel
//--- Description -----------------------------------------------------------
// NPCs found in and around Royal Mausoleum Constructors' Chapel.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DUnderfortress592NpcScript : GeneralScript
{
	public override void Load()
	{
		// Royal Mausoleum Storage
		//-------------------------------------------------------------------------
		AddNpc(40001, "Royal Mausoleum Storage", "d_underfortress_59_2", -40.84153, 281.1239, 270, "", "UNDERF592_TO_UNDERF593", "");
		
		// Royal Mausoleum Workers Lodge
		//-------------------------------------------------------------------------
		AddNpc(40001, "Royal Mausoleum Workers Lodge", "d_underfortress_59_2", 456.9549, -386.4884, 93, "", "UNDERF592_TO_UNDERF591", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154001, " ", "d_underfortress_59_2", -954, -928, 90, "", "UNDERF592_TYPEB_GATE_1", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154001, " ", "d_underfortress_59_2", -1059, -692, 180, "", "UNDERF592_TYPEB_GATE_2", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154001, " ", "d_underfortress_59_2", -1058, -239, 180, "", "UNDERF592_TYPEB_GATE_3", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154001, " ", "d_underfortress_59_2", -1059, 187, 180, "", "UNDERF592_TYPEB_GATE_4", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154001, " ", "d_underfortress_59_2", -847, 168, 180, "", "UNDERF592_TYPEB_GATE_5", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154001, " ", "d_underfortress_59_2", -838, -698, 180, "", "UNDERF592_TYPEB_GATE_6", "");
		
		// Chapel Altar
		//-------------------------------------------------------------------------
		AddNpc(147357, "Chapel Altar", "d_underfortress_59_2", -968.345, -1142.851, 45, "UNDERF592_TYPEB_ALTER_1");
		
		// Chapel Altar
		//-------------------------------------------------------------------------
		AddNpc(147357, "Chapel Altar", "d_underfortress_59_2", -1326.646, -717.1221, 45, "UNDERF592_TYPEB_ALTER_2");
		
		// Chapel Altar
		//-------------------------------------------------------------------------
		AddNpc(147357, "Chapel Altar", "d_underfortress_59_2", -1326.666, -227.6213, 45, "UNDERF592_TYPEB_ALTER_3");
		
		// Chapel Altar
		//-------------------------------------------------------------------------
		AddNpc(147357, "Chapel Altar", "d_underfortress_59_2", -1313.609, 171.6777, 45, "UNDERF592_TYPEB_ALTER_4");
		
		// Chapel Altar
		//-------------------------------------------------------------------------
		AddNpc(147357, "Chapel Altar", "d_underfortress_59_2", -623.6964, 191.6919, 45, "UNDERF592_TYPEB_ALTER_5");
		
		// Chapel Altar
		//-------------------------------------------------------------------------
		AddNpc(147357, "Chapel Altar", "d_underfortress_59_2", -601.874, -695.8885, 45, "UNDERF592_TYPEB_ALTER_6");
		
		// Abandoned Altar
		//-------------------------------------------------------------------------
		AddNpc(147417, "Abandoned Altar", "d_underfortress_59_2", -328.7843, 797.9495, 90, "FD_UNDERF592_TYPEA_ALTER");
		
		// Statue of Goddess Zemyna
		//-------------------------------------------------------------------------
		AddNpc(40110, "Statue of Goddess Zemyna", "d_underfortress_59_2", -951.0473, 696.8472, 0, "UNDERF592_ZEMINA_STATUE", "UNDERF592_ZEMINA_STATUE", "UNDERF592_ZEMINA_STATUE");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "d_underfortress_59_2", 449.585, -208.2484, -30, "WARP_D_UNDERFORTRESS_59_2", "STOUP_CAMP", "STOUP_CAMP");
		
		// The Grass of King Zachariel
		//-------------------------------------------------------------------------
		AddNpc(153014, "The Grass of King Zachariel", "d_underfortress_59_2", -555.3775, -319.4533, 90, "ROKAS_MEMO02_NPC");
		
		// Chapel Light Beacon
		//-------------------------------------------------------------------------
		AddNpc(154041, "Chapel Light Beacon", "d_underfortress_59_2", 987.5584, -195.5981, 90, "UNDERF592_TYPEC_DEFENCE_1");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "d_underfortress_59_2", -963, -1128, 90, "TREASUREBOX_LV_D_UNDERFORTRESS_59_245");
	}
}
