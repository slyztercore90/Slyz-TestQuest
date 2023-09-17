//--- Melia Script ----------------------------------------------------------
// Tevhrin Stalactite Cave Section 2
//--- Description -----------------------------------------------------------
// NPCs found in and around Tevhrin Stalactite Cave Section 2.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DLimestonecave522NpcScript : GeneralScript
{
	public override void Load()
	{
		// Tevhrin Stalactite Cave Section 1
		//-------------------------------------------------------------------------
		AddNpc(40001, "Tevhrin Stalactite Cave Section 1", "d_limestonecave_52_2", -1460.944, -1811.588, -18, "", "LIMESTONECAVE_52_2_LIMESTONECAVE_52_1", "");
		
		// Tevhrin Stalactite Cave Section 3
		//-------------------------------------------------------------------------
		AddNpc(40001, "Tevhrin Stalactite Cave Section 3", "d_limestonecave_52_2", 1287.455, -119.2307, 90, "", "LIMESTONECAVE_52_2_LIMESTONECAVE_52_3", "");
		
		// Kupole Alena
		//-------------------------------------------------------------------------
		AddNpc(154015, "Kupole Alena", "d_limestonecave_52_2", -1893.854, 188.0698, 45, "LIMESTONE_52_2_ALLENA");
		
		// Kupole Serija
		//-------------------------------------------------------------------------
		AddNpc(154012, "Kupole Serija", "d_limestonecave_52_2", -689.7747, 1385.901, 27, "LIMESTONE_52_2_SERIJA");
		
		// Kupole Medena
		//-------------------------------------------------------------------------
		AddNpc(154014, "Kupole Medena", "d_limestonecave_52_2", -1584.416, -1512.56, 100, "LIMESTONECAVE_52_2_MEDENA");
		
		// LIMESTONE_52_2_MQ_1_TRIG
		//-------------------------------------------------------------------------
		AddNpc(20026, "LIMESTONE_52_2_MQ_1_TRIG", "d_limestonecave_52_2", -1836.807, 165.6414, 90, "", "LIMESTONE_52_2_MQ_1_PROG", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20046, " ", "d_limestonecave_52_2", -1894.317, 187.7024, 90, "", "LIMESTONE_52_2_DARKWALL", "");
		
		// LIMESTONE_52_2_MQ_3_TRIG
		//-------------------------------------------------------------------------
		AddNpc(20026, "LIMESTONE_52_2_MQ_3_TRIG", "d_limestonecave_52_2", -632.9493, 1367.69, 90, "", "LIMESTONE_52_2_MQ_3_PROG", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20046, " ", "d_limestonecave_52_2", -688.631, 1387.274, 90, "", "LIMESTONE_52_2_DARKWALL_2", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(152056, " ", "d_limestonecave_52_2", -100.401, 684.7335, 90, "LIMESTONE_52_2_EVIL_1", "LIMESTONE_52_2_MQ_3_FAKE_1");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(152056, " ", "d_limestonecave_52_2", -348.2186, 110.8734, 45, "LIMESTONE_52_2_EVIL_2", "LIMESTONE_52_2_MQ_3_FAKE_1");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(152055, " ", "d_limestonecave_52_2", -1009.624, 361.4804, 90, "LIMESTONE_52_2_EVIL_3", "LIMESTONE_52_2_MQ_3_FAKE_2");
		
		// Holy Place of Recover
		//-------------------------------------------------------------------------
		AddNpc(147413, "Holy Place of Recover", "d_limestonecave_52_2", 668.1122, 482.8394, 90, "LIMESTONE_52_2_HEALING");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147358, " ", "d_limestonecave_52_2", 220.9686, 1635.496, 90, "LIMESTONE_52_2_ANTIEVIL");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "d_limestonecave_52_2", -1444.84, -1527.41, 90, "TREASUREBOX_LV_D_LIMESTONECAVE_52_21000");
	}
}
