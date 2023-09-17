//--- Melia Script ----------------------------------------------------------
// Orsha
//--- Description -----------------------------------------------------------
// NPCs found in and around Orsha.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class COrshaNpcScript : GeneralScript
{
	public override void Load()
	{
		// Orsha Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(40070, "Orsha Bulletin Board", "c_orsha", -1077.49, 332.74, 28, "ORSHA_KEDORLA_BOARD01");
		
		// [Blacksmith]{nl}Ilanai
		//-------------------------------------------------------------------------
		AddNpc(20066, "[Blacksmith]{nl}Ilanai", "c_orsha", -133.44, -285.69, 73, "ORSHA_BLACKSMITH", "TUTO_REPAIR_NPC");
		
		// [Equipment Merchant]{nl}Jura
		//-------------------------------------------------------------------------
		AddNpc(20056, "[Equipment Merchant]{nl}Jura", "c_orsha", 21, 154, 123, "ORSHA_EQUIPMENT_DEALER", "ADDHELP_NPCSHOP");
		
		// Orsha Resident
		//-------------------------------------------------------------------------
		AddNpc(20063, "Orsha Resident", "c_orsha", 384.97, 231.72, -60, "ORSHA_KEDORLA_MEMBER01");
		
		//   [Lord of Orsha]{nl}Inesa Hamondale
		//-------------------------------------------------------------------------
		AddNpc(20065, "  [Lord of Orsha]{nl}Inesa Hamondale", "c_orsha", 86.99, 713.25, 10, "C_ORSHA_HAMONDAIL");
		
		// Lord's Guard
		//-------------------------------------------------------------------------
		AddNpc(20060, "Lord's Guard", "c_orsha", 140.98, 712.85, -20, "C_ORSHA_SOLDIER_02");
		
		// [Orsha Bishop]{nl}Urbonas
		//-------------------------------------------------------------------------
		AddNpc(154057, "[Orsha Bishop]{nl}Urbonas", "c_orsha", 895.18, 702.91, 0, "C_ORSHA_URBONAS");
		
		// [Item Merchant]{nl}Alf
		//-------------------------------------------------------------------------
		AddNpc(20055, "[Item Merchant]{nl}Alf", "c_orsha", 231, 166, 120, "ORSHA_TOOL_NPC");
		
		// [Accessory Merchant]{nl}Jurus
		//-------------------------------------------------------------------------
		AddNpc(20057, "[Accessory Merchant]{nl}Jurus", "c_orsha", 462.1917, -29.93526, -11, "ORSHA_ACCESSARY_NPC", "ORSHA_HQ1_CONDITION");
		
		// [Taoist Master]{nl}GeHong
		//-------------------------------------------------------------------------
		AddNpc(153172, "[Taoist Master]{nl}GeHong", "c_orsha", -327.4769, 655.0816, 4, "DAOSHI_MASTER");
		
		// [Peltasta Submaster]{nl}Nirin Dameoff
		//-------------------------------------------------------------------------
		AddNpc(155063, "[Peltasta Submaster]{nl}Nirin Dameoff", "c_orsha", -853, -62, 100, "JOB_2_PELTASTA_NPC");
		
		// [Hoplite Master]{nl}Aidas Valor
		//-------------------------------------------------------------------------
		AddNpc(147325, "[Hoplite Master]{nl}Aidas Valor", "c_orsha", -1070.18, 229.96, 88, "JOB_2_HOPLITE_NPC");
		
		// [Cleric Submaster]{nl}Tamara Easton
		//-------------------------------------------------------------------------
		AddNpc(155083, "[Cleric Submaster]{nl}Tamara Easton", "c_orsha", -269.96, -378.04, 80, "JOB_2_CLERIC_NPC");
		
		// [Krivis Submaster]{nl}Mellinda Dicherin
		//-------------------------------------------------------------------------
		AddNpc(155084, "[Krivis Submaster]{nl}Mellinda Dicherin", "c_orsha", -612.21, 608.86, 74, "JOB_2_KRIVIS_NPC");
		
		// [Priest Submaster]{nl}Boira
		//-------------------------------------------------------------------------
		AddNpc(155085, "[Priest Submaster]{nl}Boira", "c_orsha", 723.44, 642.36, 15, "JOB_2_PRIEST_NPC");
		
		// [Bokor Submaster]{nl}Bobo Icelin
		//-------------------------------------------------------------------------
		AddNpc(155086, "[Bokor Submaster]{nl}Bobo Icelin", "c_orsha", 462.4, 608.87, 0, "JOB_2_BOKOR_NPC");
		
		// [Rodelero Master]{nl}Kamiya
		//-------------------------------------------------------------------------
		AddNpc(57235, "[Rodelero Master]{nl}Kamiya", "c_orsha", -451, 419, 25, "JOB_2_RODELERO_NPC");
		
		// [Cataphract Master]{nl}Memet Culag
		//-------------------------------------------------------------------------
		AddNpc(147327, "[Cataphract Master]{nl}Memet Culag", "c_orsha", 934.65, 146.95, 71, "JOB_2_CATAPHRACT_NPC");
		
		// [Paladin Submaster]{nl}Sylvia Naimon
		//-------------------------------------------------------------------------
		AddNpc(155088, "[Paladin Submaster]{nl}Sylvia Naimon", "c_orsha", 942.27, 475.77, 95, "JOB_2_PALADIN_NPC");
		
		// Priest Pranas
		//-------------------------------------------------------------------------
		AddNpc(155044, "Priest Pranas", "c_orsha", 915.74, 708.51, 21, "C_ORSHA_PRANAS");
		
		// Lemprasa Pond
		//-------------------------------------------------------------------------
		AddNpc(40001, "Lemprasa Pond", "c_orsha", -1422.59, 368.31, 258, "", "WARP_ORSHA_TO_EP13_F_SIAULIAI_1", "");
		
		// Lord's Guard
		//-------------------------------------------------------------------------
		AddNpc(20059, "Lord's Guard", "c_orsha", 59.57713, 716.5414, 14, "C_ORSHA_SOLDIER_01");
		
		// [Sadhu Master]{nl}Agota Hanska
		//-------------------------------------------------------------------------
		AddNpc(57226, "[Sadhu Master]{nl}Agota Hanska", "c_orsha", 1130.38, 361.98, 93, "JOB_2_SADHU_NPC");
		
		// [Swordman Submaster]{nl}Codill
		//-------------------------------------------------------------------------
		AddNpc(155062, "[Swordman Submaster]{nl}Codill", "c_orsha", 236.57, 648.6, 1, "JOB_2_SWORDMAN_NPC");
		
		// Statue of Goddess Ausrine
		//-------------------------------------------------------------------------
		AddNpc(154063, "Statue of Goddess Ausrine", "c_orsha", 103.14, 322.95, -46, "WARP_C_ORSHA", "STOUP_CAMP", "STOUP_CAMP");
		
		// [Wizard Submaster]{nl}Dejamis
		//-------------------------------------------------------------------------
		AddNpc(155069, "[Wizard Submaster]{nl}Dejamis", "c_orsha", -274.29, -758.49, 90, "JOB_2_WIZARD_MASTER");
		
		// [Pyromancer Submaster]{nl}Cathy Naimos
		//-------------------------------------------------------------------------
		AddNpc(155070, "[Pyromancer Submaster]{nl}Cathy Naimos", "c_orsha", -198.66, -899.4, 90, "JOB_2_PYROMANCER_MASTER");
		
		// [Cryomancer Submaster]{nl}Octavia Iflynn
		//-------------------------------------------------------------------------
		AddNpc(155071, "[Cryomancer Submaster]{nl}Octavia Iflynn", "c_orsha", 1035.62, 79.04, 0, "JOB_2_CRYOMANCER_MASTER");
		
		// [Psychokino Master]{nl}Ili Terid
		//-------------------------------------------------------------------------
		AddNpc(147328, "[Psychokino Master]{nl}Ili Terid", "c_orsha", -859.85, 586.16, 0, "JOB_2_PSYCHOKINO_MASTER");
		
		// [Linker Master]{nl}Winona Ende
		//-------------------------------------------------------------------------
		AddNpc(57230, "[Linker Master]{nl}Winona Ende", "c_orsha", -115.2998, 240.2178, 84, "JOB_2_LINKER_MASTER");
		
		// [Thaumaturge Submaster]{nl}Diemer Fallon
		//-------------------------------------------------------------------------
		AddNpc(155074, "[Thaumaturge Submaster]{nl}Diemer Fallon", "c_orsha", 235.47, -827.3, 0, "JOB_2_THAUMATURGE_MASTER");
		
		// [Elementalist Master]{nl}Wican Celestic
		//-------------------------------------------------------------------------
		AddNpc(147442, "[Elementalist Master]{nl}Wican Celestic", "c_orsha", -647.75, 289.48, 45, "JOB_2_ELEMENTALIST_MASTER");
		
		// [Archer Submaster]{nl}Gunnison
		//-------------------------------------------------------------------------
		AddNpc(155076, "[Archer Submaster]{nl}Gunnison", "c_orsha", -182.95, 658.06, 0, "JOB_2_ARCHER_MASTER");
		
		// [Ranger Submaster]{nl}Sheba
		//-------------------------------------------------------------------------
		AddNpc(155077, "[Ranger Submaster]{nl}Sheba", "c_orsha", 691.07, -197.58, 90, "JOB_2_RANGER_MASTER");
		
		// [Quarrel Shooter Submaster]{nl}Shorris
		//-------------------------------------------------------------------------
		AddNpc(155078, "[Quarrel Shooter Submaster]{nl}Shorris", "c_orsha", 752.0132, -41.47662, -84, "JOB_2_QUARRELSHOOTER_MASTER");
		
		// [Sapper Submaster]{nl}Zubin Katal
		//-------------------------------------------------------------------------
		AddNpc(155079, "[Sapper Submaster]{nl}Zubin Katal", "c_orsha", 50.1228, -332.2393, 90, "JOB_2_SAPPER_MASTER");
		
		// [Hunter Submaster]{nl}Belkin Vellon
		//-------------------------------------------------------------------------
		AddNpc(155080, "[Hunter Submaster]{nl}Belkin Vellon", "c_orsha", -1098.89, -648.37, 90, "JOB_2_HUNTER_MASTER");
		
		// [Wugushi Master]{nl}Wor Pat
		//-------------------------------------------------------------------------
		AddNpc(57233, "[Wugushi Master]{nl}Wor Pat", "c_orsha", -89.38, -755.54, 0, "JOB_2_WUGUSHI_MASTER");
		
		// [Scout Submaster]{nl}Suina
		//-------------------------------------------------------------------------
		AddNpc(155082, "[Scout Submaster]{nl}Suina", "c_orsha", -967.44, -562.9, 0, "JOB_2_SCOUT_MASTER");
		
		// [Companion Trader]{nl}Toras
		//-------------------------------------------------------------------------
		AddNpc(20058, "[Companion Trader]{nl}Toras", "c_orsha", -109.365, 362.765, 104, "ORSHA_PETSHOP", "ORSHA_HIDDENQ2_IN_TRIGGER");
		
		// Velheider
		//-------------------------------------------------------------------------
		AddNpc(47521, "Velheider", "c_orsha", -126.3985, 394.7018, 95, "PETSHOP_KLAIPE_PET");
		
		// [Market Manager]{nl}Tilliana
		//-------------------------------------------------------------------------
		AddNpc(156008, "[Market Manager]{nl}Tilliana", "c_orsha", 213.9646, -12.91508, 4, "ORSHA_MARKET", "TUTO_MARKET_NPC");
		
		// [Storage Keeper]{nl}Aisa
		//-------------------------------------------------------------------------
		AddNpc(20067, "[Storage Keeper]{nl}Aisa", "c_orsha", 320.2166, 69.16746, 90, "ORSHA_WAREHOUSE", "TUTO_STORAGE_NPC");
		
		// [Orsha's Magic Association]{nl}Florianna
		//-------------------------------------------------------------------------
		AddNpc(155102, "[Orsha's Magic Association]{nl}Florianna", "c_orsha", -985.9471, 415.8152, 90, "ORSHA_COLLECTION_SHOP");
		
		// [Wings of Vaivora]{nl}Rosia
		//-------------------------------------------------------------------------
		AddNpc(155103, "[Wings of Vaivora]{nl}Rosia", "c_orsha", -451.5142, -89.63361, 90, "ORSHA_JOURNEY_SHOP", "TUTO_JOURNAL_NPC");
		
		// [TP Trader]{nl}Leticia
		//-------------------------------------------------------------------------
		AddNpc(20068, "[TP Trader]{nl}Leticia", "c_orsha", 47.92036, 36.85776, 90, "TP_NPC", "TUTO_TPSHOP_NPC");
		
		// Girl Settler
		//-------------------------------------------------------------------------
		AddNpc(20062, "Girl Settler", "c_orsha", -42, 207, 90, "ORSHA_NPC01");
		
		// Young Settler
		//-------------------------------------------------------------------------
		AddNpc(20064, "Young Settler", "c_orsha", -203, 537, 90, "ORSHA_NPC02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147466, " ", "c_orsha", -143.0727, -203.0902, 112, "ORSHA_BOOK01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(151067, " ", "c_orsha", -100.2094, -203.3136, 90, "ORSHA_BOOK02");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "c_orsha", -461.54, -277, -45, "TREASUREBOX_LV_C_ORSHA150");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(151128, " ", "c_orsha", 113.8782, -1352.281, 90, "HIDDEN_MIKO_JUROTA");
		
		// Enter Challenge Mode Auto Match
		//-------------------------------------------------------------------------
		AddNpc(147507, "Enter Challenge Mode Auto Match", "c_orsha", 190, 616, 90, "AUTO_CAHLLENGE_ENTER");
		
		// Matador Notice Board
		//-------------------------------------------------------------------------
		AddNpc(40070, "Matador Notice Board", "c_orsha", -217.2029, -37.60239, 67, "ORSHA_CHAR119_MSTEP1");
		
		// [Kedora Alliance]{nl}Geraldason
		//-------------------------------------------------------------------------
		AddNpc(157057, "[Kedora Alliance]{nl}Geraldason", "c_orsha", 389.446, 454.3311, 0, "NPC_JUNK_SHOP_FEDIMIAN_ORSHA");
		
		// Sentry Viola
		//-------------------------------------------------------------------------
		AddNpc(147415, "Sentry Viola", "c_orsha", 356.3264, 611.3615, 7, "INSTANCE_DUNGEON");
		
		// Neringa
		//-------------------------------------------------------------------------
		AddNpc(154102, "Neringa", "c_orsha", 54.93348, 686.3074, 115, "EP12_PRELUDE_NERINGA_ORSHA1");
		
		// Housing Helper Kupole
		//-------------------------------------------------------------------------
		AddNpc(154125, "Housing Helper Kupole", "c_orsha", 606.5975, 601.6386, -8, "NPC_PERSONAL_HOUSING_MANAGER");
		
		// [Event] Goddess Roulette
		//-------------------------------------------------------------------------
		AddNpc(20040, "[Event] Goddess Roulette", "c_orsha", 184, 246, 45, "EVENT_GODDESS_ROULETTE_NPC");
		
		// [Demon God's Temptation]{nl}Illusion of Demon God Ragana
		//-------------------------------------------------------------------------
		AddNpc(154130, "[Demon God's Temptation]{nl}Illusion of Demon God Ragana", "c_orsha", 289.2979, -5.8213, 90, "SHOP_NPC_RAGANA_CITY_1");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(150008, "", "c_orsha", 666.1104, 82.24618, 5, "KLAPEDA_FISHING_BOARD");
		
		// [Fishing Shop]{nl}Joha's Tackle Box
		//-------------------------------------------------------------------------
		AddNpc(154119, "[Fishing Shop]{nl}Joha's Tackle Box", "c_orsha", 617.4446, 77.70792, 5, "FISHING_SUB_ORSHA_NPC");
		
		// [Kingdom Reconstruction] Orsha Officer
		//-------------------------------------------------------------------------
		AddNpc(151093, "[Kingdom Reconstruction] Orsha Officer", "c_orsha", -957.3541, 262.489, -34, "EP13_WEEK_REPUTATION_01");
		
		// [Clown Master]{nl}Jorick Show
		//-------------------------------------------------------------------------
		AddNpc(160054, "[Clown Master]{nl}Jorick Show", "c_orsha", -858.8137, -118.8935, 75, "CLO_MASTER");
		
		// [Arquebusier Master]{nl}Rudmila
		//-------------------------------------------------------------------------
		AddNpc(160053, "[Arquebusier Master]{nl}Rudmila", "c_orsha", -476.0047, 632.4641, 267, "ARQ_MASTER");
		
		// [Sage Master]{nl}Rhupas Kehel
		//-------------------------------------------------------------------------
		AddNpc(153171, "[Sage Master]{nl}Rhupas Kehel", "c_orsha", -947.8719, 46.73744, 90, "SAGE_MASTER");
		
		// Rimantas
		//-------------------------------------------------------------------------
		AddNpc(20063, "Rimantas", "c_orsha", -973, -227, 45, "CHAR119_MSTEP3_3_1_NPC");
		
		// [Professional Alchemist]{nl}Heecia
		//-------------------------------------------------------------------------
		AddNpc(20190, "[Professional Alchemist]{nl}Heecia", "c_orsha", 541.2324, -4.147208, -1, "ALCHEIST_EXPERT_NPC_ORSHA");
		
		// [Kingdom Reconstruction] Notice Board
		//-------------------------------------------------------------------------
		AddNpc(157106, "[Kingdom Reconstruction] Notice Board", "c_orsha", -1006.898, 134.1435, 103, "REPUTATION_QUEST_BOARD_01");
		
		// Nervous Lady
		//-------------------------------------------------------------------------
		AddNpc(151080, "Nervous Lady", "c_orsha", -651.4844, -167.9132, 91, "THREECMLAKE_84_HIDDEN_MADAM");
		
		// Unknown Sanctuary Gate
		//-------------------------------------------------------------------------
		AddNpc(155174, "Unknown Sanctuary Gate", "c_orsha", 295.3502, 353.3213, 34, "UNKNOWN_SANTUARY_GATE_GUILD");
		
		// [Bounty Hunt]{nl}Wanted Board
		//-------------------------------------------------------------------------
		AddNpc(9000001, "[Bounty Hunt]{nl}Wanted Board", "c_orsha", -916.4008, 192.9173, -34, "BOUNTY_HUNT_START");
		
		// Goddess Ingredient Exchange Helper 
		//-------------------------------------------------------------------------
		AddNpc(151042, "Goddess Ingredient Exchange Helper ", "c_orsha", -249.7329, 415.7246, 90, "EP13CARE_TRADE");
		
		// [Hwarang Master]{nl}Saraham
		//-------------------------------------------------------------------------
		AddNpc(150291, "[Hwarang Master]{nl}Saraham", "c_orsha", 1301.351, 381.7126, -18, "MASTER_HWARANG_NPC");
		
		// Illusion of the Girl
		//-------------------------------------------------------------------------
		AddNpc(150238, "Illusion of the Girl", "c_orsha", 1409.725, 351.7238, 90, "EP14_MULIA_NPC_3");
		
		// Orsha Port Entry Officer
		//-------------------------------------------------------------------------
		AddNpc(151078, "Orsha Port Entry Officer", "c_orsha", 1352.843, 331.6997, 98, "EP14_F_CORAL_RAID_1_NPC_1");
		
		// Goddess' Blessing
		//-------------------------------------------------------------------------
		AddNpc(160121, "Goddess' Blessing", "c_orsha", 156.9937, -4.809603, 200, "BLESSED_CUBE");
		
		// [Skill Transmutation Helper]{nl}Kupole
		//-------------------------------------------------------------------------
		AddNpc(160088, "[Skill Transmutation Helper]{nl}Kupole", "c_orsha", 549.3414, 576.8683, -25, "DUCTILITY_NPC");
		
		// TOS Coin Helper
		//-------------------------------------------------------------------------
		AddNpc(160157, "TOS Coin Helper", "c_orsha", 184, 246, 90, "EVENT_TOS_WHOLE_NPC");
		
		// [Engineer Master]{nl}Margaret Ineija
		//-------------------------------------------------------------------------
		AddNpc(160170, "[Engineer Master]{nl}Margaret Ineija", "c_orsha", -1381, -780, 90, "MASTER_ENG_NPC");
	}
}
