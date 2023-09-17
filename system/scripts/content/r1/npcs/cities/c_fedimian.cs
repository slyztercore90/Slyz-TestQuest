//--- Melia Script ----------------------------------------------------------
// Fedimian
//--- Description -----------------------------------------------------------
// NPCs found in and around Fedimian.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class CFedimianNpcScript : GeneralScript
{
	public override void Load()
	{
		// Grita
		//-------------------------------------------------------------------------
		AddNpc(147449, "Grita", "c_fedimian", 127, 517, 34, "FEDIMIAN_GRITA");
		
		// [Squire Master]{nl}Justina Legwyn
		//-------------------------------------------------------------------------
		AddNpc(147439, "[Squire Master]{nl}Justina Legwyn", "c_fedimian", 694, 114, 90, "JOB_SQUIRE3_1_NPC");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "c_fedimian", -280, -239, 7, "WARP_C_FEDIMIAN", "STOUP_CAMP", "STOUP_CAMP");
		
		// Fedimian Suburbs
		//-------------------------------------------------------------------------
		AddNpc(40001, "Fedimian Suburbs", "c_fedimian", 782, -160, 80, "", "FEDMIAN_TO_REMAINS40", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20041, "", "c_fedimian", -531, -428, 90, "", "JOB_FEDIMIAN_TRIGGER", "");
		
		// Security Guard
		//-------------------------------------------------------------------------
		AddNpc(20011, "Security Guard", "c_fedimian", -493, -534, 182, "FEDIMIAN_DETECTIVE_GUARD");
		
		// Guard Leaper
		//-------------------------------------------------------------------------
		AddNpc(20013, "Guard Leaper", "c_fedimian", -566, 168, 90, "CRIMINAL", "GHOST_APPEAR");
		
		// Girl
		//-------------------------------------------------------------------------
		AddNpc(20148, "Girl", "c_fedimian", -788, 283, 38, "REMAIN39_SQ03_GIRL");
		
		// [Rogue Master]{nl}Gema
		//-------------------------------------------------------------------------
		AddNpc(57238, "[Rogue Master]{nl}Gema", "c_fedimian", 169, 162.18, 90, "MASTER_ROGUE");
		
		// [Item Merchant]{nl}Muras
		//-------------------------------------------------------------------------
		AddNpc(151034, "[Item Merchant]{nl}Muras", "c_fedimian", -631.32, -174.9, 0, "FED_TOOL");
		
		// [Equipment Merchant]{nl}Yorgis
		//-------------------------------------------------------------------------
		AddNpc(151035, "[Equipment Merchant]{nl}Yorgis", "c_fedimian", -219.15, -558.35, 90, "FED_EQUIP", "FED_EQUIP_HQ_REINFORCE", "FED_EQUIP_HQ_REINFORCE");
		
		// Starving Demon's Way
		//-------------------------------------------------------------------------
		AddNpc(40001, "Starving Demon's Way", "c_fedimian", 846.02, 1136.69, 166, "", "FEDMIAN_PILGRIM46", "");
		
		// Fedimian Public House
		//-------------------------------------------------------------------------
		AddNpc(40001, "Fedimian Public House", "c_fedimian", -844, -100, 180, "", "FEDIMIAN_REQUEST1", "");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(40070, "Bulletin Board", "c_fedimian", 245.72, 398.1, 8, "FEDIMIAN_SIGN1");
		
		// Old Man
		//-------------------------------------------------------------------------
		AddNpc(20165, "Old Man", "c_fedimian", -899.01, 333.52, 34, "FEDIMIAN_OLDMAN1");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(40070, "Bulletin Board", "c_fedimian", 671.12, -84.22, 9, "FEDIMIAN_SIGN2");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(40070, "Bulletin Board", "c_fedimian", -879.49, 87.51, 20, "FEDIMIAN_SIGN3");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(40070, "Bulletin Board", "c_fedimian", 630.71, 1101.49, 19, "FEDIMIAN_SIGN4");
		
		// JOB_ROGUE5_1
		//-------------------------------------------------------------------------
		AddNpc(20026, "JOB_ROGUE5_1", "c_fedimian", -606.66, 63.17, 90, "", "JOB_ROGUE5_1", "");
		
		// [Hackapell Master]{nl}Flint Boulder
		//-------------------------------------------------------------------------
		AddNpc(57232, "[Hackapell Master]{nl}Flint Boulder", "c_fedimian", 366.58, 763.9, 37, "MASTER_HACKAPELL");
		
		// [Druid Master]{nl}Gina Greene
		//-------------------------------------------------------------------------
		AddNpc(57227, "[Druid Master]{nl}Gina Greene", "c_fedimian", 432.94, 808.29, 20, "JOB_DRUID3_1_NPC");
		
		// Fedimian Resident
		//-------------------------------------------------------------------------
		AddNpc(147437, "Fedimian Resident", "c_fedimian", -658, -250, 69, "FEDIMIAN_NPC_11");
		
		// Klaipeda Peddler
		//-------------------------------------------------------------------------
		AddNpc(20114, "Klaipeda Peddler", "c_fedimian", 11, 550, 90, "FEDIMIAN_NPC_12");
		
		// Notice for Pilgrims
		//-------------------------------------------------------------------------
		AddNpc(153020, "Notice for Pilgrims", "c_fedimian", 806.82, 1108.36, 15, "PILGRIM_PRE_BOARD");
		
		// [Doppelsoeldner Master]{nl}Guerra
		//-------------------------------------------------------------------------
		AddNpc(147443, "[Doppelsoeldner Master]{nl}Guerra", "c_fedimian", 220.7, -81.84, 0, "MASTER_DOPPELSOELDNER");
		
		// [Blacksmith]{nl}Anna
		//-------------------------------------------------------------------------
		AddNpc(151036, "[Blacksmith]{nl}Anna", "c_fedimian", 120, -504, 75, "BLACKSMITH_FEDIMIAN");
		
		// [Market Manager]{nl}Molun
		//-------------------------------------------------------------------------
		AddNpc(20171, "[Market Manager]{nl}Molun", "c_fedimian", -391, -266, 0, "MARKET_FEDIMIAN");
		
		// [Storage Keeper]{nl}Zadan
		//-------------------------------------------------------------------------
		AddNpc(156027, "[Storage Keeper]{nl}Zadan", "c_fedimian", -187, -235, 22, "WAREHOUSE_FEDIMIAN");
		
		// [Accessory Merchant]{nl}Joana
		//-------------------------------------------------------------------------
		AddNpc(151038, "[Accessory Merchant]{nl}Joana", "c_fedimian", -130.2, -496.14, 0, "FED_ACCESSORY");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "c_fedimian", 186.81, 855.79, 90, "SHINOBI_POTTER");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "c_fedimian", -735.82, -133.69, 90, "SHINOBI_POTTER");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "c_fedimian", 354.63, 826.61, 99, "SHINOBI_POTTER");
		
		// [TP Trader]{nl}Leticia
		//-------------------------------------------------------------------------
		AddNpc(20068, "[TP Trader]{nl}Leticia", "c_fedimian", 189.8829, -205.7937, 0, "TP_NPC");
		
		// Fedimian Guard
		//-------------------------------------------------------------------------
		AddNpc(10033, "Fedimian Guard", "c_fedimian", -95.84, 605.49, 90, "FEDIMIAN_NPC_TEMPLE04");
		
		// [Identifier]{nl}Sandra
		//-------------------------------------------------------------------------
		AddNpc(157039, "[Identifier]{nl}Sandra", "c_fedimian", -41, -223, 360, "FEDIMIAN_APPRAISER", "TUTO_APPRAISE_NPC");
		
		// Challenge Mode Auto Match Entrance
		//-------------------------------------------------------------------------
		AddNpc(147507, "Challenge Mode Auto Match Entrance", "c_fedimian", -428, -522, 90, "AUTO_CAHLLENGE_ENTER");
		
		// [Appraiser Master]{nl}Sandra
		//-------------------------------------------------------------------------
		AddNpc(157039, "[Appraiser Master]{nl}Sandra", "c_fedimian", -41, -223, 360, "FEDIMIAN_APPRAISER_NPC");
		
		// [Matador Master]{nl}Kridella Otero
		//-------------------------------------------------------------------------
		AddNpc(153194, "[Matador Master]{nl}Kridella Otero", "c_fedimian", 740.2928, 259.6365, 26, "MATADOR_MASTER");
		
		// Adventurer Anastazija
		//-------------------------------------------------------------------------
		AddNpc(155168, "Adventurer Anastazija", "c_fedimian", 406.736, 58.32973, 0, "EXPLORER_ANASTAZIJA");
		
		// Traveling Merchant Geraldas
		//-------------------------------------------------------------------------
		AddNpc(150000, "Traveling Merchant Geraldas", "c_fedimian", -641.1408, -51.47062, 90, "NPC_JUNK_SHOP_FEDIMIAN_ORSHA");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(40070, "Bulletin Board", "c_fedimian", -133.3012, 58.58133, 5, "FEDIMIAN_OFFICIAL_BOARD");
		
		// [Exorcist Master]{nl}Sydow Merrinblock
		//-------------------------------------------------------------------------
		AddNpc(153208, "[Exorcist Master]{nl}Sydow Merrinblock", "c_fedimian", 89.2861, 356.2659, 16, "EXORCIST_MASTER");
		
		// Gintaras
		//-------------------------------------------------------------------------
		AddNpc(20118, "Gintaras", "c_fedimian", 154.9777, 350.6737, 16, "CHAR420_STEP321_NPC");
		
		// Zigmas
		//-------------------------------------------------------------------------
		AddNpc(147483, "Zigmas", "c_fedimian", 154.9777, 350.6737, 16, "CHAR420_STEP323_NPC1");
		
		// [Blacksmith]{nl}Teliavelis
		//-------------------------------------------------------------------------
		AddNpc(161002, "[Blacksmith]{nl}Teliavelis", "c_fedimian", -881.679, -227.4336, 90, "FEDIMIAN_TERIAVELIS", "FEDIMIAN_TERIAVELIS");
		
		// [Outlaw Master]{nl}Maea Kellefinker
		//-------------------------------------------------------------------------
		AddNpc(156157, "[Outlaw Master]{nl}Maea Kellefinker", "c_fedimian", 488.8739, 963.166, 12, "OUTLAW_MASTER_W_NPC");
		
		// [Outlaw Master]{nl}Jazz Kellefinker
		//-------------------------------------------------------------------------
		AddNpc(156156, "[Outlaw Master]{nl}Jazz Kellefinker", "c_fedimian", 446.8587, 926.9231, 151, "OUTLAW_MASTER_M_NPC");
		
		// Pajauta
		//-------------------------------------------------------------------------
		AddNpc(154120, "Pajauta", "c_fedimian", 58.90117, 4.509953, 14, "PAYAUTA_EP11_NPC_CITY_1");
		
		// Sentry Ailee
		//-------------------------------------------------------------------------
		AddNpc(147416, "Sentry Ailee", "c_fedimian", -569.502, -492.7643, 142, "INSTANCE_DUNGEON");
		
		// Housing Helper Kupole
		//-------------------------------------------------------------------------
		AddNpc(154125, "Housing Helper Kupole", "c_fedimian", -629.5562, -430.9118, 90, "NPC_PERSONAL_HOUSING_MANAGER");
		
		// [Event] Goddess Roulette
		//-------------------------------------------------------------------------
		AddNpc(20040, "[Event] Goddess Roulette", "c_fedimian", -284, -346, 45, "EVENT_GODDESS_ROULETTE_NPC");
		
		// [Teliavelis's Disciple]{nl}Naujoves
		//-------------------------------------------------------------------------
		AddNpc(157105, "[Teliavelis's Disciple]{nl}Naujoves", "c_fedimian", -881.4329, -291.846, 87, "FEDIMIAN_NAUJOVES");
		
		// [Demon God's Temptation]{nl}Illusion of Demon God Ragana
		//-------------------------------------------------------------------------
		AddNpc(154130, "[Demon God's Temptation]{nl}Illusion of Demon God Ragana", "c_fedimian", -222.6911, -404.5667, 211, "SHOP_NPC_RAGANA_CITY_1");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(150008, "", "c_fedimian", -275.1527, 665.6674, 2, "KLAPEDA_FISHING_BOARD");
		
		// [Fishing Shop]{nl}Joha's Tackle Box
		//-------------------------------------------------------------------------
		AddNpc(154119, "[Fishing Shop]{nl}Joha's Tackle Box", "c_fedimian", -289.8217, 555.596, 90, "FISHING_SUB_NPC");
		
		// [Kingdom Reconstruction] Notice Board
		//-------------------------------------------------------------------------
		AddNpc(157106, "[Kingdom Reconstruction] Notice Board", "c_fedimian", 90.77071, -298.6885, 188, "REPUTATION_QUEST_BOARD_01");
		
		// [Professional Alchemist]{nl}Quabast
		//-------------------------------------------------------------------------
		AddNpc(20190, "[Professional Alchemist]{nl}Quabast", "c_fedimian", -735.7271, -298.9478, 90, "ALCHEIST_EXPERT_NPC_FEDIMIAN");
		
		// Unknown Sanctuary Gate
		//-------------------------------------------------------------------------
		AddNpc(155174, "Unknown Sanctuary Gate", "c_fedimian", 511.1686, -40.84446, 61, "UNKNOWN_SANTUARY_GATE_GUILD");
		
		// [Bounty Hunt]{nl}Wanted Board
		//-------------------------------------------------------------------------
		AddNpc(9000001, "[Bounty Hunt]{nl}Wanted Board", "c_fedimian", -329.2578, -257.8914, 0, "BOUNTY_HUNT_START");
		
		// Goddess Ingredient Exchange Helper 
		//-------------------------------------------------------------------------
		AddNpc(151042, "Goddess Ingredient Exchange Helper ", "c_fedimian", -305.6815, -460.033, 135, "EP13CARE_TRADE");
		
		// Goddess' Blessing
		//-------------------------------------------------------------------------
		AddNpc(160121, "Goddess' Blessing", "c_fedimian", -150.1284, -213.9672, 200, "BLESSED_CUBE");
		
		// [Skill Transmutation Helper]{nl}Kupole
		//-------------------------------------------------------------------------
		AddNpc(160088, "[Skill Transmutation Helper]{nl}Kupole", "c_fedimian", -528.8466, -144.759, 24, "DUCTILITY_NPC");
		
		// TOS Coin Helper
		//-------------------------------------------------------------------------
		AddNpc(160157, "TOS Coin Helper", "c_fedimian", -284, -346, 90, "EVENT_TOS_WHOLE_NPC");
	}
}
