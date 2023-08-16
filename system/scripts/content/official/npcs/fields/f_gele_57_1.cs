//--- Melia Script ----------------------------------------------------------
// Srautas Gorge
//--- Description -----------------------------------------------------------
// NPCs found in and around Srautas Gorge.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FGele571NpcScript : GeneralScript
{
	public override void Load()
	{
		// Miners' Village
		//-------------------------------------------------------------------------
		AddNpc(101, 40001, "Miners' Village", "f_gele_57_1", -1662, 168, -1176, 270, "", "GELE571_SIALLAIOUT", "");
		
		// Gele Plateau
		//-------------------------------------------------------------------------
		AddNpc(102, 40001, "Gele Plateau", "f_gele_57_1", 640, 267, 1489, 180, "", "GELE571_GELE572", "");
		
		// Watcher Gilbert
		//-------------------------------------------------------------------------
		AddNpc(104, 147406, "Watcher Gilbert", "f_gele_57_1", -352, 168, -564, 90, "GELE571_NPC_GILBERT", "", "");
		
		// Grass Dummy
		//-------------------------------------------------------------------------
		AddNpc(117, 47204, "Grass Dummy", "f_gele_57_1", -1385.33, 276.34, 683.5, 90, "GELE571_MQ_03", "", "");
		
		// Grass Dummy
		//-------------------------------------------------------------------------
		AddNpc(117, 47204, "Grass Dummy", "f_gele_57_1", -1227.54, 276.34, 118.29, 90, "GELE571_MQ_03", "", "");
		
		// Grass Dummy
		//-------------------------------------------------------------------------
		AddNpc(117, 47204, "Grass Dummy", "f_gele_57_1", -1200.75, 276.34, 512.95, 90, "GELE571_MQ_03", "", "");
		
		// Grass Dummy
		//-------------------------------------------------------------------------
		AddNpc(117, 47204, "Grass Dummy", "f_gele_57_1", -1501.95, 276.34, 399.63, 90, "GELE571_MQ_03", "", "");
		
		// Grass Dummy
		//-------------------------------------------------------------------------
		AddNpc(117, 47204, "Grass Dummy", "f_gele_57_1", -1506.592, 276.3425, 76.2149, 90, "GELE571_MQ_03", "", "");
		
		// Grass Dummy
		//-------------------------------------------------------------------------
		AddNpc(117, 47204, "Grass Dummy", "f_gele_57_1", -1192.194, 276.3425, -129.7668, 90, "GELE571_MQ_03", "", "");
		
		// Grass Dummy
		//-------------------------------------------------------------------------
		AddNpc(117, 47204, "Grass Dummy", "f_gele_57_1", -1480.81, 276.3425, -180.4353, 90, "GELE571_MQ_03", "", "");
		
		// Grass Dummy
		//-------------------------------------------------------------------------
		AddNpc(117, 47204, "Grass Dummy", "f_gele_57_1", -1392.776, 276.3425, 130.3467, 90, "GELE571_MQ_03", "", "");
		
		// Grass Dummy
		//-------------------------------------------------------------------------
		AddNpc(117, 47204, "Grass Dummy", "f_gele_57_1", -1538.045, 276.3425, -71.39037, 90, "GELE571_MQ_03", "", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(133, 40120, "Statue of Goddess Vakarine", "f_gele_57_1", -132.3, 168.82, -571.54, -9, "WARP_F_GELE_57_1", "STOUP_CAMP", "STOUP_CAMP");
		AddNpc(135, 147365, "Field Gen x", "f_gele_57_1", -397.64, 168.82, -641.99, 90, "", "", "");
		AddNpc(135, 147365, "Field Gen x", "f_gele_57_1", -99.12251, 168.8233, -619.7493, 90, "", "", "");
		AddNpc(135, 147365, "Field Gen x", "f_gele_57_1", -355.81, 168.82, -840.64, 90, "", "", "");
		AddNpc(135, 147365, "Field Gen x", "f_gele_57_1", -175.39, 168.82, -841, 90, "", "", "");
		
		// Watcher Matthew
		//-------------------------------------------------------------------------
		AddNpc(137, 147421, "Watcher Matthew", "f_gele_57_1", -401, 168, -642, 74, "GELE571_NPC_MATTHEW", "", "");
		
		// Watcher Molly
		//-------------------------------------------------------------------------
		AddNpc(138, 147423, "Watcher Molly", "f_gele_57_1", -257.99, 95.99, 283.71, 123, "GELE571_NPC_MARLEY", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(136, 147451, "", "f_gele_57_1", 607.16, 95.99, 528.5, 90, "GELE571_NPC_PANTO", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(136, 147451, "", "f_gele_57_1", 757.72, 95.99, 568.46, 90, "GELE571_NPC_PANTO", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(136, 147451, "", "f_gele_57_1", 832.19, 95.99, 389.37, 90, "GELE571_NPC_PANTO", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(136, 147451, "", "f_gele_57_1", 779.14, 95.99, 312.72, 90, "GELE571_NPC_PANTO", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(136, 147451, "", "f_gele_57_1", 681.05, 95.99, 297.3, 90, "GELE571_NPC_PANTO", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(136, 147451, "", "f_gele_57_1", 565.13, 95.99, 280.52, 90, "GELE571_NPC_PANTO", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(136, 147451, "", "f_gele_57_1", 411.6, 95.99, 323.87, 90, "GELE571_NPC_PANTO", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(136, 147451, "", "f_gele_57_1", 376.72, 95.99, 559.83, 90, "GELE571_NPC_PANTO", "", "");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(145, 40070, "Bulletin Board", "f_gele_57_1", -1496, 168, -968, 90, "GELE1_BOARD01", "", "");
		AddNpc(135, 147365, "Field Gen x", "f_gele_57_1", -332.9766, 95.9891, 309.762, 90, "", "", "");
		AddNpc(135, 147365, "Field Gen x", "f_gele_57_1", -1656.908, 168.8233, -1123.918, 90, "", "", "");
		
		// Poata's Nest
		//-------------------------------------------------------------------------
		AddNpc(146, 47203, "Poata's Nest", "f_gele_57_1", 793, 368, -1362, 126, "GELE571_MQ_05", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(147, 147451, "", "f_gele_57_1", 980, 253, 961, 90, "GELE571_MQ_07", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(148, 147451, "", "f_gele_57_1", 950, 266, 963, 270, "", "GELE571_MQ_07_1", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(148, 147451, "", "f_gele_57_1", 999, 251, 995, 135, "", "GELE571_MQ_07_1", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(148, 147451, "", "f_gele_57_1", 980, 264, 1025, 225, "", "GELE571_MQ_07_1", "");
		
		// To the other side
		//-------------------------------------------------------------------------
		AddNpc(152, 40070, "To the other side", "f_gele_57_1", -290.8438, 168.8233, -520.5992, 0, "GELE_57_1_CABLETEMP_01", "", "");
		
		// To the other side
		//-------------------------------------------------------------------------
		AddNpc(153, 40070, "To the other side", "f_gele_57_1", -305.344, 95.9891, 200.1367, 0, "GELE_57_1_CABLETEMP_02", "", "");
		AddNpc(154, 20170, "Search Skill Trigger", "f_gele_57_1", 1482.46, 224.83, -752.67, 90, "", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(155, 20024, " ", "f_gele_57_1", -1542.498, 168.8233, -1083.21, 90, "PARTY_Q3_GELE01", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(157, 20024, " ", "f_gele_57_1", 1929.394, 166.8134, 79.72261, 90, "PARTY_Q3_GELE02", "", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(158, 147392, "Lv1 Treasure Chest", "f_gele_57_1", 22, 168.92, -979.04, 90, "TREASUREBOX_LV_F_GELE_57_1158", "", "");
		
		// Plateau Sugar Beet Stems
		//-------------------------------------------------------------------------
		AddNpc(159, 47201, "Plateau Sugar Beet Stems", "f_gele_57_1", 1461.146, 166.8134, 384.5148, 90, "GELE571_RP_1_OBJ", "", "");
		
		// Plateau Sugar Beet Stems
		//-------------------------------------------------------------------------
		AddNpc(159, 47201, "Plateau Sugar Beet Stems", "f_gele_57_1", 1247.689, 166.8134, 626.0811, 90, "GELE571_RP_1_OBJ", "", "");
		
		// Plateau Sugar Beet Stems
		//-------------------------------------------------------------------------
		AddNpc(159, 47201, "Plateau Sugar Beet Stems", "f_gele_57_1", 1321.018, 166.8134, 463.7831, 90, "GELE571_RP_1_OBJ", "", "");
		
		// Plateau Sugar Beet Stems
		//-------------------------------------------------------------------------
		AddNpc(159, 47201, "Plateau Sugar Beet Stems", "f_gele_57_1", 1560.621, 166.8134, 501.1877, 90, "GELE571_RP_1_OBJ", "", "");
		
		// Plateau Sugar Beet Stems
		//-------------------------------------------------------------------------
		AddNpc(159, 47201, "Plateau Sugar Beet Stems", "f_gele_57_1", 1625.516, 166.8134, 721.4664, 90, "GELE571_RP_1_OBJ", "", "");
		
		// Plateau Sugar Beet Stems
		//-------------------------------------------------------------------------
		AddNpc(159, 47201, "Plateau Sugar Beet Stems", "f_gele_57_1", 1484.599, 166.8134, 924.0555, 90, "GELE571_RP_1_OBJ", "", "");
		
		// Plateau Sugar Beet Stems
		//-------------------------------------------------------------------------
		AddNpc(159, 47201, "Plateau Sugar Beet Stems", "f_gele_57_1", 1370.013, 166.8134, 921.287, 90, "GELE571_RP_1_OBJ", "", "");
		
		// Plateau Sugar Beet Stems
		//-------------------------------------------------------------------------
		AddNpc(159, 47201, "Plateau Sugar Beet Stems", "f_gele_57_1", 1201.997, 167.158, 969.8781, 90, "GELE571_RP_1_OBJ", "", "");
		
		// Plateau Sugar Beet Stems
		//-------------------------------------------------------------------------
		AddNpc(159, 47201, "Plateau Sugar Beet Stems", "f_gele_57_1", 1003.929, 229.1478, 889.205, 90, "GELE571_RP_1_OBJ", "", "");
		
		// Plateau Sugar Beet Stems
		//-------------------------------------------------------------------------
		AddNpc(159, 47201, "Plateau Sugar Beet Stems", "f_gele_57_1", 758.899, 267.4677, 893.6205, 90, "GELE571_RP_1_OBJ", "", "");
		
		// Plateau Sugar Beet Stems
		//-------------------------------------------------------------------------
		AddNpc(159, 47201, "Plateau Sugar Beet Stems", "f_gele_57_1", 572.5952, 267.4677, 932.1086, 90, "GELE571_RP_1_OBJ", "", "");
		
		// Plateau Sugar Beet Stems
		//-------------------------------------------------------------------------
		AddNpc(159, 47201, "Plateau Sugar Beet Stems", "f_gele_57_1", 465.3732, 267.4677, 992.3305, 90, "GELE571_RP_1_OBJ", "", "");
		
		// Plateau Sugar Beet Stems
		//-------------------------------------------------------------------------
		AddNpc(159, 47201, "Plateau Sugar Beet Stems", "f_gele_57_1", 448.7435, 267.4677, 1161.481, 90, "GELE571_RP_1_OBJ", "", "");
		
		// Plateau Sugar Beet Stems
		//-------------------------------------------------------------------------
		AddNpc(159, 47201, "Plateau Sugar Beet Stems", "f_gele_57_1", 434.148, 267.4677, 1290.53, 90, "GELE571_RP_1_OBJ", "", "");
		
		// Plateau Sugar Beet Stems
		//-------------------------------------------------------------------------
		AddNpc(159, 47201, "Plateau Sugar Beet Stems", "f_gele_57_1", 802.425, 267.4677, 1411.518, 90, "GELE571_RP_1_OBJ", "", "");
		
		// Plateau Sugar Beet Stems
		//-------------------------------------------------------------------------
		AddNpc(159, 47201, "Plateau Sugar Beet Stems", "f_gele_57_1", 934.8285, 267.4677, 1316.14, 90, "GELE571_RP_1_OBJ", "", "");
		
		// Plateau Sugar Beet Stems
		//-------------------------------------------------------------------------
		AddNpc(159, 47201, "Plateau Sugar Beet Stems", "f_gele_57_1", 922.61, 267.4677, 1127.583, 90, "GELE571_RP_1_OBJ", "", "");
		
		// Plateau Sugar Beet Stems
		//-------------------------------------------------------------------------
		AddNpc(159, 47201, "Plateau Sugar Beet Stems", "f_gele_57_1", 1027.952, 251.1026, 1048.905, 90, "GELE571_RP_1_OBJ", "", "");
		
		// Plateau Sugar Beet Stems
		//-------------------------------------------------------------------------
		AddNpc(159, 47201, "Plateau Sugar Beet Stems", "f_gele_57_1", 1586.069, 166.8134, 67.58208, 90, "GELE571_RP_1_OBJ", "", "");
		
		// Plateau Sugar Beet Stems
		//-------------------------------------------------------------------------
		AddNpc(159, 47201, "Plateau Sugar Beet Stems", "f_gele_57_1", 1665.072, 166.8134, -46.44629, 90, "GELE571_RP_1_OBJ", "", "");
		
		// Plateau Sugar Beet Stems
		//-------------------------------------------------------------------------
		AddNpc(159, 47201, "Plateau Sugar Beet Stems", "f_gele_57_1", 1848.49, 166.8134, -62.98946, 90, "GELE571_RP_1_OBJ", "", "");
		
		// Plateau Sugar Beet Stems
		//-------------------------------------------------------------------------
		AddNpc(159, 47201, "Plateau Sugar Beet Stems", "f_gele_57_1", 1960.662, 166.8134, 62.02409, 90, "GELE571_RP_1_OBJ", "", "");
		
		// Plateau Sugar Beet Stems
		//-------------------------------------------------------------------------
		AddNpc(159, 47201, "Plateau Sugar Beet Stems", "f_gele_57_1", 1570.407, 166.8134, 217.9513, 90, "GELE571_RP_1_OBJ", "", "");
		
		// Plateau Sugar Beet Stems
		//-------------------------------------------------------------------------
		AddNpc(159, 47201, "Plateau Sugar Beet Stems", "f_gele_57_1", 1917.527, 166.8134, 207.2458, 90, "GELE571_RP_1_OBJ", "", "");
		
		// Plateau Sugar Beet Stems
		//-------------------------------------------------------------------------
		AddNpc(159, 47201, "Plateau Sugar Beet Stems", "f_gele_57_1", 1810.396, 166.8134, 314.759, 90, "GELE571_RP_1_OBJ", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(160, 20026, " ", "f_gele_57_1", -141.156, 95.98911, 405.8867, 90, "", "GELE571_MQ_04_TGT", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(160, 20026, " ", "f_gele_57_1", 1045.469, 140.2868, 628.8118, 90, "", "GELE571_MQ_04_TGT", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(160, 20026, " ", "f_gele_57_1", 306.5867, 95.9891, 409.6581, 90, "", "GELE571_MQ_04_TGT", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(160, 20026, " ", "f_gele_57_1", 737.1281, 95.9891, 431.8421, 90, "", "GELE571_MQ_04_TGT", "");
		AddNpc(161, 160034, "Transportation Device", "f_gele_57_1", -306.0865, 96.22449, 154.3987, 90, "", "", "");
		AddNpc(162, 160034, "Transportation Device", "f_gele_57_1", -316.878, 168.8233, -465.7924, 90, "", "", "");
	}
}
