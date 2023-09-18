//--- Melia Script ----------------------------------------------------------
// Magic Association Assembly Hall
//--- Description -----------------------------------------------------------
// NPCs found in and around Magic Association Assembly Hall.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class Ep142DCastle3NpcScript : GeneralScript
{
	public override void Load()
	{
		// Hidden Passage
		//-------------------------------------------------------------------------
		AddNpc(154065, "Hidden Passage", "ep14_2_d_castle_3", -5.34767, -296.5492, 46, "EP14_2_DCASLTE3_PORTAL");
		
		// Pajauta
		//-------------------------------------------------------------------------
		AddNpc(154120, "Pajauta", "ep14_2_d_castle_3", 53.07189, -308.9152, 4, "EP14_2_DCASTLE3_PAJAUTA");
		
		// [Great Royal General] {nl} Ramin
		//-------------------------------------------------------------------------
		AddNpc(150287, "[Great Royal General] {nl} Ramin", "ep14_2_d_castle_3", -9.226412, -358.7516, 90, "EP14_2_DCASTLE3_RAMIN");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(160129, "", "ep14_2_d_castle_3", 318.3398, -755.0438, 90, "EP14_2_TRPLEHELIX1");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(160129, "", "ep14_2_d_castle_3", -552.3965, -297.7231, 90, "EP14_2_TRPLEHELIX2");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(160129, "", "ep14_2_d_castle_3", 323.9438, 120.5246, 90, "EP14_2_TRPLEHELIX3");
		
		// Temple Border
		//-------------------------------------------------------------------------
		AddNpc(154079, "Temple Border", "ep14_2_d_castle_3", -0.2321453, 379.1339, 3, "EP14_2_DCASTLE3_WALL");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(160128, "", "ep14_2_d_castle_3", 19.89125, 1966.492, -14, "RAID_CASTLE_EP14_2_PORTAL");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20040, "", "ep14_2_d_castle_3", -0.8668938, 1416.057, -1, "", "EP14_2_DCASTLE4_MQ_5_HIDDEN", "");
		
		// Orsha Investigator
		//-------------------------------------------------------------------------
		AddNpc(20060, "Orsha Investigator", "ep14_2_d_castle_3", -27.20892, 1950.933, 31, "RAID_CASTLE_EP14_2_SOLD");
		
		// [Great Royal General] {nl} Ramin
		//-------------------------------------------------------------------------
		AddNpc(150287, "[Great Royal General] {nl} Ramin", "ep14_2_d_castle_3", 69.65138, 1955.201, -9, "EP14_2_DCASTLE3_RAMIN2");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(155011, " ", "ep14_2_d_castle_3", 135.705, 1936.657, 90, "EP14_2_DCASTLE3_EXIT2", "EP14_2_DCASTLE3_CAVEWARP2");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(155011, " ", "ep14_2_d_castle_3", -257.5349, -527.3824, 90, "EP14_2_DCASTLE3_EXIT", "EP14_2_DCASTLE3_CAVEWARP");
		
		// Orsha Investigator
		//-------------------------------------------------------------------------
		AddNpc(20059, "Orsha Investigator", "ep14_2_d_castle_3", -36.66774, 1946.85, 41, "RAID_CASTLE_EP14_2_FSOLD");
	}
}
