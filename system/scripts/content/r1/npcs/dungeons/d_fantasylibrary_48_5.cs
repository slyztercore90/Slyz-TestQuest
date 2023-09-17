//--- Melia Script ----------------------------------------------------------
// Valandis Room 91
//--- Description -----------------------------------------------------------
// NPCs found in and around Valandis Room 91.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DFantasylibrary485NpcScript : GeneralScript
{
	public override void Load()
	{
		// Valandis Room 3
		//-------------------------------------------------------------------------
		AddNpc(154069, "Valandis Room 3", "d_fantasylibrary_48_5", -2031.81, -973.6965, 90, "FLIBRARY485_TO_FLIBRARY484");
		
		// Neringa
		//-------------------------------------------------------------------------
		AddNpc(154102, "Neringa", "d_fantasylibrary_48_5", -2079.023, -994.3223, 90, "FLIBRARY485_NERINGA_FLLW_NPC");
		
		// Neringa
		//-------------------------------------------------------------------------
		AddNpc(154102, "Neringa", "d_fantasylibrary_48_5", 875.9861, -383.5553, 181, "FLIBRARY485_NERINGA_NPC_1");
		
		// Neringa
		//-------------------------------------------------------------------------
		AddNpc(154102, "Neringa", "d_fantasylibrary_48_5", 926.457, 717.7445, 90, "FLIBRARY485_NERINGA_NPC_2");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "d_fantasylibrary_48_5", -1457.461, -766.5001, 90, "", "FANTASYLIB485_MQ_1_NPC", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "d_fantasylibrary_48_5", -1455.624, -24.64447, 90, "", "FANTASYLIB485_MQ_2_NPC", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "d_fantasylibrary_48_5", 57.47133, 225.7426, 90, "", "FANTASYLIB485_MQ_4_NPC", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154103, " ", "d_fantasylibrary_48_5", 891.34, 1485.698, 47, "", "FANTASYLIB485_MQ_6_BOOKS", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154103, " ", "d_fantasylibrary_48_5", 928.7161, 1503.457, 3, "", "FANTASYLIB485_MQ_6_BOOKS", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154103, " ", "d_fantasylibrary_48_5", 969.5424, 1496.473, -26, "", "FANTASYLIB485_MQ_6_BOOKS", "");
		
		// Abandoned Book
		//-------------------------------------------------------------------------
		AddNpc(151131, "Abandoned Book", "d_fantasylibrary_48_5", -1606.857, -222.3498, 90, "FLIBRARY485_BOOKLIST_1_NPC");
		
		// Abandoned Book
		//-------------------------------------------------------------------------
		AddNpc(151131, "Abandoned Book", "d_fantasylibrary_48_5", -817.4594, -821.2012, 90, "FLIBRARY485_BOOKLIST_2_NPC");
		
		// Abandoned Book
		//-------------------------------------------------------------------------
		AddNpc(151132, "Abandoned Book", "d_fantasylibrary_48_5", 526.7537, 1344.767, 90, "FLIBRARY485_BOOKLIST_3_NPC");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "d_fantasylibrary_48_5", 924.7238, 1096.633, 90, "", "FANTASYLIB485_MQ_6_NPC", "");
		
		// Central Corridor of Scriptorium
		//-------------------------------------------------------------------------
		AddNpc(154069, "Central Corridor of Scriptorium", "d_fantasylibrary_48_5", -863.3888, -498.364, 90, "SECRET_ROOM_TO_FL485");
	}
}
