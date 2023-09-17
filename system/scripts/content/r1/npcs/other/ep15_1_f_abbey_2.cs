//--- Melia Script ----------------------------------------------------------
// Novaha Library
//--- Description -----------------------------------------------------------
// NPCs found in and around Novaha Library.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class Ep151FAbbey2NpcScript : GeneralScript
{
	public override void Load()
	{
		// Novaha Institute
		//-------------------------------------------------------------------------
		AddNpc(40001, "Novaha Institute", "ep15_1_f_abbey_2", 1137.038, -163.5099, 90, "", "WARP_EP15_1_FABBEY_2_TO_EP15_1_FABBEY_1", "");
		
		// The Confessional
		//-------------------------------------------------------------------------
		AddNpc(40001, "The Confessional", "ep15_1_f_abbey_2", -1508.286, 1726.041, 184, "", "WARP_EP15_1_FABBEY_2_TO_EP15_1_FABBEY_3", "");
		
		// Capsule that contains Devilglove
		//-------------------------------------------------------------------------
		AddNpc(160145, "Capsule that contains Devilglove", "ep15_1_f_abbey_2", -1505.125, 1560.81, -21, "EP15_1_GLOVECUPSULE");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "ep15_1_f_abbey_2", 844.3311, -353.6386, 149, "WARP_EP15_1_F_ABBEY_2", "STOUP_CAMP", "STOUP_CAMP");
		
		// Statue of Goddess Zemyna
		//-------------------------------------------------------------------------
		AddNpc(40110, "Statue of Goddess Zemyna", "ep15_1_f_abbey_2", 400.6598, 1414.301, 90, "EP15_1_FABBEY2_ZEMINA", "EP15_1_FABBEY2_ZEMINA", "EP15_1_FABBEY2_ZEMINA");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "ep15_1_f_abbey_2", 1062.377, -160.6702, 90, "", "EP15_1_F_ABBEY2_1_TRIGGER", "");
		
		// Edmundas
		//-------------------------------------------------------------------------
		AddNpc(160144, "Edmundas", "ep15_1_f_abbey_2", 827.8367, -36.97649, 8, "EP15_1_FABBEY2_AD1");
		
		// Rose
		//-------------------------------------------------------------------------
		AddNpc(153119, "Rose", "ep15_1_f_abbey_2", 874.0349, -37.01439, 15, "EP15_1_FABBEY2_ROZE1");
		
		// Wagon plundered by the Vubbes
		//-------------------------------------------------------------------------
		AddNpc(45104, "Wagon plundered by the Vubbes", "ep15_1_f_abbey_2", 20.08241, -215.048, -15, "EP15_1_F_ABBEY2_2_CART");
		
		// Wagon plundered by the Vubbes
		//-------------------------------------------------------------------------
		AddNpc(45104, "Wagon plundered by the Vubbes", "ep15_1_f_abbey_2", -160.8816, -21.1426, -78, "EP15_1_F_ABBEY2_2_CART");
		
		// Wagon plundered by the Vubbes
		//-------------------------------------------------------------------------
		AddNpc(45104, "Wagon plundered by the Vubbes", "ep15_1_f_abbey_2", -234.4295, -267.0778, 90, "EP15_1_F_ABBEY2_2_CART");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "ep15_1_f_abbey_2", -78.89831, 327.3547, 90, "EP15_1_FABBEY2_MQ4_BOWER01", "EP15_1_F_ABBEY2_4_BOWER");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "ep15_1_f_abbey_2", -104.0543, 582.4238, 90, "EP15_1_FABBEY2_MQ4_BOWER02", "EP15_1_F_ABBEY2_4_BOWER");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "ep15_1_f_abbey_2", -536.9774, 736.9337, 90, "EP15_1_FABBEY2_MQ4_BOWER03", "EP15_1_F_ABBEY2_4_BOWER");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "ep15_1_f_abbey_2", -981.7236, 800.4088, 90, "EP15_1_FABBEY2_MQ4_BOWER04", "EP15_1_F_ABBEY2_4_BOWER");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "ep15_1_f_abbey_2", -1166.074, 1473.391, 90, "", "EP15_1_F_ABBEY2_4_TRIGGER", "");
		
		// Rose
		//-------------------------------------------------------------------------
		AddNpc(153119, "Rose", "ep15_1_f_abbey_2", -1411.57, 1396.621, 90, "EP15_1_FABBEY2_ROZE2");
		
		// Edmundas
		//-------------------------------------------------------------------------
		AddNpc(160144, "Edmundas", "ep15_1_f_abbey_2", -1432.013, 1439.009, 90, "EP15_1_FABBEY2_AD2");
		
		// Wagon plundered by the Vubbes
		//-------------------------------------------------------------------------
		AddNpc(45104, "Wagon plundered by the Vubbes", "ep15_1_f_abbey_2", 10.88443, -75.8432, 262, "EP15_1_F_ABBEY2_2_CART");
		
		// Wagon plundered by the Vubbes
		//-------------------------------------------------------------------------
		AddNpc(45104, "Wagon plundered by the Vubbes", "ep15_1_f_abbey_2", -59.68726, -286.498, -89, "EP15_1_F_ABBEY2_2_CART");
		
		// Isolated scholar
		//-------------------------------------------------------------------------
		AddNpc(155119, "Isolated scholar", "ep15_1_f_abbey_2", -172.8258, -903.258, -7, "EP15_1_ABBEY2_SQ3_NPC");
		
		// Greedy merchantwoman
		//-------------------------------------------------------------------------
		AddNpc(20188, "Greedy merchantwoman", "ep15_1_f_abbey_2", -756.2309, 988.1091, 20, "EP15_1_ABBEY2_SQ1_NPC");
	}
}
