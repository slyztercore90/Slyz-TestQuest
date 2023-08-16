//--- Melia Script ----------------------------------------------------------
// Ouaas Memorial
//--- Description -----------------------------------------------------------
// NPCs found in and around Ouaas Memorial.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FPilgrimroad415NpcScript : GeneralScript
{
	public override void Load()
	{
		// Rasvoy Lake
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Rasvoy Lake", "f_pilgrimroad_41_5", -1941.114, -51.90838, 576.4455, -89, "", "PILGRIM41_5_PILGRIM41_3", "");
		AddNpc(3, 147362, "FieldCantGen", "f_pilgrimroad_41_5", -1941.625, -51.90838, 572.4664, 90, "", "", "");
		AddNpc(4, 20026, "", "f_pilgrimroad_41_5", 1360.898, -11.48038, 218.3964, 90, "", "", "");
		
		// UnVisibleName
		//-------------------------------------------------------------------------
		AddNpc(5, 151045, "UnVisibleName", "f_pilgrimroad_41_5", -129.1206, -98.99318, 17.28439, 90, "DELIVERY_CHARGES_GAME", "", "");
		AddNpc(6, 20026, "", "f_pilgrimroad_41_5", 1276.763, 37.83511, -980.2154, 90, "", "", "");
		AddNpc(7, 20026, "", "f_pilgrimroad_41_5", -1086.611, -65.60628, -306.1852, 90, "", "", "");
		AddNpc(7, 20026, "", "f_pilgrimroad_41_5", -151.4937, -61.92107, 1058.844, 90, "", "", "");
		AddNpc(7, 20026, "", "f_pilgrimroad_41_5", 844.5733, 4.060495, -234.4995, 90, "", "", "");
		AddNpc(7, 20026, "", "f_pilgrimroad_41_5", 1914.554, -11.48036, 340.6967, 90, "", "", "");
		AddNpc(8, 20026, "", "f_pilgrimroad_41_5", 1018.316, 37.83512, -900.0175, 90, "", "", "");
		AddNpc(8, 20026, "", "f_pilgrimroad_41_5", 189.8189, -60.48248, -785.9006, 90, "", "", "");
		AddNpc(8, 20026, "", "f_pilgrimroad_41_5", -1273.486, -65.60628, -1077.559, 90, "", "", "");
		AddNpc(8, 20026, "", "f_pilgrimroad_41_5", -1702.329, -51.90838, 691.8844, 90, "", "", "");
		
		// Monk Stella
		//-------------------------------------------------------------------------
		AddNpc(9, 155126, "Monk Stella", "f_pilgrimroad_41_5", -1518.024, -51.90837, 681.9841, 9, "PILGRIM415_SQ_01", "", "");
		
		// Monk Stella
		//-------------------------------------------------------------------------
		AddNpc(10, 155126, "Monk Stella", "f_pilgrimroad_41_5", -126.7505, -60.48248, -923.7063, 90, "PILGRIM415_SQ_09", "", "");
		
		// Monk Stella
		//-------------------------------------------------------------------------
		AddNpc(11, 155126, "Monk Stella", "f_pilgrimroad_41_5", -779.813, -98.99318, 275.5391, 123, "PILGRIM415_SQ_10", "", "");
		
		// Monk Mattas
		//-------------------------------------------------------------------------
		AddNpc(12, 155046, "Monk Mattas", "f_pilgrimroad_41_5", 1059.891, -11.48038, 250.2739, 19, "PILGRIM415_SQ_03", "", "");
		
		// Monk Mattas
		//-------------------------------------------------------------------------
		AddNpc(13, 155046, "Monk Mattas", "f_pilgrimroad_41_5", -742.8293, -98.99318, 360.9496, 10, "PILGRIM415_SQ_06", "PILGRIM415_SQ_06_1", "");
		
		// Monk Mattas
		//-------------------------------------------------------------------------
		AddNpc(14, 155046, "Monk Mattas", "f_pilgrimroad_41_5", -742.8293, -98.99318, 360.9496, 10, "PILGRIM415_SQ_06_2", "", "");
		
		// High Officer Medea
		//-------------------------------------------------------------------------
		AddNpc(15, 156006, "High Officer Medea", "f_pilgrimroad_41_5", 1170.19, 37.8351, -861.1136, 21, "PILGRIM415_SQ_08", "", "");
		
		// High Officer Medea
		//-------------------------------------------------------------------------
		AddNpc(16, 156006, "High Officer Medea", "f_pilgrimroad_41_5", -773.5663, -98.99318, 323.9143, 90, "PILGRIM415_SQ_08_1", "", "");
		
		// UnVisibleName
		//-------------------------------------------------------------------------
		AddNpc(17, 47107, "UnVisibleName", "f_pilgrimroad_41_5", -1204.466, -65.60629, -1109.019, 90, "PILGRIM415_SQ_02", "PILGRIM415_SQ_02_1", "");
		
		// UnVisibleName
		//-------------------------------------------------------------------------
		AddNpc(18, 47107, "UnVisibleName", "f_pilgrimroad_41_5", 1414.809, -11.48039, 36.67443, 90, "PILGRIM415_SQ_05", "", "");
		
		// UnVisibleName
		//-------------------------------------------------------------------------
		AddNpc(19, 47107, "UnVisibleName", "f_pilgrimroad_41_5", 1395.321, 37.83511, -1146.479, 90, "PILGRIM415_SQ_07", "", "");
		
		// UnVisibleName
		//-------------------------------------------------------------------------
		AddNpc(20, 153149, "UnVisibleName", "f_pilgrimroad_41_5", -1204.466, -65.60629, -1109.019, 90, "PILGRIM415_SQ_10_1", "", "");
		
		// UnVisibleName
		//-------------------------------------------------------------------------
		AddNpc(21, 153149, "UnVisibleName", "f_pilgrimroad_41_5", 1414.809, -11.48039, 36.67443, 90, "PILGRIM415_SQ_10_2", "", "");
		
		// UnVisibleName
		//-------------------------------------------------------------------------
		AddNpc(22, 153149, "UnVisibleName", "f_pilgrimroad_41_5", 1395.321, 37.83511, -1146.479, 90, "PILGRIM415_SQ_10_3", "", "");
		
		// Unnamed Monk's Tombstone
		//-------------------------------------------------------------------------
		AddNpc(23, 47252, "Unnamed Monk's Tombstone", "f_pilgrimroad_41_5", 70.91111, -60.48248, -793.8766, -6, "PILGRIM415_SQ_11", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(24, 20041, "", "f_pilgrimroad_41_5", -807.8059, -98.99318, 313.7925, 90, "PILGRIM415_TREE", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(25, 20026, "", "f_pilgrimroad_41_5", -1388.299, -51.90838, 415.271, 90, "", "PILGRIM415_SQ_04", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(26, 20026, "", "f_pilgrimroad_41_5", -49.62457, -60.48248, -650.1313, 90, "", "PILGRIM415_SQ_09_1", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(27, 20026, "", "f_pilgrimroad_41_5", -773.5663, -98.99318, 323.9143, 90, "", "PILGRIM415_SQ_10_4", "");
		AddNpc(28, 147363, "Gate Entrance x", "f_pilgrimroad_41_5", -793.9799, -98.99318, 323.7726, 90, "", "", "");
		AddNpc(29, 147362, "Gate Entrance x", "f_pilgrimroad_41_5", -1517.327, -51.90838, 663.1464, 90, "", "", "");
		AddNpc(30, 147361, "Gate Entrance x", "f_pilgrimroad_41_5", -127.003, -60.48248, -923.5558, 90, "", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(105, 47201, " ", "f_pilgrimroad_41_5", 27.4283, -98.99318, -264.7087, 90, "", "JOB_3_DRUID_OBJ", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(105, 47201, " ", "f_pilgrimroad_41_5", -190.729, -98.99318, 290.4022, 90, "", "JOB_3_DRUID_OBJ", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(105, 47201, " ", "f_pilgrimroad_41_5", 221.2181, -98.99318, 24.32487, 90, "", "JOB_3_DRUID_OBJ", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(105, 47201, " ", "f_pilgrimroad_41_5", 683.9174, 4.060493, -264.5182, 90, "", "JOB_3_DRUID_OBJ", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(105, 47201, " ", "f_pilgrimroad_41_5", -338.1865, -98.99318, -140.7286, 90, "", "JOB_3_DRUID_OBJ", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(105, 47201, " ", "f_pilgrimroad_41_5", -593.5153, -61.92107, 957.3922, 90, "", "JOB_3_DRUID_OBJ", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(105, 47201, " ", "f_pilgrimroad_41_5", -363.3931, -61.92108, 902.6395, 90, "", "JOB_3_DRUID_OBJ", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(105, 47201, " ", "f_pilgrimroad_41_5", -222.1782, -61.92107, 756.2414, 90, "", "JOB_3_DRUID_OBJ", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(105, 47201, " ", "f_pilgrimroad_41_5", -586.8733, -61.92107, 723.022, 90, "", "JOB_3_DRUID_OBJ", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(105, 47201, " ", "f_pilgrimroad_41_5", 731.6317, 4.060514, -562.4781, 90, "", "JOB_3_DRUID_OBJ", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(105, 47201, " ", "f_pilgrimroad_41_5", 918.5551, 4.060501, -212.9525, 90, "", "JOB_3_DRUID_OBJ", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(105, 47201, " ", "f_pilgrimroad_41_5", 518.5134, -51.61437, 270.9422, 90, "", "JOB_3_DRUID_OBJ", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(105, 47201, " ", "f_pilgrimroad_41_5", 616.4259, -51.61438, 558.889, 90, "", "JOB_3_DRUID_OBJ", "");
	}
}
