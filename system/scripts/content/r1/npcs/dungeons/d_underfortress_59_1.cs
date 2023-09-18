//--- Melia Script ----------------------------------------------------------
// Royal Mausoleum Workers Lodge
//--- Description -----------------------------------------------------------
// NPCs found in and around Royal Mausoleum Workers Lodge.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DUnderfortress591NpcScript : GeneralScript
{
	public override void Load()
	{
		// Tiltas Valley
		//-------------------------------------------------------------------------
		AddNpc(40001, "Tiltas Valley", "d_underfortress_59_1", -90.56654, -478.4176, 270, "", "UNDERF591_TO_ROKAS28", "");
		
		// Royal Mausoleum Constructors' Chapel
		//-------------------------------------------------------------------------
		AddNpc(40001, "Royal Mausoleum Constructors' Chapel", "d_underfortress_59_1", 626.9723, 481.9314, 180, "", "UNDERF591_TO_UNDERF592", "");
		
		// Evil Energy Purifier
		//-------------------------------------------------------------------------
		AddNpc(154007, "Evil Energy Purifier", "d_underfortress_59_1", 857.0598, 1107.961, 1, "UNDERF591_TYPEB_OBJ");
		
		// Eviction Order
		//-------------------------------------------------------------------------
		AddNpc(147312, "Eviction Order", "d_underfortress_59_1", -81.6588, -53.02641, 90, "ROKAS_MEMO01_NPC");
		
		// Lantern
		//-------------------------------------------------------------------------
		AddNpc(47253, "Lantern", "d_underfortress_59_1", -507.6955, -1407.308, 0, "FD_UNDERF591_TYPED_LAMP_01");
		
		// Lantern
		//-------------------------------------------------------------------------
		AddNpc(47253, "Lantern", "d_underfortress_59_1", -1061.69, -1422.807, 0, "FD_UNDERF591_TYPED_LAMP_01");
		
		// Lantern
		//-------------------------------------------------------------------------
		AddNpc(47253, "Lantern", "d_underfortress_59_1", -1057.27, -817.8938, 0, "FD_UNDERF591_TYPED_LAMP_01");
		
		// Lantern
		//-------------------------------------------------------------------------
		AddNpc(47253, "Lantern", "d_underfortress_59_1", -478.0948, -813.058, 0, "FD_UNDERF591_TYPED_LAMP_01");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "d_underfortress_59_1", 59, -1362, 90, "TREASUREBOX_LV_D_UNDERFORTRESS_59_138");
		
		// JOB_MIKO_6_1_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(20026, "JOB_MIKO_6_1_TRIGGER", "d_underfortress_59_1", -951.0374, 1427.649, 90, "JOB_MIKO_6_1_UNDER_59_1");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "d_underfortress_59_1", -225.6708, 1663.541, 90, "", "EXPLORER_MISLE38", "");
	}
}
