//--- Melia Script ----------------------------------------------------------
// Cobalt Forest
//--- Description -----------------------------------------------------------
// NPCs found in and around Cobalt Forest.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FHuevillage583NpcScript : GeneralScript
{
	public override void Load()
	{
		// Vieta Gorge
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Vieta Gorge", "f_huevillage_58_3", 418.0233, -86.7077, -1834.006, -5, "", "HUEVILLAGE58_3_TO_HUEVILLAGE58_2", "");
		
		// Septyni Glen
		//-------------------------------------------------------------------------
		AddNpc(3, 40001, "Septyni Glen", "f_huevillage_58_3", -1129.885, 22.14493, -29.77028, 207, "", "HUEVILLAGE58_3_TO_HUEVILLAGE58_4", "");
		
		// Andale Village Priest
		//-------------------------------------------------------------------------
		AddNpc(7, 147408, "Andale Village Priest", "f_huevillage_58_3", 438.8962, -117.4459, -598.1819, 90, "HUEVILLAGE_58_3_MQ01_NPC", "", "");
		
		// Andale Village Headman
		//-------------------------------------------------------------------------
		AddNpc(8, 147396, "Andale Village Headman", "f_huevillage_58_3", 562.931, -117.3718, -844.8317, 90, "HUEVILLAGE_58_3_MQ03_NPC", "", "");
		
		// Warning
		//-------------------------------------------------------------------------
		AddNpc(27, 40070, "Warning", "f_huevillage_58_3", 1112.542, -86.70761, -212.9394, 27, "HUVILLAGE_58_3_WELL_WARING", "", "");
		AddNpc(33, 147366, "Field Gen x", "f_huevillage_58_3", 340.9163, -86.7077, -1608.679, 90, "", "", "");
		AddNpc(33, 147366, "Field Gen x", "f_huevillage_58_3", 676.9524, -116.6459, -852.8513, 90, "", "", "");
		AddNpc(33, 147366, "Field Gen x", "f_huevillage_58_3", 244.6989, -117.4459, -608.7192, 90, "", "", "");
		AddNpc(33, 147366, "Field Gen x", "f_huevillage_58_3", -1388.348, -1.3659, -1288.003, 90, "", "", "");
		AddNpc(33, 147366, "Field Gen x", "f_huevillage_58_3", -1129.641, 22.30516, -56.94745, 90, "", "", "");
		
		// Sleeping Upent
		//-------------------------------------------------------------------------
		AddNpc(34, 57019, "Sleeping Upent", "f_huevillage_58_3", -1395.59, -1.37, -1312.53, 104, "HUEVILLAGE_58_3_MQ04_NPC01", "", "");
		
		// Sleeping Upent
		//-------------------------------------------------------------------------
		AddNpc(35, 57019, "Sleeping Upent", "f_huevillage_58_3", -1459.64, -1.37, -1383.54, 150, "", "HUEVILLAGE_58_3_MQ04_NPC02", "");
		
		// Sleeping Upent
		//-------------------------------------------------------------------------
		AddNpc(35, 57019, "Sleeping Upent", "f_huevillage_58_3", -1431.66, -1.37, -1311.59, -66, "", "HUEVILLAGE_58_3_MQ04_NPC02", "");
		
		// Sleeping Upent
		//-------------------------------------------------------------------------
		AddNpc(35, 57019, "Sleeping Upent", "f_huevillage_58_3", -1388.6, -1.37, -1346.46, 57, "", "HUEVILLAGE_58_3_MQ04_NPC02", "");
		
		// Languid Herb
		//-------------------------------------------------------------------------
		AddNpc(36, 47201, "Languid Herb", "f_huevillage_58_3", 1889.339, -86.7077, -362.3805, 100, "HUEVILLAGE_58_3_MQ01_GRASS", "", "");
		
		// Languid Herb
		//-------------------------------------------------------------------------
		AddNpc(36, 47201, "Languid Herb", "f_huevillage_58_3", 2011.822, -86.70766, -566.5384, 95, "HUEVILLAGE_58_3_MQ01_GRASS", "", "");
		
		// Languid Herb
		//-------------------------------------------------------------------------
		AddNpc(36, 47201, "Languid Herb", "f_huevillage_58_3", 1820.731, -86.7077, -781.0388, 90, "HUEVILLAGE_58_3_MQ01_GRASS", "", "");
		
		// Languid Herb
		//-------------------------------------------------------------------------
		AddNpc(36, 47201, "Languid Herb", "f_huevillage_58_3", 1702.579, -86.7077, -481.5159, 80, "HUEVILLAGE_58_3_MQ01_GRASS", "", "");
		
		// Languid Herb
		//-------------------------------------------------------------------------
		AddNpc(36, 47201, "Languid Herb", "f_huevillage_58_3", 1673.03, -86.7077, -268.1107, 85, "HUEVILLAGE_58_3_MQ01_GRASS", "", "");
		
		// Strongly Scented Soul Flower
		//-------------------------------------------------------------------------
		AddNpc(37, 147412, "Strongly Scented Soul Flower", "f_huevillage_58_3", 498, -86, 512, 60, "HUEVILLAGE_58_3_MQ02_FLOWER", "", "");
		
		// Barrel of Explosives
		//-------------------------------------------------------------------------
		AddNpc(38, 147458, "Barrel of Explosives", "f_huevillage_58_3", -155.8625, -116.7223, 234.1455, 90, "HUEVILLAGE_58_3_MQ03_DRUM_FAKE", "", "");
		
		// Barrel of Explosives
		//-------------------------------------------------------------------------
		AddNpc(38, 147458, "Barrel of Explosives", "f_huevillage_58_3", -240.2384, -116.7213, 228.3441, 90, "HUEVILLAGE_58_3_MQ03_DRUM_FAKE", "", "");
		
		// Barrel of Explosives
		//-------------------------------------------------------------------------
		AddNpc(38, 147458, "Barrel of Explosives", "f_huevillage_58_3", -119.6051, -116.7228, 327.8456, 90, "HUEVILLAGE_58_3_MQ03_DRUM_FAKE", "", "");
		
		// Barrel of Explosives
		//-------------------------------------------------------------------------
		AddNpc(38, 147458, "Barrel of Explosives", "f_huevillage_58_3", -235.6622, -116.7219, 140.6209, 90, "HUEVILLAGE_58_3_MQ03_DRUM_FAKE", "", "");
		
		// Barrel of Explosives
		//-------------------------------------------------------------------------
		AddNpc(38, 147458, "Barrel of Explosives", "f_huevillage_58_3", -328.3791, -116.7212, 117.9618, 90, "HUEVILLAGE_58_3_MQ03_DRUM_FAKE", "", "");
		
		// Barrel of Explosives
		//-------------------------------------------------------------------------
		AddNpc(39, 147459, "Barrel of Explosives", "f_huevillage_58_3", -322.3594, -116.7209, 215.865, 90, "HUEVILLAGE_58_3_MQ03_DRUM", "", "");
		
		// Barrel of Explosives
		//-------------------------------------------------------------------------
		AddNpc(39, 147459, "Barrel of Explosives", "f_huevillage_58_3", -241.4406, -116.7216, 351.8501, 90, "HUEVILLAGE_58_3_MQ03_DRUM", "", "");
		
		// Old Well
		//-------------------------------------------------------------------------
		AddNpc(41, 147469, "Old Well", "f_huevillage_58_3", 1070, -74, -101, 90, "HUEVILLAGE_58_3_SQ01_NPC01", "", "");
		
		// Bucket
		//-------------------------------------------------------------------------
		AddNpc(42, 147354, "Bucket", "f_huevillage_58_3", 200.3023, -32.8737, -421.9907, 90, "HUEVILLAGE_58_3_SQ01_NPC02", "", "");
		
		// Old Tent
		//-------------------------------------------------------------------------
		AddNpc(43, 147469, "Old Tent", "f_huevillage_58_3", -681, -3, -1153, 90, "HUEVILLAGE_58_3_SQ01_NPC03", "", "");
		
		// Languid Herb
		//-------------------------------------------------------------------------
		AddNpc(36, 47201, "Languid Herb", "f_huevillage_58_3", 1662.647, -86.7077, -662.7324, 90, "HUEVILLAGE_58_3_MQ01_GRASS", "", "");
		AddNpc(33, 147366, "Field Gen x", "f_huevillage_58_3", -242.5046, -116.7212, 307.2094, 90, "", "", "");
		
		// Tenants' Farm
		//-------------------------------------------------------------------------
		AddNpc(45, 40001, "Tenants' Farm", "f_huevillage_58_3", -223.0459, -88.07333, -1545.6, 6, "", "HUEVILL_58_3_TO_FARM_47_1", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(47, 20026, "", "f_huevillage_58_3", 405.039, -117.4459, -654.6818, 90, "", "HUEVILLAGE_SOUL01", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(48, 20026, "", "f_huevillage_58_3", 262.5762, -116.0734, -919.0522, 90, "", "HUEVILLAGE_SOUL02", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(49, 20026, "", "f_huevillage_58_3", 1136.006, -86.7077, -980.9241, 90, "", "HUEVILLAGE_SOUL03", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(50, 20026, "", "f_huevillage_58_3", 1091.148, -77.38187, -148.8584, 90, "", "HUEVILLAGE_SOUL04", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(51, 147392, "Lv1 Treasure Chest", "f_huevillage_58_3", 39.6, -117.35, -640.86, 90, "TREASUREBOX_LV_F_HUEVILLAGE_58_351", "", "");
		AddNpc(52, 150004, "Fishing Spot", "f_huevillage_58_3", 1904.729, -86.70766, -609.9006, 90, "", "", "");
		AddNpc(53, 150004, "Fishing Spot", "f_huevillage_58_3", 1742.1, -86.70766, -341.2632, 90, "", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(54, 150008, "", "f_huevillage_58_3", 1802.583, -86.70766, -511.3328, 90, "KLAPEDA_FISHING_BOARD", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(55, 40095, " ", "f_huevillage_58_3", 235.4728, -97.49583, 367.3156, 90, "", "EXPLORER_MISLE22", "");
	}
}
