//--- Melia Script ----------------------------------------------------------
// Demon Prison District 4
//--- Description -----------------------------------------------------------
// NPCs found in and around Demon Prison District 4.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DVelniasprison513NpcScript : GeneralScript
{
	public override void Load()
	{
		// Kupole Daiva
		//-------------------------------------------------------------------------
		AddNpc(154013, "Kupole Daiva", "d_velniasprison_51_3", -3158.28, -653.9012, 90, "VPRISON513_MQ_DAIVA_01");
		
		// Kupole Daiva
		//-------------------------------------------------------------------------
		AddNpc(154013, "Kupole Daiva", "d_velniasprison_51_3", -1382.819, 940.3401, 90, "VPRISON513_MQ_DAIVA_02");
		
		// Kupole Sigita
		//-------------------------------------------------------------------------
		AddNpc(154012, "Kupole Sigita", "d_velniasprison_51_3", 1307.429, 916.9585, 269, "VPRISON513_MQ_SIGITA");
		
		// Demon Prison District 3
		//-------------------------------------------------------------------------
		AddNpc(154000, "Demon Prison District 3", "d_velniasprison_51_3", -3317, -807, 90, "VELNIASP513_TO_VELNIASP514");
		
		// Demon Prison District 5
		//-------------------------------------------------------------------------
		AddNpc(154000, "Demon Prison District 5", "d_velniasprison_51_3", 2867, -751, 90, "VELNIASP513_TO_VELNIASP515");
		
		// Demon Lord Hauberk
		//-------------------------------------------------------------------------
		AddNpc(57840, "Demon Lord Hauberk", "d_velniasprison_51_3", -2517.733, -400.7579, 171, "", "VPRISON513_MQ_01_NPC", "");
		
		// Kupole Daiva
		//-------------------------------------------------------------------------
		AddNpc(154013, "Kupole Daiva", "d_velniasprison_51_3", 1154.901, 969.0727, 90, "VPRISON513_MQ_DAIVA_03");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "d_velniasprison_51_3", 1736.33, -1242.48, 90, "TREASUREBOX_LV_D_VELNIASPRISON_51_317");
	}
}
