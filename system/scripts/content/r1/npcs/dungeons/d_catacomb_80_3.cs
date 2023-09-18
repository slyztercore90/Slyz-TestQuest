//--- Melia Script ----------------------------------------------------------
// Michmas Temple
//--- Description -----------------------------------------------------------
// NPCs found in and around Michmas Temple.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DCatacomb803NpcScript : GeneralScript
{
	public override void Load()
	{
		// Magic Stone Enhancer
		//-------------------------------------------------------------------------
		AddNpc(153137, "Magic Stone Enhancer", "d_catacomb_80_3", 172.32, -1889.25, 90, "CATACOMB_80_1_CRYSTAL");
		
		// Magic Stone Enhancer
		//-------------------------------------------------------------------------
		AddNpc(153137, "Magic Stone Enhancer", "d_catacomb_80_3", -1282.141, 158.2724, 90, "CATACOMB_80_1_CRYSTAL");
		
		// Magic Stone Enhancer
		//-------------------------------------------------------------------------
		AddNpc(153137, "Magic Stone Enhancer", "d_catacomb_80_3", 832.3134, -143.7363, 90, "CATACOMB_80_1_CRYSTAL");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154000, " ", "d_catacomb_80_3", -16.76, -1903.2, 90, "", "CATACOMB_80_2_HEAL", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154000, " ", "d_catacomb_80_3", 14.65, -942.47, 90, "", "CATACOMB_80_2_HEAL", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154000, " ", "d_catacomb_80_3", -1114.909, -9.433952, 90, "", "CATACOMB_80_2_HEAL", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154000, " ", "d_catacomb_80_3", 1028.68, -54.78, 90, "", "CATACOMB_80_2_HEAL", "");
		
		// Balaam Camp Site
		//-------------------------------------------------------------------------
		AddNpc(147507, "Balaam Camp Site", "d_catacomb_80_3", -958.6116, -2169.41, 219, "CATACOMB_80_3_TO_CATACOMB_80_2");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154000, " ", "d_catacomb_80_3", 15.94859, 922.8054, 90, "", "CATACOMB_80_2_HEAL", "");
	}
}
