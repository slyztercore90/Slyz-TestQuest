//--- Melia Script -----------------------------------------------------------
// Irredian Shelter Spawns
//--- Description -----------------------------------------------------------
// Sets up monster spawners for 'd_irredians_113_1'.
//---------------------------------------------------------------------------

using System;
using Melia.Zone.Scripting;
using Melia.Shared.Tos.Const;
using static Melia.Zone.Scripting.Shortcuts;

public class DIrredians1131MobScript : GeneralScript
{
	public override void Load()
	{
		// Monster Spawners ---------------------------------

		AddSpawner("d_irredians_113_1.Id1", MonsterId.Gazer, min: 64, max: 85);
		AddSpawner("d_irredians_113_1.Id2", MonsterId.Greedyprisoner, min: 30, max: 40);
		AddSpawner("d_irredians_113_1.Id3", MonsterId.PuppetM, min: 55, max: 73);
		AddSpawner("d_irredians_113_1.Id4", MonsterId.Maskexecutor, min: 64, max: 85);
		AddSpawner("d_irredians_113_1.Id5", MonsterId.Rootcrystal_03, min: 23, max: 30, respawn: TimeSpan.FromMilliseconds(20000));

		// Monster Spawn Points -----------------------------

		// 'Gazer' GenType 2 Spawn Points
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-1225, -558, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-1125, -533, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-1029, -577, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-1233, -690, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-1199, -794, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-1130, -869, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-987, -859, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-941, -752, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-1430, -140, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-1357, -162, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-1285, -129, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-1437, 4, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-1385, 56, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-1301, 18, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-1099, 737, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-1035, 806, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-920, 761, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-1097, 452, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-1161, 521, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-1157, 624, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-849, 450, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-819, 529, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-834, 641, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-520, -546, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-585, -524, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-631, -435, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(509, -587, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(587, -570, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(603, -470, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(507, 948, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(590, 913, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(629, 776, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-603, 856, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-635, 1010, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-485, 951, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(133, -813, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(221, -773, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(262, -684, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(492, -702, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(563, -684, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(640, -637, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-255, -514, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-262, -436, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-176, -445, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-551, -466, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-559, -404, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-641, -370, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-639, 120, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-525, 201, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-613, 285, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(542, 105, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(628, 150, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(549, 238, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-5, 927, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-78, 999, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(140, 974, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-879, -217, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-815, -201, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-834, 32, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-556, -347, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-1007, -160, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-932, -21, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-1021, 53, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-618, -172, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-544, -87, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-647, 487, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-612, 679, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-545, 326, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-538, 82, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-255, 906, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-196, 893, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(328, 969, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(377, 981, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(569, 553, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(589, 465, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(568, -305, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(553, -233, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-993, 485, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-921, 521, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-163, -547, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-212, -605, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(41, -803, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(235, -548, 20));
		AddSpawnPoint("d_irredians_113_1.Id1", "d_irredians_113_1", Rectangle(-875, 664, 20));

		// 'Greedyprisoner' GenType 3 Spawn Points
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(-1133, -13, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(-968, -64, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(-1226, -623, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(-1071, -727, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(-60, -555, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(66, -530, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(-18, -683, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(-975, 569, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(-1091, 523, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(-994, 732, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(-635, -173, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(-564, -82, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(-621, 492, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(-566, 582, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(-217, 910, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(-167, 993, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(249, 984, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(321, 908, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(530, 600, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(616, 445, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(532, -39, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(597, -141, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(905, -402, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(990, -523, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(974, -304, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(925, 96, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(1038, 42, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(1089, 117, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(938, 670, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(1031, 503, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(1290, 531, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(1317, 705, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(1077, 577, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(1212, 601, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(1338, 99, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(1481, 0, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(1546, 191, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(1175, -511, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(1256, -410, 20));
		AddSpawnPoint("d_irredians_113_1.Id2", "d_irredians_113_1", Rectangle(1210, -318, 20));

		// 'PuppetM' GenType 4 Spawn Points
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1008, -389, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1026, -360, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1053, -329, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1093, -477, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1120, -452, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1152, -431, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1064, -176, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1111, -167, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1144, -209, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1309, -359, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1334, -417, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1357, -375, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(870, -478, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(886, -516, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(933, -541, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1153, -359, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1130, -311, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1086, -270, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(895, -291, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(922, -225, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1391, 60, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1428, 27, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1378, 177, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1415, 207, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1524, 50, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1528, 99, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(875, 45, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(830, 123, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(953, 39, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1112, 33, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1129, 87, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1168, 135, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1126, 183, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1025, 230, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(990, 146, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(892, 649, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(875, 731, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(956, 712, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(971, 503, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1038, 443, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1090, 475, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1024, 593, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1109, 518, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1131, 584, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1181, 551, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1243, 540, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1252, 627, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1320, 568, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1254, 467, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1334, 459, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1238, 750, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1302, 648, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1369, 719, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1016, -237, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1090, -400, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1046, -524, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(947, -468, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1142, -570, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1276, -471, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(977, -183, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(918, 110, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1561, 207, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1613, 132, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(906, 545, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(837, 634, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(831, 706, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1339, 806, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1044, 61, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1391, -10, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1503, -10, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1315, 100, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(1310, 151, 20));
		AddSpawnPoint("d_irredians_113_1.Id3", "d_irredians_113_1", Rectangle(976, 219, 20));

		// 'Maskexecutor' GenType 5 Spawn Points
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-1152, -676, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-1093, -637, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-1027, -678, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-1134, -755, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-1077, -811, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-1026, -788, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-988, -169, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-902, -166, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-861, -107, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-873, -27, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-926, 34, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-1026, 44, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-1019, 505, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-1068, 582, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-1021, 662, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-929, 690, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-900, 613, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-925, 519, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-160, -652, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-187, -584, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-145, -538, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-242, -625, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(56, -724, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(124, -707, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(157, -654, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(138, -556, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(223, -624, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(215, -482, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-640, -278, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-565, -331, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-536, -259, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-644, 0, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-567, 54, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-543, 326, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-647, 360, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-645, 767, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-558, 774, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-569, 942, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-387, 889, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-398, 988, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-68, 894, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(11, 1000, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(92, 877, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(519, 878, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(550, 785, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(644, 702, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(433, 973, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(537, 175, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(622, 28, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(622, 282, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(448, -577, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(366, -602, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(551, -505, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(617, -402, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-93, -612, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(79, -628, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-1301, -650, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-1266, -761, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-1242, -847, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-1224, 631, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-1317, -130, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-1315, -4, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-809, -258, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-826, 70, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-1077, -95, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-1038, -8, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-1121, 545, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-1119, 683, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-979, 587, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-1009, 748, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-79, -525, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(22, -503, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-8, -721, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-86, -677, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(584, -301, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(518, -182, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(651, 467, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(569, 464, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(375, 900, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(306, 1007, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-245, 896, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-240, 1013, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-1077, 775, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-1056, 855, 20));
		AddSpawnPoint("d_irredians_113_1.Id4", "d_irredians_113_1", Rectangle(-937, 781, 20));

		// 'Rootcrystal_03' GenType 7 Spawn Points
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(-357, -1094, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(-285, -932, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(-212, -500, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(161, -713, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(551, -622, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(591, -161, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(573, 238, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(574, 632, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(496, 1017, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(84, 1045, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(-262, 1037, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(-681, 1033, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(-662, 585, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(-657, 188, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(-660, -155, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(-651, -517, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(-1144, -868, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(-1240, -572, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(-962, -636, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(-1404, -142, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(-1092, -16, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(-788, -70, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(-995, 353, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(-1173, 660, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(-872, 601, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(938, 664, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(1292, 644, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(1115, 477, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(1591, 197, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(1338, 77, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(1025, 200, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(827, 65, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(936, -498, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(992, -216, 200));
		AddSpawnPoint("d_irredians_113_1.Id5", "d_irredians_113_1", Rectangle(1291, -422, 200));
	}
}
