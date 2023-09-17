//--- Melia Script ----------------------------------------------------------
// Sunset Flag Forest
//--- Description -----------------------------------------------------------
// NPCs found in and around Sunset Flag Forest.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DThorn23NpcScript : GeneralScript
{
	public override void Load()
	{
		// Dvasia Peak
		//-------------------------------------------------------------------------
		AddNpc(40001, "Dvasia Peak", "d_thorn_23", -2159, -2969, 252, "", "THORN23_THORN22", "");
		
		// Gateway of the Great King
		//-------------------------------------------------------------------------
		AddNpc(40001, "Gateway of the Great King", "d_thorn_23", 2420, 2163, 163, "", "THORN23_ROKAS24", "");
		
		// Sunset Flag Forest
		//-------------------------------------------------------------------------
		AddNpc(40001, "Sunset Flag Forest", "d_thorn_23", -1528, -1792, 215, "", "THORN23_1_THORN23_2", "");
		
		// Sunset Flag Forest
		//-------------------------------------------------------------------------
		AddNpc(40001, "Sunset Flag Forest", "d_thorn_23", -1631, -1637, 25, "", "THORN23_2_THORN23_1", "");
		
		// Sunset Flag Forest
		//-------------------------------------------------------------------------
		AddNpc(40001, "Sunset Flag Forest", "d_thorn_23", 2295, 937, 144, "", "THORN23_2_THORN23_3", "");
		
		// Sunset Flag Forest
		//-------------------------------------------------------------------------
		AddNpc(40001, "Sunset Flag Forest", "d_thorn_23", 2581, 1036, -83, "", "THORN23_3_THORN23_2", "");
		
		// Soldier Alan
		//-------------------------------------------------------------------------
		AddNpc(20011, "Soldier Alan", "d_thorn_23", -1578.7, -2850.12, 90, "THORN23_ALAN");
		
		// Commander Wallace
		//-------------------------------------------------------------------------
		AddNpc(20107, "Commander Wallace", "d_thorn_23", -1494, -1093, 90, "THORN23_WALLACE");
		
		// Soldier Weiz
		//-------------------------------------------------------------------------
		AddNpc(20013, "Soldier Weiz", "d_thorn_23", -1887.8, 337.47, 90, "THORN23_WISE");
		
		// Old Owl Sculpture
		//-------------------------------------------------------------------------
		AddNpc(48004, "Old Owl Sculpture", "d_thorn_23", 390, 312, -5, "THORN23_OWL2");
		
		// Worrying Owl Sculpture
		//-------------------------------------------------------------------------
		AddNpc(12081, "Worrying Owl Sculpture", "d_thorn_23", 734, -252, -5, "THORN23_OWL3");
		
		// Sleeping Owl Statue
		//-------------------------------------------------------------------------
		AddNpc(153036, "Sleeping Owl Statue", "d_thorn_23", 1345.73, 164.33, -5, "THORN23_OWL4");
		
		// Sleeping Owl Statue
		//-------------------------------------------------------------------------
		AddNpc(153037, "Sleeping Owl Statue", "d_thorn_23", 1428.57, -118.9404, -5, "THORN23_OWL5");
		
		// Sleeping Owl Statue
		//-------------------------------------------------------------------------
		AddNpc(153038, "Sleeping Owl Statue", "d_thorn_23", 1030.352, 38.84108, 16, "THORN23_OWL6");
		
		// Gaigalas Summoning Area
		//-------------------------------------------------------------------------
		AddNpc(20026, "Gaigalas Summoning Area", "d_thorn_23", 2517.447, 1577.391, 90, "", "THORN23_BOSS_TRIGGER", "");
		
		// Useless Report Trigger
		//-------------------------------------------------------------------------
		AddNpc(20041, "Useless Report Trigger", "d_thorn_23", -1916.87, -2346.68, 90, "", "THORN23_Q_4_TRIGGER", "");
		
		// Tomb
		//-------------------------------------------------------------------------
		AddNpc(47170, "Tomb", "d_thorn_23", -833.408, -1295.349, 37, "THORN23_Q_7_TRIGGER");
		
		// Kvailas Forest
		//-------------------------------------------------------------------------
		AddNpc(40001, "Kvailas Forest", "d_thorn_23", -588, 899, 180, "", "THORN23_THORN21", "");
		
		// Firewood
		//-------------------------------------------------------------------------
		AddNpc(47223, "Firewood", "d_thorn_23", -993, 290, 90, "THORN23_FIRETRIGGER", "THORN23_BONFIRE");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "d_thorn_23", -1369.76, -1847.77, 90, "TREASUREBOX_LV_D_THORN_23631");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "d_thorn_23", -1577.77, -2852.41, 90, "", "HT2_THORN23_ALAN_EFFECT", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "d_thorn_23", -1461.79, -2749.7, 90, "", "HT2_THORN23_ALAN_EFFECT", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "d_thorn_23", -1494.42, -1091.03, 90, "", "HT2_THORN23_WALLACE_EFFECT", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "d_thorn_23", -1881.967, 339.897, 90, "", "HT2_THORN23_WISE_EFFECT", "");
	}
}
