//--- Melia Script ----------------------------------------------------------
// Tiltas Valley
//--- Description -----------------------------------------------------------
// NPCs found in and around Tiltas Valley.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FRokas28NpcScript : GeneralScript
{
	public override void Load()
	{
		// Broken device
		//-------------------------------------------------------------------------
		AddNpc(147336, "Broken device", "f_rokas_28", -337, 299, 225, "", "ROKAS28_BLOCK", "");
		
		// Akmens Ridge
		//-------------------------------------------------------------------------
		AddNpc(40001, "Akmens Ridge", "f_rokas_28", -717, -1692, -85, "", "ROKAS28_ROKAS27", "");
		
		// Rukas Plateau
		//-------------------------------------------------------------------------
		AddNpc(40001, "Rukas Plateau", "f_rokas_28", -1892, -545, 259, "", "ROKAS28_ROKAS29", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20025, "", "f_rokas_28", -445, 70, 90, "", "ROKAS28_ODEL_TRIGGER", "");
		
		// Trap-setting Area
		//-------------------------------------------------------------------------
		AddNpc(20025, "Trap-setting Area", "f_rokas_28", 651, 466, 90, "ROKAS28_TRAP");
		
		// Stone Pillar
		//-------------------------------------------------------------------------
		AddNpc(47107, "Stone Pillar", "f_rokas_28", 1422, 772, 90, "ROKAS28_ENTICE");
		
		// Liaison Officer Nian
		//-------------------------------------------------------------------------
		AddNpc(20125, "Liaison Officer Nian", "f_rokas_28", -544, -1500, 45, "ROKAS28_MQ1_1", "ROKAS28_MQ1_2");
		
		// Trap-setting Area
		//-------------------------------------------------------------------------
		AddNpc(20025, "Trap-setting Area", "f_rokas_28", 556, 553, 90, "", "ROKAS28_TRAP_2", "");
		
		// Historian Adelle
		//-------------------------------------------------------------------------
		AddNpc(153040, "Historian Adelle", "f_rokas_28", 1616, 1791, 90, "ROKAS28_ODEL_MQ4_DLG");
		
		// Mural
		//-------------------------------------------------------------------------
		AddNpc(20025, "Mural", "f_rokas_28", 1263.86, 1974.244, 90, "ROKAS28_MQ5_NPC");
		
		// Historian Adelle
		//-------------------------------------------------------------------------
		AddNpc(153040, "Historian Adelle", "f_rokas_28", -475, -506, 90, "ROKAS28_ODEL_MQ6");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20025, "", "f_rokas_28", -1318, -480, 90, "", "ROKAS28_MQ7_NPC", "");
		
		// Seal Device
		//-------------------------------------------------------------------------
		AddNpc(47106, "Seal Device", "f_rokas_28", -216, -69, 90, "ROKAS28_SEAL_FAKE1");
		
		// Seal Device
		//-------------------------------------------------------------------------
		AddNpc(47106, "Seal Device", "f_rokas_28", -638, -617, 90, "ROKAS28_SEAL_FAKE2");
		
		// Seal Device
		//-------------------------------------------------------------------------
		AddNpc(47106, "Seal Device", "f_rokas_28", -42, -1502, 90, "ROKAS28_SEAL_FAKE3");
		
		// Seal Device
		//-------------------------------------------------------------------------
		AddNpc(47106, "Seal Device", "f_rokas_28", 733, -446, 90, "ROKAS28_SEAL_FAKE4");
		
		// Seal Device
		//-------------------------------------------------------------------------
		AddNpc(47106, "Seal Device", "f_rokas_28", 777, 724, 90, "ROKAS28_SEAL_FAKE5");
		
		// Seal Device
		//-------------------------------------------------------------------------
		AddNpc(47106, "Seal Device", "f_rokas_28", 1156, 1125, 90, "ROKAS28_SEAL_FAKE6");
		
		// Seal Device
		//-------------------------------------------------------------------------
		AddNpc(47106, "Seal Device", "f_rokas_28", -616, 14, 90, "ROKAS28_SEAL_TRUE2");
		
		// Seal Device
		//-------------------------------------------------------------------------
		AddNpc(47106, "Seal Device", "f_rokas_28", 371, 646, 90, "ROKAS28_SEAL_TRUE3");
		
		// Seal Device
		//-------------------------------------------------------------------------
		AddNpc(47106, "Seal Device", "f_rokas_28", 1650, 1715, 90, "ROKAS28_SEAL_TRUE1");
		
		// Archaeologist Friedka
		//-------------------------------------------------------------------------
		AddNpc(20150, "Archaeologist Friedka", "f_rokas_28", 251, -346, 90, "ROKAS28_FRIDKA");
		
		// Technician Orion
		//-------------------------------------------------------------------------
		AddNpc(20102, "Technician Orion", "f_rokas_28", 501, -177, 90, "ROKAS28_ORION");
		
		// Historian Adelle
		//-------------------------------------------------------------------------
		AddNpc(153040, "Historian Adelle", "f_rokas_28", 16, -571, 90, "ROKAS28_ODEL");
		
		// Royal Mausoleum Workers Lodge
		//-------------------------------------------------------------------------
		AddNpc(40001, "Royal Mausoleum Workers Lodge", "f_rokas_28", 1191.129, 2320.436, 252, "", "ROKAS28_TO_UNDERF591", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "f_rokas_28", 1647.958, 2088.266, 90, "ROKAS28_SECRET_PORTAL");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "f_rokas_28", 630.55, -159.62, 270, "TREASUREBOX_LV_F_ROKAS_281040");
	}
}
