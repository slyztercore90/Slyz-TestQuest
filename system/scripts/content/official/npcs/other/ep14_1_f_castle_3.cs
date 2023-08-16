//--- Melia Script ----------------------------------------------------------
// Delmore Outskirts
//--- Description -----------------------------------------------------------
// NPCs found in and around Delmore Outskirts.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class Ep141FCastle3NpcScript : GeneralScript
{
	public override void Load()
	{
		// 
		//-------------------------------------------------------------------------
		AddNpc(1, 154120, "", "ep14_1_f_castle_3", 270.6861, 0.7452213, -1652.222, 100, "EP14_1_FCASTLE3_MQ_1_NPC1", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(2, 147469, " ", "ep14_1_f_castle_3", 434.685, 0.7454457, -1379.625, 90, "", "EP14_1_FCASTLE3_MQ_1_HIDDEN", "");
		
		// Blickferret's Track
		//-------------------------------------------------------------------------
		AddNpc(9, 150283, "Blickferret's Track", "ep14_1_f_castle_3", -692.7269, 93.17522, -357.0325, 90, "EP14_1_FCASTLE3_MQ_3_TRACE", "", "");
		
		// Blickferret's Tent
		//-------------------------------------------------------------------------
		AddNpc(19, 150284, "Blickferret's Tent", "ep14_1_f_castle_3", -1608.77, 93.07763, 521.9925, -37, "EP14_1_FCASTLE3_MQ_4_TENT1", "", "");
		
		// Blickferret's Tent
		//-------------------------------------------------------------------------
		AddNpc(20, 150284, "Blickferret's Tent", "ep14_1_f_castle_3", -1770.584, 93.07774, 882.8959, -5, "EP14_1_FCASTLE3_MQ_4_TENT2", "", "");
		
		// Blickferret's Tent
		//-------------------------------------------------------------------------
		AddNpc(21, 150284, "Blickferret's Tent", "ep14_1_f_castle_3", -1940.134, 93.07764, 406.2884, 41, "EP14_1_FCASTLE3_MQ_4_TENT3", "", "");
		
		// Blickferret's Tent
		//-------------------------------------------------------------------------
		AddNpc(22, 150284, "Blickferret's Tent", "ep14_1_f_castle_3", -2001.458, 93.07764, 695.5047, 60, "EP14_1_FCASTLE3_MQ_4_TENT4", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(23, 147469, " ", "ep14_1_f_castle_3", -2043.173, 93.07769, 1031.839, 90, "", "EP14_1_FCASTLE3_MQ_5_HIDDEN", "");
		AddNpc(24, 150274, " ", "ep14_1_f_castle_3", -1996.968, 93.07767, 945.0352, 42, "", "", "");
		
		// Royal Army's Supply Soldier
		//-------------------------------------------------------------------------
		AddNpc(25, 150219, "Royal Army's Supply Soldier", "ep14_1_f_castle_3", -2037.579, 93.07767, 974.8214, 44, "", "EP14_1_FCASTLE3_MQ_5_SOLDIER1", "");
		
		// Royal Army's Supply Soldier
		//-------------------------------------------------------------------------
		AddNpc(26, 150219, "Royal Army's Supply Soldier", "ep14_1_f_castle_3", -1994, 93.07769, 1054, 78, "", "EP14_1_FCASTLE3_MQ_5_SOLDIER1", "");
		
		// Lemprasa Pond
		//-------------------------------------------------------------------------
		AddNpc(27, 40001, "Lemprasa Pond", "ep14_1_f_castle_3", -2068.512, 93.0777, 1043.251, 256, "", "WARP_EP14_1_F_CASTLE_3_TO_EP13_F_SIAULIAI_1", "");
		
		// Blickferret's Tent
		//-------------------------------------------------------------------------
		AddNpc(47, 150296, "Blickferret's Tent", "ep14_1_f_castle_3", 14.91722, 369.5756, 630.6003, 83, "EP14_1_FCASTLE3_MQ_7_TENT1", "", "");
		
		// Blickferret's Tent
		//-------------------------------------------------------------------------
		AddNpc(48, 150296, "Blickferret's Tent", "ep14_1_f_castle_3", 9.193981, 369.5756, 730.0893, 83, "EP14_1_FCASTLE3_MQ_7_TENT2", "", "");
		
		// Blickferret's Tent
		//-------------------------------------------------------------------------
		AddNpc(49, 150296, "Blickferret's Tent", "ep14_1_f_castle_3", 56.89164, 369.5756, 830.3154, 34, "EP14_1_FCASTLE3_MQ_7_TENT3", "", "");
		
		// Blickferret's Tent
		//-------------------------------------------------------------------------
		AddNpc(50, 150296, "Blickferret's Tent", "ep14_1_f_castle_3", 339.8229, 369.5756, 779.6075, -27, "EP14_1_FCASTLE3_MQ_7_TENT4", "", "");
		
		// Blickferret's Tent
		//-------------------------------------------------------------------------
		AddNpc(51, 150296, "Blickferret's Tent", "ep14_1_f_castle_3", 341.0749, 369.5756, 477.8947, 67, "EP14_1_FCASTLE3_MQ_7_TENT5", "", "");
		
		// Blickferret's Tent
		//-------------------------------------------------------------------------
		AddNpc(52, 150296, "Blickferret's Tent", "ep14_1_f_castle_3", 144.4793, 369.5756, 884.107, 21, "EP14_1_FCASTLE3_MQ_7_TENT6", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(65, 147469, " ", "ep14_1_f_castle_3", 353.98, 438.6821, 1288.063, 90, "", "EP14_1_FCASTLE3_MQ_8_HIDDEN", "");
		
		// Delmore Manor
		//-------------------------------------------------------------------------
		AddNpc(66, 40001, "Delmore Manor", "ep14_1_f_castle_3", 240.8775, 0.745302, -1763.283, -43, "", "WARP_EP14_1_F_CASTLE_3_TO_EP14_1_F_CASTLE_2", "");
		
		// Delmore Citadel
		//-------------------------------------------------------------------------
		AddNpc(67, 40001, "Delmore Citadel", "ep14_1_f_castle_3", 1134.802, 332.7553, 315.485, 189, "", "WARP_EP14_1_F_CASTLE_3_TO_EP14_1_F_CASTLE_4", "");
	}
}
