//--- Melia Script ----------------------------------------------------------
// Path of Desition
//--- Description -----------------------------------------------------------
// NPCs found in and around Path of Desition.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FDcapital104NpcScript : GeneralScript
{
	public override void Load()
	{
		// Rinksmas Ruins
		//-------------------------------------------------------------------------
		AddNpc(40001, "Rinksmas Ruins", "f_dcapital_104", 1795.006, -2063.198, 80, "", "WARP_DCAPITAL104_TO_DCAPITAL53_1", "");
		
		// Goddess Laima
		//-------------------------------------------------------------------------
		AddNpc(154040, "Goddess Laima", "f_dcapital_104", 624.5918, 1983.782, 13, "EP12_FINALE_RAIMA02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20042, " ", "f_dcapital_104", 219, 181, 90, "", "EP12_FINALE_DIRECTION_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154067, " ", "f_dcapital_104", -612.4031, 212.3094, 90, "", "EP12_FINALE_MQ_03_OBJECT01", "EP12_FINALE_MQ_03_OBJECT01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154067, " ", "f_dcapital_104", -18.549, 753.7501, 90, "", "EP12_FINALE_MQ_03_OBJECT02", "EP12_FINALE_MQ_03_OBJECT02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154067, " ", "f_dcapital_104", 1026.035, 167.5896, 90, "", "EP12_FINALE_MQ_03_OBJECT03", "EP12_FINALE_MQ_03_OBJECT03");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154067, " ", "f_dcapital_104", 589.715, -416.876, 90, "", "EP12_FINALE_MQ_03_OBJECT04", "EP12_FINALE_MQ_03_OBJECT04");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(150227, "", "f_dcapital_104", 223.04, 271.37, 0, "EP12_FINALE_RAIMA01");
		
		// Sacred Atspalvis 
		//-------------------------------------------------------------------------
		AddNpc(40001, "Sacred Atspalvis ", "f_dcapital_104", 742.0436, 1998.778, 17, "", "WARP_DCAPITAL104_TO_F_DCAPITAL_101", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "f_dcapital_104", 666.7079, 2016.974, 90, "", "EXPLORER_MISLE37", "");
	}
}
