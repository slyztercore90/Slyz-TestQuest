//--- Melia Script ----------------------------------------------------------
// Delmore Waiting Area
//--- Description -----------------------------------------------------------
// NPCs found in and around Delmore Waiting Area.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class Ep142DCastle1NpcScript : GeneralScript
{
	public override void Load()
	{
		// [Great Royal General] {nl} Ramin
		//-------------------------------------------------------------------------
		AddNpc(150287, "[Great Royal General] {nl} Ramin", "ep14_2_d_castle_1", 1777.062, -291.2963, 187, "EP14_2_1_Lamin1");
		
		// Pajauta
		//-------------------------------------------------------------------------
		AddNpc(154120, "Pajauta", "ep14_2_d_castle_1", 1658.078, -303.6677, 190, "EP14_2_1_PAJAUTA1");
		
		// [Great Royal General] {nl} Ramin
		//-------------------------------------------------------------------------
		AddNpc(150287, "[Great Royal General] {nl} Ramin", "ep14_2_d_castle_1", -747.4651, 3365.16, 0, "EP14_2_1_Lamin2");
		
		// Hidden Passage
		//-------------------------------------------------------------------------
		AddNpc(40001, "Hidden Passage", "ep14_2_d_castle_1", -1007.142, 3302.728, -86, "", "WARP_EP14_2_D_CASTLE_1_TO_EP14_2_D_CASTLE_2", "");
		
		// Delmore Garden
		//-------------------------------------------------------------------------
		AddNpc(40001, "Delmore Garden", "ep14_2_d_castle_1", 1591.621, -495.3015, -11, "", "WARP_EP14_2_D_CASTLE_1_TO_EP14_1_F_CASTLE_5", "");
		
		// Pajauta
		//-------------------------------------------------------------------------
		AddNpc(154120, "Pajauta", "ep14_2_d_castle_1", -673.9743, 3359.794, -30, "EP14_2_1_PAJAUTA2");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "ep14_2_d_castle_1", 1133.609, 37.23258, 92, "WARP_EP14_2_DCASTLE_1", "STOUP_CAMP", "STOUP_CAMP");
		
		// Red Crystal with Kruvina
		//-------------------------------------------------------------------------
		AddNpc(160126, "Red Crystal with Kruvina", "ep14_2_d_castle_1", 2020.576, 1153.062, 90, "EP14_2_RED_CRYSTAL");
		
		// Red Crystal with Kruvina
		//-------------------------------------------------------------------------
		AddNpc(160126, "Red Crystal with Kruvina", "ep14_2_d_castle_1", 1976.989, 1551.501, 90, "EP14_2_RED_CRYSTAL");
		
		// Red Crystal with Kruvina
		//-------------------------------------------------------------------------
		AddNpc(160126, "Red Crystal with Kruvina", "ep14_2_d_castle_1", 1583.775, 1473.314, 90, "EP14_2_RED_CRYSTAL");
		
		// Red Crystal with Kruvina
		//-------------------------------------------------------------------------
		AddNpc(160126, "Red Crystal with Kruvina", "ep14_2_d_castle_1", 2056.346, 2026.499, 90, "EP14_2_RED_CRYSTAL");
		
		// Red Crystal with Kruvina
		//-------------------------------------------------------------------------
		AddNpc(160126, "Red Crystal with Kruvina", "ep14_2_d_castle_1", 1562.152, 2034.595, 69, "EP14_2_RED_CRYSTAL");
		
		// Red Crystal with Kruvina
		//-------------------------------------------------------------------------
		AddNpc(160126, "Red Crystal with Kruvina", "ep14_2_d_castle_1", 1543.732, 2493.622, 90, "EP14_2_RED_CRYSTAL");
		
		// Red Crystal with Kruvina
		//-------------------------------------------------------------------------
		AddNpc(160126, "Red Crystal with Kruvina", "ep14_2_d_castle_1", 2045.122, 2484.767, 90, "EP14_2_RED_CRYSTAL");
		
		// Red Crystal with Kruvina
		//-------------------------------------------------------------------------
		AddNpc(160126, "Red Crystal with Kruvina", "ep14_2_d_castle_1", 1982.464, 2922.498, 90, "EP14_2_RED_CRYSTAL");
		
		// Red Crystal with Kruvina
		//-------------------------------------------------------------------------
		AddNpc(160126, "Red Crystal with Kruvina", "ep14_2_d_castle_1", 1557.687, 2950.02, 90, "EP14_2_RED_CRYSTAL");
		
		// Red Crystal with Kruvina
		//-------------------------------------------------------------------------
		AddNpc(160126, "Red Crystal with Kruvina", "ep14_2_d_castle_1", 1548.165, 3364.232, 90, "EP14_2_RED_CRYSTAL");
		
		// Red Crystal with Kruvina
		//-------------------------------------------------------------------------
		AddNpc(160126, "Red Crystal with Kruvina", "ep14_2_d_castle_1", 1965.98, 3347.788, 90, "EP14_2_RED_CRYSTAL");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(154079, "", "ep14_2_d_castle_1", -902.0294, 3282.801, 90, "EP14_2_DCASTLE1_WALL");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20025, "", "ep14_2_d_castle_1", -401.0585, 3074.433, 90, "", "EP14_2_DCASTLE1_MQ_7_HIDDEN", "");
		
		// Underground Tunnel
		//-------------------------------------------------------------------------
		AddNpc(155010, "Underground Tunnel", "ep14_2_d_castle_1", -1044.053, -66.9463, 90, "EP14_2_DCASTLE_EXIT", "EP14_2_DCASTLE_CAVEWARP");
		
		// Underground Tunnel
		//-------------------------------------------------------------------------
		AddNpc(155011, "Underground Tunnel", "ep14_2_d_castle_1", 1480.814, 1123.208, 90, "EP14_2_DCASTLE_EXIT2", "EP14_2_DCASTLE_CAVEWARP2");
	}
}
