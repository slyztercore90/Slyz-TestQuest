//--- Melia Script ----------------------------------------------------------
// Halloween Dungeon - Creepy Klaipeda
//--- Description -----------------------------------------------------------
// NPCs found in and around Halloween Dungeon - Creepy Klaipeda.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class CKlaipeEventNpcScript : GeneralScript
{
	public override void Load()
	{
		
		// Scaredy Scarecrow
		//-------------------------------------------------------------------------
		AddNpc(157054, "Scaredy Scarecrow", "c_Klaipe_event", -206.5314, 94.02247, 47, "AGARIO_DUNGEON_NPC");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(46216, " ", "c_Klaipe_event", -840.4724, 84.85162, 90, "AGARIO_MINE_DMG", "AGARIO_MINE_DMG");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(46216, " ", "c_Klaipe_event", -162.4379, -803.4096, 90, "AGARIO_MINE_DMG", "AGARIO_MINE_DMG");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(46216, " ", "c_Klaipe_event", 669.4443, 133.3863, 90, "AGARIO_MINE_DMG", "AGARIO_MINE_DMG");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(46216, " ", "c_Klaipe_event", -235.9899, 819.2154, 90, "AGARIO_MINE_DMG", "AGARIO_MINE_DMG");
	}
}
