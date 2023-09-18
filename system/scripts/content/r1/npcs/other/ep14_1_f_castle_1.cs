//--- Melia Script ----------------------------------------------------------
// Delmore Hamlet
//--- Description -----------------------------------------------------------
// NPCs found in and around Delmore Hamlet.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class Ep141FCastle1NpcScript : GeneralScript
{
	public override void Load()
	{
		// [Centurion Master] Krajicek
		//-------------------------------------------------------------------------
		AddNpc(147326, "[Centurion Master] Krajicek", "ep14_1_f_castle_1", 980.5783, -614.608, 90, "EP14_1_F_CASTLE_1_NPC1");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "ep14_1_f_castle_1", 1171.715, -641.6, 90, "", "EP14_1_F_CASTLE_1_NPC2", "");
		
		// Royal Army Guard
		//-------------------------------------------------------------------------
		AddNpc(150290, "Royal Army Guard", "ep14_1_f_castle_1", 1048.73, 491.3686, 90, "EP14_1_FCASTLE1_MQ_2_SOLDIER");
		
		// Royal Army Guard
		//-------------------------------------------------------------------------
		AddNpc(150290, "Royal Army Guard", "ep14_1_f_castle_1", 976.4153, 712.3425, 90, "EP14_1_FCASTLE1_MQ_2_SOLDIER");
		
		// Royal Army Guard
		//-------------------------------------------------------------------------
		AddNpc(150290, "Royal Army Guard", "ep14_1_f_castle_1", 898.5609, 542.6355, 90, "EP14_1_FCASTLE1_MQ_2_SOLDIER");
		
		// Hidden Soldier
		//-------------------------------------------------------------------------
		AddNpc(150294, "Hidden Soldier", "ep14_1_f_castle_1", 1191.024, 1464.596, 27, "EP14_1_FCASTLE1_MQ_3_SOLDIER");
		
		// Hidden Soldier
		//-------------------------------------------------------------------------
		AddNpc(150294, "Hidden Soldier", "ep14_1_f_castle_1", 1364.573, 1263.767, -46, "EP14_1_FCASTLE1_MQ_3_SOLDIER");
		
		// Hidden Soldier
		//-------------------------------------------------------------------------
		AddNpc(150294, "Hidden Soldier", "ep14_1_f_castle_1", 1079.712, 1521.753, -29, "EP14_1_FCASTLE1_MQ_3_SOLDIER");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "ep14_1_f_castle_1", -604.4221, 794.1345, 90, "", "EP14_1_FCASTLE1_MQ_6_HIDDEN", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "ep14_1_f_castle_1", -267.147, -610.9994, 90, "", "EP14_1_FCASTLE1_MQ_7_HIDDEN", "");
		
		// [Centurion Master] Krajicek
		//-------------------------------------------------------------------------
		AddNpc(147326, "[Centurion Master] Krajicek", "ep14_1_f_castle_1", -597.3381, -524.8023, 78, "EP14_1_F_CASTLE_1_NPC3");
		
		// Delmore Manor
		//-------------------------------------------------------------------------
		AddNpc(40001, "Delmore Manor", "ep14_1_f_castle_1", -709.1204, -426.1506, 249, "", "WARP_EP14_1_F_CASTLE_1_TO_EP14_1_F_CASTLE_2", "");
		
		// Kirtimas Forest
		//-------------------------------------------------------------------------
		AddNpc(40001, "Kirtimas Forest", "ep14_1_f_castle_1", 1584.229, -762.3168, 90, "", "WARP_EP14_1_F_CASTLE_1_TO_EP13_F_SIAULIAI_5", "");
		
		// Sage Envoy
		//-------------------------------------------------------------------------
		AddNpc(157100, "Sage Envoy", "ep14_1_f_castle_1", 886.2971, -439.1505, 48, "D_CASTLE_19_1_PORTAL_NPC_01", "D_CASTLE_19_1_PORTAL_NPC_01");
	}
}
