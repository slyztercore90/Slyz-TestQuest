//--- Melia Script ----------------------------------------------------------
// Halloween Dungeon - Creepy Klaipeda
//--- Description -----------------------------------------------------------
// NPCs found in and around Halloween Dungeon - Creepy Klaipeda.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DCastleAgarioNpcScript : GeneralScript
{
	public override void Load()
	{
		
		// Scaredy Scarecrow
		//-------------------------------------------------------------------------
		AddNpc(157054, "Scaredy Scarecrow", "d_castle_agario", 337, -438, 47, "AGARIO_DUNGEON_NPC");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(46216, " ", "d_castle_agario", 1546, -404, 90, "AGARIO_MINE_DMG", "AGARIO_MINE_DMG");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(46216, " ", "d_castle_agario", 916, -1075, 90, "AGARIO_MINE_DMG", "AGARIO_MINE_DMG");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(46216, " ", "d_castle_agario", -24, -1210, 90, "AGARIO_MINE_DMG", "AGARIO_MINE_DMG");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(46216, " ", "d_castle_agario", 746, 472, 90, "AGARIO_MINE_DMG", "AGARIO_MINE_DMG");
	}
}
