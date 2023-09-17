//--- Melia Script ----------------------------------------------------------
// Residence of the Fallen Legwyn Family
//--- Description -----------------------------------------------------------
// NPCs found in and around Residence of the Fallen Legwyn Family.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DStartower601NpcScript : GeneralScript
{
	public override void Load()
	{
		// Astral Assistance
		//-------------------------------------------------------------------------
		AddNpc(151043, "Astral Assistance", "d_startower_60_1", -926.8743, -1228.377, 90, "STARTOWER_60_1_SYSTEM_01");
		
		// Astral Protection
		//-------------------------------------------------------------------------
		AddNpc(151043, "Astral Protection", "d_startower_60_1", 142.3433, -297.3275, 45, "STARTOWER_60_1_SYSTEM_02");
		
		// Astral Blessing
		//-------------------------------------------------------------------------
		AddNpc(151043, "Astral Blessing", "d_startower_60_1", 1470.958, -1229.48, 45, "STARTOWER_60_1_SYSTEM_03");
		
		// Astral Tower Assistance Device
		//-------------------------------------------------------------------------
		AddNpc(151044, "Astral Tower Assistance Device", "d_startower_60_1", -936.3505, -275.3196, 90, "", "STARTOWER_60_1_GUARDIAN_NPC", "");
		
		// Astral Protector Statue
		//-------------------------------------------------------------------------
		AddNpc(153017, "Astral Protector Statue", "d_startower_60_1", -105.6555, 621.4272, 90, "STARTOWER_60_1_STORNSTATUE");
		
		// Astral Protector Statue
		//-------------------------------------------------------------------------
		AddNpc(153017, "Astral Protector Statue", "d_startower_60_1", -105.536, 876.3533, 90, "STARTOWER_60_1_STORNSTATUE");
		
		// Astral Protector Statue
		//-------------------------------------------------------------------------
		AddNpc(153017, "Astral Protector Statue", "d_startower_60_1", 412.9784, 616.2069, 270, "STARTOWER_60_1_STORNSTATUE");
		
		// Astral Protector Statue
		//-------------------------------------------------------------------------
		AddNpc(153017, "Astral Protector Statue", "d_startower_60_1", 412.9004, 871.7554, 270, "STARTOWER_60_1_STORNSTATUE");
		
		// Candlestick
		//-------------------------------------------------------------------------
		AddNpc(151047, "Candlestick", "d_startower_60_1", 2024.567, -1779.329, 90, "STARTOWER_60_1_CANDLESTICK");
		
		// Candlestick
		//-------------------------------------------------------------------------
		AddNpc(151047, "Candlestick", "d_startower_60_1", 2017.142, -1421.79, 90, "STARTOWER_60_1_CANDLESTICK");
		
		// Candlestick
		//-------------------------------------------------------------------------
		AddNpc(151047, "Candlestick", "d_startower_60_1", 2025.221, -1067.645, 90, "STARTOWER_60_1_CANDLESTICK");
		
		// Candlestick
		//-------------------------------------------------------------------------
		AddNpc(151047, "Candlestick", "d_startower_60_1", 2022.423, -702.0853, 90, "STARTOWER_60_1_CANDLESTICK");
		
		// Anti-gravity Magic Circle
		//-------------------------------------------------------------------------
		AddNpc(147500, "Anti-gravity Magic Circle", "d_startower_60_1", -1875.505, 1132.613, 0, "", "STARTOWER_60_1_REVERSEGRAVITY", "");
		
		// Mysterious Box of Legwyn Family
		//-------------------------------------------------------------------------
		AddNpc(147392, "Mysterious Box of Legwyn Family", "d_startower_60_1", -229.3618, 1267.745, 270, "STARTOWER_60_1_DAILY_BOX");
		
		// Magic Astral Lamp
		//-------------------------------------------------------------------------
		AddNpc(151045, "Magic Astral Lamp", "d_startower_60_1", 1786.096, -450.3302, 90, "", "STARTOWER_60_1_STARLAMP", "");
		
		// Giant Star Stone
		//-------------------------------------------------------------------------
		AddNpc(151046, "Giant Star Stone", "d_startower_60_1", 1728.265, 734.7443, 0, "STARTOWER_60_1_STARSTORN_01");
		
		// Forest of Prayer
		//-------------------------------------------------------------------------
		AddNpc(40001, "Forest of Prayer", "d_startower_60_1", -81.22099, -2128.663, 270, "", "STOWERTOWER_60_1_TO_PILGRIMROAD_51", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "d_startower_60_1", -28.21613, -2381.822, 90, "WARP_D_STARTOWER_60_1", "STOUP_CAMP", "STOUP_CAMP");
		
		// Adventurer's Journal
		//-------------------------------------------------------------------------
		AddNpc(153014, "Adventurer's Journal", "d_startower_60_1", -1297.08, -102.2516, 90, "STARTOWER_60_1_MEMO_01");
		
		// Beikeol's Reply
		//-------------------------------------------------------------------------
		AddNpc(147312, "Beikeol's Reply", "d_startower_60_1", -864.1365, 1326.797, 90, "STARTOWER_60_1_MEMO_02");
		
		// Purchase Order
		//-------------------------------------------------------------------------
		AddNpc(147312, "Purchase Order", "d_startower_60_1", 1219.117, -484.075, 90, "STARTOWER_60_1_MEMO_03");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "d_startower_60_1", 265, 1427, 90, "TREASUREBOX_LV_D_STARTOWER_60_127");
		
		// JOB_MIKO_6_1_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(20026, "JOB_MIKO_6_1_TRIGGER", "d_startower_60_1", 1730.769, 352.867, 90, "JOB_MIKO_6_1_STOWER_60_1");
	}
}
