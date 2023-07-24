//--- Melia Script -----------------------------------------------------------
// Stele Road Spawns
//--- Description -----------------------------------------------------------
// Sets up monster spawners for 'f_remains_37'.
//---------------------------------------------------------------------------

using System;
using Melia.Zone.Scripting;
using Melia.Shared.Tos.Const;
using static Melia.Zone.Scripting.Shortcuts;

public class FRemains37MobScript : GeneralScript
{
	public override void Load()
	{
		// Monster Spawners ---------------------------------

		AddSpawner("f_remains_37.Id1", MonsterId.Stub_Tree, min: 8, max: 10);
		AddSpawner("f_remains_37.Id2", MonsterId.Stub_Tree, min: 30, max: 40);
		AddSpawner("f_remains_37.Id3", MonsterId.Tama, min: 12, max: 15);
		AddSpawner("f_remains_37.Id4", MonsterId.TreeAmbulo, min: 8, max: 10);
		AddSpawner("f_remains_37.Id5", MonsterId.TreeAmbulo, min: 19, max: 25);
		AddSpawner("f_remains_37.Id6", MonsterId.Tama, min: 30, max: 40);
		AddSpawner("f_remains_37.Id7", MonsterId.TreeAmbulo, min: 30, max: 40);
		AddSpawner("f_remains_37.Id8", MonsterId.Rootcrystal_01, min: 4, max: 5, respawn: TimeSpan.FromMilliseconds(60000));

		// Monster Spawn Points -----------------------------

		// 'Stub_Tree' GenType 4 Spawn Points
		AddSpawnPoint("f_remains_37.Id1", "f_remains_37", Rectangle(1428, 354, 25));
		AddSpawnPoint("f_remains_37.Id1", "f_remains_37", Rectangle(1470, 721, 25));
		AddSpawnPoint("f_remains_37.Id1", "f_remains_37", Rectangle(1384, 241, 25));
		AddSpawnPoint("f_remains_37.Id1", "f_remains_37", Rectangle(1236, 389, 25));
		AddSpawnPoint("f_remains_37.Id1", "f_remains_37", Rectangle(1270, 598, 25));
		AddSpawnPoint("f_remains_37.Id1", "f_remains_37", Rectangle(1311, 708, 25));
		AddSpawnPoint("f_remains_37.Id1", "f_remains_37", Rectangle(1609, 640, 25));
		AddSpawnPoint("f_remains_37.Id1", "f_remains_37", Rectangle(1569, 444, 25));
		AddSpawnPoint("f_remains_37.Id1", "f_remains_37", Rectangle(1545, 291, 25));
		AddSpawnPoint("f_remains_37.Id1", "f_remains_37", Rectangle(1446, 544, 25));

		// 'Stub_Tree' GenType 5 Spawn Points
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-735, -2267, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1241, -2312, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-973, -2347, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-821, -2455, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-512, -2372, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-946, -2141, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-800, -2045, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-659, -2470, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-429, -2170, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-362, -2323, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-1128, -2165, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-1364, -2181, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-608, -2110, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1283, -2190, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1078, -2264, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1179, -2415, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1311, -2528, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1415, -2338, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1408, -2242, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1377, -2455, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1330, -2331, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1195, -2197, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-711, -2169, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-796, -2327, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(154, -2271, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(207, -2227, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(794, -2242, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(877, -2215, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1378, -2393, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1446, -2452, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1489, -2364, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1477, -2256, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1341, -2280, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1217, -2244, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1266, -2386, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1286, -2505, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1307, -2431, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1374, -2509, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1166, -2339, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1149, -2261, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1274, -2264, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1072, -2362, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1235, -2444, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1007, -2274, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1086, -2208, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1107, -2310, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1330, -2206, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(1001, -2211, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(874, -2268, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(830, -2278, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(837, -2212, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(774, -2283, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(758, -2210, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(217, -2292, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(153, -2216, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(241, -2254, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-321, -2257, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-386, -2153, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-386, -2265, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-308, -2204, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-381, -2201, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-505, -2178, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-642, -2288, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-811, -2229, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-738, -2054, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-628, -2045, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-673, -2153, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-598, -2245, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-553, -2198, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-569, -2126, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-713, -2300, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-431, -2382, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-489, -2427, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-587, -2488, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-673, -2537, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-581, -2424, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-673, -2356, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-872, -2395, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-771, -2383, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-667, -2227, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-813, -2136, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-629, -2185, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-870, -2066, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-981, -2064, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-895, -2159, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-923, -2298, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-859, -2285, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-882, -2199, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-979, -2236, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-1037, -2154, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-1032, -2066, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-1088, -2211, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-930, -2060, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-770, -2114, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-684, -2067, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-837, -2002, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-745, -1984, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-772, -2188, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-1317, -2223, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-1303, -2119, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-1427, -2243, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-1371, -2124, 20));
		AddSpawnPoint("f_remains_37.Id2", "f_remains_37", Rectangle(-1291, -2163, 20));

		// 'Tama' GenType 9 Spawn Points
		AddSpawnPoint("f_remains_37.Id3", "f_remains_37", Rectangle(1458, 583, 9999));

		// 'TreeAmbulo' GenType 37 Spawn Points
		AddSpawnPoint("f_remains_37.Id4", "f_remains_37", Rectangle(479, 643, 9999));

		// 'TreeAmbulo' GenType 47 Spawn Points
		AddSpawnPoint("f_remains_37.Id5", "f_remains_37", Rectangle(593, -853, 100));
		AddSpawnPoint("f_remains_37.Id5", "f_remains_37", Rectangle(789, -871, 100));
		AddSpawnPoint("f_remains_37.Id5", "f_remains_37", Rectangle(795, -1160, 100));
		AddSpawnPoint("f_remains_37.Id5", "f_remains_37", Rectangle(729, -1246, 100));
		AddSpawnPoint("f_remains_37.Id5", "f_remains_37", Rectangle(558, -1380, 100));
		AddSpawnPoint("f_remains_37.Id5", "f_remains_37", Rectangle(370, -1243, 100));
		AddSpawnPoint("f_remains_37.Id5", "f_remains_37", Rectangle(396, -964, 100));
		AddSpawnPoint("f_remains_37.Id5", "f_remains_37", Rectangle(384, -1101, 100));
		AddSpawnPoint("f_remains_37.Id5", "f_remains_37", Rectangle(570, -964, 100));
		AddSpawnPoint("f_remains_37.Id5", "f_remains_37", Rectangle(430, -1333, 100));
		AddSpawnPoint("f_remains_37.Id5", "f_remains_37", Rectangle(657, -1291, 100));
		AddSpawnPoint("f_remains_37.Id5", "f_remains_37", Rectangle(723, -1118, 100));
		AddSpawnPoint("f_remains_37.Id5", "f_remains_37", Rectangle(740, -1012, 100));
		AddSpawnPoint("f_remains_37.Id5", "f_remains_37", Rectangle(699, -837, 100));
		AddSpawnPoint("f_remains_37.Id5", "f_remains_37", Rectangle(509, -880, 100));

		// 'Tama' GenType 48 Spawn Points
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(591, 664, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1400, 613, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(602, 2777, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(369, 2639, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(365, 2797, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(676, 2574, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(506, 2680, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(633, 2896, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(822, 2770, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(803, 2641, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(884, 2486, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(816, 2962, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(971, 2695, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(187, 2457, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(328, 2454, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(361, 727, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(524, 791, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(429, 591, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(512, 425, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(670, 497, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(784, 588, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(652, 651, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(554, 729, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(458, 774, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(465, 847, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(366, 889, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(294, 819, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(279, 738, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(350, 825, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(392, 770, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(399, 669, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(483, 706, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(359, 680, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(527, 574, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(561, 645, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(653, 558, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(700, 600, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(702, 672, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(729, 554, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(717, 490, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(790, 493, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(761, 404, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(687, 382, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(636, 368, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(604, 392, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(609, 490, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(550, 494, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(587, 573, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(474, 483, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(417, 427, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(362, 514, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(330, 566, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(324, 644, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(373, 607, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(415, 517, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(490, 556, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(554, 403, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(819, 539, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1221, 633, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1539, 785, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1537, 824, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1630, 826, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1700, 722, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1777, 781, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1699, 807, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1745, 630, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1680, 532, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1668, 429, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1623, 290, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1572, 208, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1484, 143, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1534, 113, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1463, 277, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1416, 167, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1291, 197, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1296, 366, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1366, 335, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1353, 472, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1499, 485, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1488, 375, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1614, 385, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1435, 423, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1273, 484, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1160, 482, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1167, 610, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1155, 711, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1231, 692, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1331, 580, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1363, 721, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1378, 820, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1442, 854, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1437, 787, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1540, 695, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1599, 727, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1656, 607, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1689, 655, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1537, 586, 30));
		AddSpawnPoint("f_remains_37.Id6", "f_remains_37", Rectangle(1595, 548, 30));

		// 'TreeAmbulo' GenType 59 Spawn Points
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(508, 2767, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(354, 2697, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(888, 2584, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(563, 2918, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(734, 2905, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(769, 2741, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(765, 2568, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(459, 2545, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(197, 2481, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(615, 2606, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(921, 2715, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(937, 2775, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(891, 2864, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(767, 2884, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(932, 2850, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(864, 2802, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(862, 2699, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(952, 2615, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(925, 2532, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(804, 2475, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(828, 2550, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(878, 2647, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(717, 2640, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(676, 2725, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(772, 2696, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(683, 2814, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(766, 2840, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(722, 2777, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(825, 2895, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(667, 2945, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(599, 2826, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(596, 2711, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(545, 2577, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(572, 2537, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(460, 2608, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(432, 2723, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(448, 2845, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(478, 2930, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(538, 2869, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(372, 2905, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(290, 2738, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(395, 2584, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(300, 2535, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(268, 2607, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(222, 2699, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(363, 2528, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(784, -939, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(690, -932, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(617, -984, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(449, -976, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(408, -879, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(569, -902, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(546, -1133, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(625, -1187, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(615, -1300, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(624, -1051, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(817, -981, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(865, -885, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(864, -1061, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(779, -1090, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(820, -1043, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(779, -1235, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(865, -1181, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(642, -1372, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(729, -1336, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(518, -1319, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(463, -1200, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(556, -1231, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(469, -1088, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(526, -1027, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(656, -1108, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(499, -937, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(422, -1131, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(354, -923, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(631, -806, 30));
		AddSpawnPoint("f_remains_37.Id7", "f_remains_37", Rectangle(496, -1387, 30));

		// 'Rootcrystal_01' GenType 60 Spawn Points
		AddSpawnPoint("f_remains_37.Id8", "f_remains_37", Rectangle(-1574, -2501, 250));
		AddSpawnPoint("f_remains_37.Id8", "f_remains_37", Rectangle(-1359, -2188, 250));
		AddSpawnPoint("f_remains_37.Id8", "f_remains_37", Rectangle(-854, -2172, 250));
		AddSpawnPoint("f_remains_37.Id8", "f_remains_37", Rectangle(-526, -2244, 250));
		AddSpawnPoint("f_remains_37.Id8", "f_remains_37", Rectangle(105, -2278, 250));
		AddSpawnPoint("f_remains_37.Id8", "f_remains_37", Rectangle(616, -2221, 250));
		AddSpawnPoint("f_remains_37.Id8", "f_remains_37", Rectangle(1064, -2241, 250));
		AddSpawnPoint("f_remains_37.Id8", "f_remains_37", Rectangle(1380, -2374, 250));
		AddSpawnPoint("f_remains_37.Id8", "f_remains_37", Rectangle(568, -1295, 250));
		AddSpawnPoint("f_remains_37.Id8", "f_remains_37", Rectangle(601, -891, 250));
		AddSpawnPoint("f_remains_37.Id8", "f_remains_37", Rectangle(815, -1062, 250));
		AddSpawnPoint("f_remains_37.Id8", "f_remains_37", Rectangle(530, -336, 250));
		AddSpawnPoint("f_remains_37.Id8", "f_remains_37", Rectangle(600, 478, 250));
		AddSpawnPoint("f_remains_37.Id8", "f_remains_37", Rectangle(376, 740, 250));
		AddSpawnPoint("f_remains_37.Id8", "f_remains_37", Rectangle(1164, 537, 250));
		AddSpawnPoint("f_remains_37.Id8", "f_remains_37", Rectangle(1472, 807, 250));
		AddSpawnPoint("f_remains_37.Id8", "f_remains_37", Rectangle(1562, 291, 250));
		AddSpawnPoint("f_remains_37.Id8", "f_remains_37", Rectangle(401, 1130, 250));
		AddSpawnPoint("f_remains_37.Id8", "f_remains_37", Rectangle(98, 1772, 250));
		AddSpawnPoint("f_remains_37.Id8", "f_remains_37", Rectangle(536, 1593, 250));
		AddSpawnPoint("f_remains_37.Id8", "f_remains_37", Rectangle(118, 2274, 250));
		AddSpawnPoint("f_remains_37.Id8", "f_remains_37", Rectangle(393, 2670, 250));
		AddSpawnPoint("f_remains_37.Id8", "f_remains_37", Rectangle(779, 2771, 250));
		AddSpawnPoint("f_remains_37.Id8", "f_remains_37", Rectangle(693, 2559, 250));
	}
}
