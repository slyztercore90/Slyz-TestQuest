//--- Melia Script ----------------------------------------------------------
// Penitence Route
//--- Description -----------------------------------------------------------
// NPCs found in and around Penitence Route.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FPilgrimroad55NpcScript : GeneralScript
{
	public override void Load()
	{
		// Stones
		//-------------------------------------------------------------------------
		AddNpc(10045, "Stones", "f_pilgrimroad_55", -264.9468, -348.9568, 38, "JOB_ARCHER4_2");
		
		// Stones
		//-------------------------------------------------------------------------
		AddNpc(10044, "Stones", "f_pilgrimroad_55", -227.2099, -543.7182, 90, "JOB_ARCHER4_2");
		
		// Stones
		//-------------------------------------------------------------------------
		AddNpc(10043, "Stones", "f_pilgrimroad_55", 16.34722, -243.1312, 90, "JOB_ARCHER4_2");
		
		// Stones
		//-------------------------------------------------------------------------
		AddNpc(10045, "Stones", "f_pilgrimroad_55", 361.54, -466.497, -27, "JOB_ARCHER4_2");
		
		// Stones
		//-------------------------------------------------------------------------
		AddNpc(10044, "Stones", "f_pilgrimroad_55", 266.0987, -612.4353, 90, "JOB_ARCHER4_2");
		
		// Stones
		//-------------------------------------------------------------------------
		AddNpc(10044, "Stones", "f_pilgrimroad_55", -885.5775, 229.9449, 90, "JOB_ARCHER4_2");
		
		// Stones
		//-------------------------------------------------------------------------
		AddNpc(10045, "Stones", "f_pilgrimroad_55", -514.3937, 552.1394, 34, "JOB_ARCHER4_2");
		
		// Stones
		//-------------------------------------------------------------------------
		AddNpc(10043, "Stones", "f_pilgrimroad_55", -822.1495, 22.33638, 90, "JOB_ARCHER4_2");
		
		// Stones
		//-------------------------------------------------------------------------
		AddNpc(10043, "Stones", "f_pilgrimroad_55", -535.8921, 269.1184, 90, "JOB_ARCHER4_2");
		
		// Grand Corridor
		//-------------------------------------------------------------------------
		AddNpc(40001, "Grand Corridor", "f_pilgrimroad_55", 1614.564, 40.79414, 150, "", "PILGRIM55_CATHEDRAL54", "");
		
		// Grand Corridor
		//-------------------------------------------------------------------------
		AddNpc(40001, "Grand Corridor", "f_pilgrimroad_55", -576.0657, 776.1403, 169, "", "PILGRIM55_CATHEDRAL54_RE", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "f_pilgrimroad_55", 1055.57, -424.0734, 0, "WARP_F_PILGRIMROAD_55", "STOUP_CAMP", "STOUP_CAMP");
		
		// Priest Alisha
		//-------------------------------------------------------------------------
		AddNpc(147491, "Priest Alisha", "f_pilgrimroad_55", 722.8712, -445.3557, 50, "PILGRIMROAD55_SQ02");
		
		// Cursed Pilgrim
		//-------------------------------------------------------------------------
		AddNpc(20152, "Cursed Pilgrim", "f_pilgrimroad_55", 1374.248, -773.2021, 143, "PILGRIMROAD55_SQ01");
		
		// Pilgrim Orville
		//-------------------------------------------------------------------------
		AddNpc(155037, "Pilgrim Orville", "f_pilgrimroad_55", -366.23, 486.4813, 12, "PILGRIMROAD55_SQ09");
		
		// Priest Roana
		//-------------------------------------------------------------------------
		AddNpc(147386, "Priest Roana", "f_pilgrimroad_55", -696.9637, 593.1094, -4, "PILGRIMROAD55_SQ05");
		
		// Dallas' Grave
		//-------------------------------------------------------------------------
		AddNpc(47252, "Dallas' Grave", "f_pilgrimroad_55", -320.463, -615.2558, 50, "BISHOP_TOMB");
		
		// Dallas' Body
		//-------------------------------------------------------------------------
		AddNpc(20026, "Dallas' Body", "f_pilgrimroad_55", -246.3085, -47.79858, 94, "", "PRIST_DEAD", "");
		
		// Pilgrim Orville
		//-------------------------------------------------------------------------
		AddNpc(155037, "Pilgrim Orville", "f_pilgrimroad_55", -470.7903, -322.6234, 99, "PILGRIMROAD55_SQ11");
		
		// Moon Thistle
		//-------------------------------------------------------------------------
		AddNpc(47201, "Moon Thistle", "f_pilgrimroad_55", 1454.15, -258.3048, 90, "PILGRIMROAD55_SQ02_HERB");
		
		// Moon Thistle
		//-------------------------------------------------------------------------
		AddNpc(47200, "Moon Thistle", "f_pilgrimroad_55", 1375.707, -94.46993, 90, "PILGRIMROAD55_SQ02_HERB");
		
		// Moon Thistle
		//-------------------------------------------------------------------------
		AddNpc(47201, "Moon Thistle", "f_pilgrimroad_55", 1334.413, -249.0051, 90, "PILGRIMROAD55_SQ02_HERB");
		
		// Moon Thistle
		//-------------------------------------------------------------------------
		AddNpc(47200, "Moon Thistle", "f_pilgrimroad_55", 1553.471, -351.4728, 90, "PILGRIMROAD55_SQ02_HERB");
		
		// Moon Thistle
		//-------------------------------------------------------------------------
		AddNpc(47200, "Moon Thistle", "f_pilgrimroad_55", 1157.277, -291.4189, 90, "PILGRIMROAD55_SQ02_HERB");
		
		// Moon Thistle
		//-------------------------------------------------------------------------
		AddNpc(47201, "Moon Thistle", "f_pilgrimroad_55", 1509.344, -498.3456, 90, "PILGRIMROAD55_SQ02_HERB");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20026, "", "f_pilgrimroad_55", -214.5445, -572.5262, 90, "", "PILGRIMROAD55_SQ11_TOMB", "");
		
		// Pot of boiling medicine
		//-------------------------------------------------------------------------
		AddNpc(153013, "Pot of boiling medicine", "f_pilgrimroad_55", 736.9417, -433.9318, 90, "", "PILGRIMROAD_CAULDRON", "");
		
		// Moon Thistle
		//-------------------------------------------------------------------------
		AddNpc(47200, "Moon Thistle", "f_pilgrimroad_55", 1551.137, -120.7749, 90, "PILGRIMROAD55_SQ02_HERB");
		
		// Moon Thistle
		//-------------------------------------------------------------------------
		AddNpc(47201, "Moon Thistle", "f_pilgrimroad_55", 1247.022, -397.0624, 90, "PILGRIMROAD55_SQ02_HERB");
		
		// Moon Thistle
		//-------------------------------------------------------------------------
		AddNpc(47200, "Moon Thistle", "f_pilgrimroad_55", 1363.17, -470.7308, 90, "PILGRIMROAD55_SQ02_HERB");
		
		// Altar of Purification
		//-------------------------------------------------------------------------
		AddNpc(46213, "Altar of Purification", "f_pilgrimroad_55", -575.5598, 86.63588, -46, "PILGRIMROAD55_ALTAR01", "PILGRIMROAD55_ALTAR01_ANIM");
		
		// Altar of Purification
		//-------------------------------------------------------------------------
		AddNpc(46213, "Altar of Purification", "f_pilgrimroad_55", 32.28408, -478.2611, 90, "PILGRIMROAD55_ALTAR02", "PILGRIMROAD55_ALTAR02_ANIM");
		
		// Altar of Purification
		//-------------------------------------------------------------------------
		AddNpc(46213, "Altar of Purification", "f_pilgrimroad_55", 172.445, -169.251, -64, "PILGRIMROAD55_ALTAR03", "PILGRIMROAD55_ALTAR03_ANIM");
		
		// Altar of Purification
		//-------------------------------------------------------------------------
		AddNpc(46213, "Altar of Purification", "f_pilgrimroad_55", 289.8616, -731.8196, -30, "PILGRIMROAD55_ALTAR04", "PILGRIMROAD55_ALTAR04_ANIM");
		
		// Dallas' Body
		//-------------------------------------------------------------------------
		AddNpc(155036, "Dallas' Body", "f_pilgrimroad_55", -62.1, -331, 90, "SQ09_DEAD_PRIST");
		
		// Priest Alisha
		//-------------------------------------------------------------------------
		AddNpc(147491, "Priest Alisha", "f_pilgrimroad_55", 1396.603, -744.239, 148, "PILGRIMROAD55_SQ02_AFTER");
		
		// Dallas' Body
		//-------------------------------------------------------------------------
		AddNpc(155036, "Dallas' Body", "f_pilgrimroad_55", -386.5267, 486.6694, 9, "", "PRIST_DEAD_BODY_AFTER", "");
		
		// Lv4 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147394, "Lv4 Treasure Chest", "f_pilgrimroad_55", -105.74, 77.43, 90, "TREASUREBOX_LV_F_PILGRIMROAD_5539");
		
		// Barha Forest
		//-------------------------------------------------------------------------
		AddNpc(40001, "Barha Forest", "f_pilgrimroad_55", 1752.151, -636.6796, 39, "", "PILGRIM55_ORCHARD34_3", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "f_pilgrimroad_55", -1007.17, 339.83, 0, "TREASUREBOX_LV_F_PILGRIMROAD_55900");
		
		// Moon Thistle
		//-------------------------------------------------------------------------
		AddNpc(47201, "Moon Thistle", "f_pilgrimroad_55", 1222.245, -143.3315, 90, "PILGRIMROAD55_SQ02_HERB");
		
		// Moon Thistle
		//-------------------------------------------------------------------------
		AddNpc(47200, "Moon Thistle", "f_pilgrimroad_55", 1638, -254.6627, 90, "PILGRIMROAD55_SQ02_HERB");
		
		// Beholder
		//-------------------------------------------------------------------------
		AddNpc(147382, "Beholder", "f_pilgrimroad_55", -233.914, -767.3223, -28, "CHATHEDRAL54_BLACKMAN");
	}
}
