//--- Melia Script ----------------------------------------------------------
// Rancid Labyrinth
//--- Description -----------------------------------------------------------
// NPCs found in and around Rancid Labyrinth.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DCatacomb801NpcScript : GeneralScript
{
	public override void Load()
	{
		// Magic Stone Enhancer
		//-------------------------------------------------------------------------
		AddNpc(153137, "Magic Stone Enhancer", "d_catacomb_80_1", 121.66, -1707.27, 90, "CATACOMB_80_1_CRYSTAL");
		
		// Magic Stone Enhancer
		//-------------------------------------------------------------------------
		AddNpc(153137, "Magic Stone Enhancer", "d_catacomb_80_1", -1005.516, -629.6679, 90, "CATACOMB_80_1_CRYSTAL");
		
		// Magic Stone Enhancer
		//-------------------------------------------------------------------------
		AddNpc(153137, "Magic Stone Enhancer", "d_catacomb_80_1", 958.97, -667.27, 90, "CATACOMB_80_1_CRYSTAL");
		
		// Magic Stone Enhancer
		//-------------------------------------------------------------------------
		AddNpc(153137, "Magic Stone Enhancer", "d_catacomb_80_1", 1063.195, 1557.351, 90, "CATACOMB_80_1_CRYSTAL");
		
		// Magic Stone Enhancer
		//-------------------------------------------------------------------------
		AddNpc(153137, "Magic Stone Enhancer", "d_catacomb_80_1", -1133.47, 1555.81, 90, "CATACOMB_80_1_CRYSTAL");
		
		// Balaam Camp Site
		//-------------------------------------------------------------------------
		AddNpc(147507, "Balaam Camp Site", "d_catacomb_80_1", -32.95918, -1085.865, 176, "CATACOMB_80_1_TO_CATACOMB_80_2");
		
		// Grynas Hills
		//-------------------------------------------------------------------------
		AddNpc(147507, "Grynas Hills", "d_catacomb_80_1", -58.37, -2527.01, 90, "CATACOMB_80_1_TO_KATYN_45_3");
	}
}
