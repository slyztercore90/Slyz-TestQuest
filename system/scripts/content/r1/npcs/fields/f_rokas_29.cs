//--- Melia Script ----------------------------------------------------------
// Rukas Plateau
//--- Description -----------------------------------------------------------
// NPCs found in and around Rukas Plateau.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FRokas29NpcScript : GeneralScript
{
	public override void Load()
	{
		// Tiltas Valley
		//-------------------------------------------------------------------------
		AddNpc(40001, "Tiltas Valley", "f_rokas_29", 2612, 819, 120, "", "ROKAS29_ROKAS28", "");
		
		// King's Plateau
		//-------------------------------------------------------------------------
		AddNpc(40001, "King's Plateau", "f_rokas_29", -1413, -2079, -62, "", "ROKAS29_ROKAS30", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20041, "", "f_rokas_29", 1561, -923, 90, "", "ROKAS29_INITIATING1_1", "");
		
		// Rexipher
		//-------------------------------------------------------------------------
		AddNpc(47413, "Rexipher", "f_rokas_29", -770, -1564, 90, "ROKAS29_HALF_SUCCESS1", "ROKAS29_HALF_SUCCESS1_1");
		
		// Adventurer Varkis
		//-------------------------------------------------------------------------
		AddNpc(152000, "Adventurer Varkis", "f_rokas_29", 1641.213, 757.5521, 360, "VACYS_LIVE");
		
		// Adventurer's Bag
		//-------------------------------------------------------------------------
		AddNpc(47161, "Adventurer's Bag", "f_rokas_29", 2265, 220, 90, "ROKAS29_BAG");
		
		// Bonfire
		//-------------------------------------------------------------------------
		AddNpc(46011, "Bonfire", "f_rokas_29", 163, 769, 90, "ROKAS29_FIRE");
		
		// Adventurer Varkis' Spirit
		//-------------------------------------------------------------------------
		AddNpc(152000, "Adventurer Varkis' Spirit", "f_rokas_29", 168.59, 792.08, 360, "VACYS_SOUL");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20041, "", "f_rokas_29", 1549, 539, 90, "", "VACYS_LIVE_ENTER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(155026, " ", "f_rokas_29", -1184, 320, 90, "ROKAS29_SLATE1");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(155026, " ", "f_rokas_29", -1746.237, 700.1913, 90, "ROKAS29_SLATE2");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(155026, " ", "f_rokas_29", -792, -567, 90, "ROKAS29_SLATE3");
		
		// Historian Rexipher
		//-------------------------------------------------------------------------
		AddNpc(47413, "Historian Rexipher", "f_rokas_29", 2332, 666, 90, "ROKAS29_MQ_REXITHER1");
		
		// Historian Rexipher
		//-------------------------------------------------------------------------
		AddNpc(47413, "Historian Rexipher", "f_rokas_29", -384.2911, -413.1193, 90, "ROKAS29_MQ_REXITHER6");
		
		// Historian Rexipher
		//-------------------------------------------------------------------------
		AddNpc(47413, "Historian Rexipher", "f_rokas_29", 1080.552, -785.3503, 23, "ROKAS29_MQ_REXITHER2");
		
		// Historian Rexipher
		//-------------------------------------------------------------------------
		AddNpc(47413, "Historian Rexipher", "f_rokas_29", 1764.483, 464.2432, 360, "ROKAS29_MQ_REXITHER3");
		
		// Historian Rexipher
		//-------------------------------------------------------------------------
		AddNpc(47413, "Historian Rexipher", "f_rokas_29", -66.24129, 574.991, 90, "ROKAS29_MQ_REXITHER4");
		
		// Historian Rexipher
		//-------------------------------------------------------------------------
		AddNpc(47413, "Historian Rexipher", "f_rokas_29", -666.3936, 389.6885, 90, "ROKAS29_MQ_REXITHER5");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20026, "", "f_rokas_29", -368.2122, -428.2732, 90, "", "ROKAS29_MQ_REXITHERLOST", "");
		
		// Zachariel's Epitaph
		//-------------------------------------------------------------------------
		AddNpc(153053, "Zachariel's Epitaph", "f_rokas_29", 1073.307, -819.9244, 27, "ROKAS29_MQ_DEVICE1");
		
		// Zachariel's Epitaph
		//-------------------------------------------------------------------------
		AddNpc(153053, "Zachariel's Epitaph", "f_rokas_29", 1343, 311, 27, "ROKAS29_MQ_DEVICE2");
		
		// Zachariel's Epitaph
		//-------------------------------------------------------------------------
		AddNpc(153053, "Zachariel's Epitaph", "f_rokas_29", -680, 360, 27, "ROKAS29_MQ_DEVICE4");
		
		// Zachariel's Epitaph
		//-------------------------------------------------------------------------
		AddNpc(153053, "Zachariel's Epitaph", "f_rokas_29", -332, -398, 27, "ROKAS29_MQ_DEVICE5");
		
		// Mullers Passage
		//-------------------------------------------------------------------------
		AddNpc(40001, "Mullers Passage", "f_rokas_29", -2114, 1614, 180, "", "ROKAS29_PCATACOMB1", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "f_rokas_29", 1114.74, -1202.02, 90, "TREASUREBOX_LV_F_ROKAS_29654");
	}
}
