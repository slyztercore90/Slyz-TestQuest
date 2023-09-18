//--- Melia Script ----------------------------------------------------------
// Balaam Camp Site
//--- Description -----------------------------------------------------------
// NPCs found in and around Balaam Camp Site.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DCatacomb802NpcScript : GeneralScript
{
	public override void Load()
	{
		// Magic Stone Enhancer
		//-------------------------------------------------------------------------
		AddNpc(153137, "Magic Stone Enhancer", "d_catacomb_80_2", 979.8, -772.57, 90, "CATACOMB_80_1_CRYSTAL");
		
		// Magic Stone Enhancer
		//-------------------------------------------------------------------------
		AddNpc(153137, "Magic Stone Enhancer", "d_catacomb_80_2", -633, -786.33, 90, "CATACOMB_80_1_CRYSTAL");
		
		// Magic Stone Enhancer
		//-------------------------------------------------------------------------
		AddNpc(153137, "Magic Stone Enhancer", "d_catacomb_80_2", -1502.7, 1141.8, 90, "CATACOMB_80_1_CRYSTAL");
		
		// Magic Stone Enhancer
		//-------------------------------------------------------------------------
		AddNpc(153137, "Magic Stone Enhancer", "d_catacomb_80_2", 1757.39, 1132.05, 90, "CATACOMB_80_1_CRYSTAL");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154000, " ", "d_catacomb_80_2", 1748.07, -918.5, 90, "", "CATACOMB_80_2_HEAL", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154000, " ", "d_catacomb_80_2", 931.64, 1021.31, 90, "", "CATACOMB_80_2_HEAL", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154000, " ", "d_catacomb_80_2", -799.79, 1011.68, 90, "", "CATACOMB_80_2_HEAL", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154000, " ", "d_catacomb_80_2", -1668.39, -918.99, 90, "", "CATACOMB_80_2_HEAL", "");
		
		// Rancid Labyrinth
		//-------------------------------------------------------------------------
		AddNpc(147507, "Rancid Labyrinth", "d_catacomb_80_2", 35.08328, -2316.688, -5, "CATACOMB_80_2_TO_CATACOMB_80_1");
		
		// Michmas Temple
		//-------------------------------------------------------------------------
		AddNpc(147507, "Michmas Temple", "d_catacomb_80_2", -521.4592, -1668.701, -87, "CATACOMB_80_2_TO_CATACOMB_80_3");
	}
}
