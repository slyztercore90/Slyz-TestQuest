//--- Melia Script ----------------------------------------------------------
// Klaipeda
//--- Description -----------------------------------------------------------
// NPCs found in and around Klaipeda.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class CKlaipeNpcScript : GeneralScript
{
	public override void Load()
	{
		// [Item Merchant]{nl}Mirina
		//-------------------------------------------------------------------------
		AddNpc(20115, "[Item Merchant]{nl}Mirina", "c_Klaipe", 510.7029, -349.3194, 90, "EMILIA");
		
		// [Equipment Merchant]{nl}Dunkel
		//-------------------------------------------------------------------------
		AddNpc(20111, "[Equipment Merchant]{nl}Dunkel", "c_Klaipe", 394, -475, 90, "AKALABETH");
		
		// [Accessory Merchant]{nl}Ronesa
		//-------------------------------------------------------------------------
		AddNpc(20104, "[Accessory Merchant]{nl}Ronesa", "c_Klaipe", 268.7077, -610.9401, 90, "ALFONSO", "ADDHELP_NPCSHOP");
		
		// [Templar Master]{nl}Knight Commander Uska
		//-------------------------------------------------------------------------
		AddNpc(20113, "[Templar Master]{nl}Knight Commander Uska", "c_Klaipe", -474, 82, 405, "KLAPEDA_USKA");
		
		// [Cleric Master]{nl}Rozalija
		//-------------------------------------------------------------------------
		AddNpc(20112, "[Cleric Master]{nl}Rozalija", "c_Klaipe", -409, 174, 405, "MASTER_CLERIC");
		
		// Klaipeda Resident
		//-------------------------------------------------------------------------
		AddNpc(20158, "Klaipeda Resident", "c_Klaipe", -9, 131, 22, "ACT_VILLAGERS");
		
		// Mother of a Soldier
		//-------------------------------------------------------------------------
		AddNpc(20114, "Mother of a Soldier", "c_Klaipe", -60, 42, 82, "ACT_SMOM");
		
		// [Priest Master]{nl}Boruble
		//-------------------------------------------------------------------------
		AddNpc(57229, "[Priest Master]{nl}Boruble", "c_Klaipe", -196.47, 350.73, 0, "MASTER_PRIEST");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(40090, "Bulletin Board", "c_Klaipe", -80, 387, 30, "KLAPEDA_SIGN9");
		
		// [Blacksmith]{nl}Zaras
		//-------------------------------------------------------------------------
		AddNpc(20105, "[Blacksmith]{nl}Zaras", "c_Klaipe", 600, -83, 90, "BLACKSMITH", "TUTO_REPAIR_NPC");
		
		// [Krivis Master]{nl}Herkus
		//-------------------------------------------------------------------------
		AddNpc(57228, "[Krivis Master]{nl}Herkus", "c_Klaipe", -1108, 512, 405, "MASTER_KRIWI");
		
		// Indifferent Widow
		//-------------------------------------------------------------------------
		AddNpc(20114, "Indifferent Widow", "c_Klaipe", -409, -647, -2, "TUTO_GIRL");
		
		// Refugee
		//-------------------------------------------------------------------------
		AddNpc(20139, "Refugee", "c_Klaipe", -60, -446, 12, "KLAPEDA_NPC_14");
		
		// [Market Manager]{nl}Logi
		//-------------------------------------------------------------------------
		AddNpc(20169, "[Market Manager]{nl}Logi", "c_Klaipe", 254.7493, 225.7428, 90, "KLAPEDA_MARKET", "TUTO_MARKET_NPC");
		
		// [Peltasta Master]{nl}Maria Leed
		//-------------------------------------------------------------------------
		AddNpc(20028, "[Peltasta Master]{nl}Maria Leed", "c_Klaipe", -225, -385, -10, "MASTER_PELTASTA");
		
		// [Cryomancer Master]{nl}Aleister Crowley
		//-------------------------------------------------------------------------
		AddNpc(20137, "[Cryomancer Master]{nl}Aleister Crowley", "c_Klaipe", -205, -515, 96, "MASTER_ICEMAGE");
		
		// [Quarrel Shooter Master]{nl}Ream Toiler
		//-------------------------------------------------------------------------
		AddNpc(147445, "[Quarrel Shooter Master]{nl}Ream Toiler", "c_Klaipe", -236, 867, 315, "MASTER_QU");
		
		// [Ranger Master]{nl}Nemoken
		//-------------------------------------------------------------------------
		AddNpc(147343, "[Ranger Master]{nl}Nemoken", "c_Klaipe", -488.78, 27, 96, "MASTER_RANGER");
		
		// [Swordsman Master]{nl}Rashua
		//-------------------------------------------------------------------------
		AddNpc(20023, "[Swordsman Master]{nl}Rashua", "c_Klaipe", -92, 784, 315, "MASTER_SWORDMAN");
		
		// [Wizard Master]{nl}Lucia
		//-------------------------------------------------------------------------
		AddNpc(20021, "[Wizard Master]{nl}Lucia", "c_Klaipe", -100, -275, 0, "MASTER_WIZARD");
		
		// [Archer Master]{nl}Edmundas Tiller
		//-------------------------------------------------------------------------
		AddNpc(147447, "[Archer Master]{nl}Edmundas Tiller", "c_Klaipe", -909.2549, 266.0488, 405, "MASTER_ARCHER");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(40070, "Bulletin Board", "c_Klaipe", -66, -752, -2, "KLAPEDA_SIGN30");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(40070, "Bulletin Board", "c_Klaipe", 195, -641, 12, "KLAPEDA_SIGN31");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(40070, "Bulletin Board", "c_Klaipe", 58, -359, 34, "KLAPEDA_SIGN32");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(40070, "Bulletin Board", "c_Klaipe", -63, -108, 83, "KLAPEDA_SIGN33");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(40070, "Bulletin Board", "c_Klaipe", -165, -958, 64, "KLAPEDA_SIGN_WELCOME");
		
		// Signboard
		//-------------------------------------------------------------------------
		AddNpc(40070, "Signboard", "c_Klaipe", 744, 192, -36, "KLAPEDA_SIGN35");
		
		// About the Goddess Statue
		//-------------------------------------------------------------------------
		AddNpc(40070, "About the Goddess Statue", "c_Klaipe", -125, -11, 42, "KLAPEDA_SIGN36");
		
		// Holiday Notice
		//-------------------------------------------------------------------------
		AddNpc(40070, "Holiday Notice", "c_Klaipe", 617, 61, 90, "KLAPEDA_BOARD_01");
		
		// Lyliana
		//-------------------------------------------------------------------------
		AddNpc(147473, "Lyliana", "c_Klaipe", 615.23, 132.44, 90, "HUEVILLAGE_58_3_KLAIPEDA_NPC");
		
		// [Companion Trader]{nl}Christina
		//-------------------------------------------------------------------------
		AddNpc(153005, "[Companion Trader]{nl}Christina", "c_Klaipe", 6, -760, 360, "PETSHOP_KLAIPE");
		
		// Velheider
		//-------------------------------------------------------------------------
		AddNpc(47521, "Velheider", "c_Klaipe", -22, -757, 360, "PETSHOP_KLAIPE_PET");
		
		// [Wings of Vaivora]{nl}Lena
		//-------------------------------------------------------------------------
		AddNpc(152005, "[Wings of Vaivora]{nl}Lena", "c_Klaipe", 68.44363, 485.8954, -14, "JOURNEY_SHOP", "TUTO_JOURNAL_NPC");
		
		// [Klaipeda's Magic Association]{nl}Henrika
		//-------------------------------------------------------------------------
		AddNpc(152004, "[Klaipeda's Magic Association]{nl}Henrika", "c_Klaipe", -292, 291, 405, "COLLECTION_SHOP");
		
		// Gytis Settlement Area
		//-------------------------------------------------------------------------
		AddNpc(40001, "Gytis Settlement Area", "c_Klaipe", 240.6537, 895.663, 154, "", "KLAPEDA_TO_SIAUL50_1", "");
		
		// [Storage Keeper]{nl}Rita
		//-------------------------------------------------------------------------
		AddNpc(154018, "[Storage Keeper]{nl}Rita", "c_Klaipe", 307.8934, 298.521, 90, "WAREHOUSE", "TUTO_STORAGE_NPC");
		
		// [Oracle Master]{nl}Apolonija Barbora
		//-------------------------------------------------------------------------
		AddNpc(57224, "[Oracle Master]{nl}Apolonija Barbora", "c_Klaipe", -900.4363, 233.7942, 74, "MASTER_ORACLE");
		
		// Statue of Goddess Ausrine
		//-------------------------------------------------------------------------
		AddNpc(154039, "Statue of Goddess Ausrine", "c_Klaipe", -206.574, 98.63973, 45, "WARP_C_KLAIPE", "STOUP_CAMP", "STOUP_CAMP");
		
		// [TP Trader]{nl}Leticia
		//-------------------------------------------------------------------------
		AddNpc(20068, "[TP Trader]{nl}Leticia", "c_Klaipe", 282.7217, 148.8087, 90, "TP_NPC", "TUTO_TPSHOP_NPC");
		
		// Mercenary Post Manager Rota
		//-------------------------------------------------------------------------
		AddNpc(151037, "Mercenary Post Manager Rota", "c_Klaipe", -562.1796, 872.9383, 405, "FEDIMIAN_ROTA_02");
		
		// Receptionist Ramda
		//-------------------------------------------------------------------------
		AddNpc(147484, "Receptionist Ramda", "c_Klaipe", -604.8451, 851.9891, 77, "MISSIONSHOP_NPC_01");
		
		// Receptionist Liam
		//-------------------------------------------------------------------------
		AddNpc(154054, "Receptionist Liam", "c_Klaipe", -435.3569, 895.4382, 360, "PARTYQUEST_NPC_01");
		
		// Receptionist Donnes
		//-------------------------------------------------------------------------
		AddNpc(151039, "Receptionist Donnes", "c_Klaipe", -464.8736, 885.3188, 12, "DROPITEM_REQUEST1_NPC");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(47248, "", "c_Klaipe", -77.60321, -142.1835, 90, "KLAPEDA_FISHING_CAT", "KLAPEDA_FISHING_CAT");
		
		// Enter Challenge Mode Auto Match
		//-------------------------------------------------------------------------
		AddNpc(147507, "Enter Challenge Mode Auto Match", "c_Klaipe", -391, 894, 90, "AUTO_CAHLLENGE_ENTER");
		
		// Selphie
		//-------------------------------------------------------------------------
		AddNpc(147473, "Selphie", "c_Klaipe", -605.3381, -479.0974, -3, "LOWLV_GREEN_SELPHUI");
		
		// Baron Munchausen
		//-------------------------------------------------------------------------
		AddNpc(155017, "Baron Munchausen", "c_Klaipe", -932.2205, 363.2987, 405, "LOWLV_BOASTER_MUENCHHAUSEN");
		
		// Fishing Spot Notice Board
		//-------------------------------------------------------------------------
		AddNpc(150008, "Fishing Spot Notice Board", "c_Klaipe", -645, 694, 45, "KLAPEDA_FISHING_BOARD");
		
		// [Fishing Manager]{nl}Joha
		//-------------------------------------------------------------------------
		AddNpc(147517, "[Fishing Manager]{nl}Joha", "c_Klaipe", -616, 723, 45, "KLAPEDA_FISHING_MANAGER");
		
		// Team Battle League{nl}Valis
		//-------------------------------------------------------------------------
		AddNpc(158000, "Team Battle League{nl}Valis", "c_Klaipe", -389.748, 605.1042, 90, "WORLDPVP_START");
		
		// Rima
		//-------------------------------------------------------------------------
		AddNpc(20148, "Rima", "c_Klaipe", 519.8436, 326.1438, 90, "CHAR119_MSTEP3_4_NPC");
		
		// Sentinel Rian
		//-------------------------------------------------------------------------
		AddNpc(147410, "Sentinel Rian", "c_Klaipe", -321.1135, 896.6875, 0, "INSTANCE_DUNGEON");
		
		// [Onmyoji Master]{nl}Ahiro Seimei
		//-------------------------------------------------------------------------
		AddNpc(153203, "[Onmyoji Master]{nl}Ahiro Seimei", "c_Klaipe", -589, -161, 90, "ONMYOJI_MASTER");
		
		// [Kedora Alliance]{nl}Geraldasia
		//-------------------------------------------------------------------------
		AddNpc(157056, "[Kedora Alliance]{nl}Geraldasia", "c_Klaipe", -384.9556, 1045.116, 0, "NPC_JUNK_SHOP_KLAPEDA");
		
		// Beauty Shop
		//-------------------------------------------------------------------------
		AddNpc(40001, "Beauty Shop", "c_Klaipe", -1046.133, 689.0533, 242, "BEAUTY_IN_MOVE", "BEAUTY_IN_MOVE");
		
		// Class Tree Change Helper
		//-------------------------------------------------------------------------
		AddNpc(151042, "Class Tree Change Helper", "c_Klaipe", -435, -144, 180, "CTRLTYPE_RESET_NPC");
		
		// [Scout Master]{nl}Recon Rimgaile
		//-------------------------------------------------------------------------
		AddNpc(57234, "[Scout Master]{nl}Recon Rimgaile", "c_Klaipe", -916.7286, 138.8984, 90, "JOB_SCOUT3_1_NPC");
		
		// [Professional Alchemist]{nl}Abelu
		//-------------------------------------------------------------------------
		AddNpc(20190, "[Professional Alchemist]{nl}Abelu", "c_Klaipe", -125.7215, -308.4914, 84, "ALCHEIST_EXPERT_NPC_KLAPEDA");
		
		// Housing Helper Kupole
		//-------------------------------------------------------------------------
		AddNpc(154125, "Housing Helper Kupole", "c_Klaipe", -267.7074, -723.6546, 4, "NPC_PERSONAL_HOUSING_MANAGER");
		
		// [Event] Goddess Roulette
		//-------------------------------------------------------------------------
		AddNpc(20026, "[Event] Goddess Roulette", "c_Klaipe", -664, 576, 45, "EVENT_GODDESS_ROULETTE_NPC");
		
		// [Demon God's Temptation]{nl}Illusion of Demon God Ragana
		//-------------------------------------------------------------------------
		AddNpc(154130, "[Demon God's Temptation]{nl}Illusion of Demon God Ragana", "c_Klaipe", 411.4446, 208.2908, 16, "SHOP_NPC_RAGANA_CITY_1");
		
		// [Kingdom Reconstruction] Notice Board
		//-------------------------------------------------------------------------
		AddNpc(157106, "[Kingdom Reconstruction] Notice Board", "c_Klaipe", 67.48899, -10.15458, 225, "REPUTATION_QUEST_BOARD_01");
		
		// Mysterious Storyteller
		//-------------------------------------------------------------------------
		AddNpc(150256, "Mysterious Storyteller", "c_Klaipe", 118.7831, 93.82877, -32, "TOSHERO_TUTO_NPC_01");
		
		// Unknown Sanctuary Gate
		//-------------------------------------------------------------------------
		AddNpc(155174, "Unknown Sanctuary Gate", "c_Klaipe", -510.5378, 68.49586, 81, "UNKNOWN_SANTUARY_GATE_GUILD");
		
		// [Bounty Hunt]{nl}Wanted Board
		//-------------------------------------------------------------------------
		AddNpc(9000000, "[Bounty Hunt]{nl}Wanted Board", "c_Klaipe", -526.7698, 908.6937, 90, "BOUNTY_HUNT_START");
		
		// Goddess Ingredient Exchange Helper 
		//-------------------------------------------------------------------------
		AddNpc(151042, "Goddess Ingredient Exchange Helper ", "c_Klaipe", -249.0009, -86.20673, 180, "EP13CARE_TRADE");
		
		// Goddess' Blessing
		//-------------------------------------------------------------------------
		AddNpc(160121, "Goddess' Blessing", "c_Klaipe", 363.902, 287.629, 200, "BLESSED_CUBE");
		
		// [Skill Transmutation Helper]{nl}Kupole
		//-------------------------------------------------------------------------
		AddNpc(160088, "[Skill Transmutation Helper]{nl}Kupole", "c_Klaipe", 294.6426, -20.70284, 90, "DUCTILITY_NPC");
		
		// TOS Coin Helper
		//-------------------------------------------------------------------------
		AddNpc(160157, "TOS Coin Helper", "c_Klaipe", -664, 576, 90, "EVENT_TOS_WHOLE_NPC");
	}
}
