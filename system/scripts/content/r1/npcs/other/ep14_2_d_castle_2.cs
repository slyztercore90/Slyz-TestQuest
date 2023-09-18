//--- Melia Script ----------------------------------------------------------
// Hidden Passage
//--- Description -----------------------------------------------------------
// NPCs found in and around Hidden Passage.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class Ep142DCastle2NpcScript : GeneralScript
{
	public override void Load()
	{
		// Delmore Waiting Area
		//-------------------------------------------------------------------------
		AddNpc(40001, "Delmore Waiting Area", "ep14_2_d_castle_2", 235.9232, -656.8378, -89, "", "WARP_EP14_2_D_CASTLE_2_TO_EP14_2_D_CASTLE_1", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "ep14_2_d_castle_2", 213.0273, -1052.083, 90, "WARP_EP14_2_DCASTLE_2", "STOUP_CAMP", "STOUP_CAMP");
		
		// Statue of Goddess Zemyna
		//-------------------------------------------------------------------------
		AddNpc(40110, "Statue of Goddess Zemyna", "ep14_2_d_castle_2", 793.483, 1271.432, 90, "EP14_2_DCASLTE2_ZEMINA", "EP14_2_DCASLTE2_ZEMINA", "EP14_2_DCASLTE2_ZEMINA");
		
		// Magic Association Assembly Hall
		//-------------------------------------------------------------------------
		AddNpc(154065, "Magic Association Assembly Hall", "ep14_2_d_castle_2", 86.00278, 635.9998, 90, "EP14_2_DCASLTE2_PORTAL");
		
		// [Great Royal General] {nl} Ramin
		//-------------------------------------------------------------------------
		AddNpc(150287, "[Great Royal General] {nl} Ramin", "ep14_2_d_castle_2", 188.8989, -331.3, 93, "EP14_2_2_LAMIN1");
		
		// Pajauta
		//-------------------------------------------------------------------------
		AddNpc(154120, "Pajauta", "ep14_2_d_castle_2", 213.9028, -388.2869, 142, "EP14_2_2_PAJAUTA1");
		
		// Magic Control Device
		//-------------------------------------------------------------------------
		AddNpc(150032, "Magic Control Device", "ep14_2_d_castle_2", 1385.703, -570.6474, 90, "EP14_2_DCASTLE2_MANA1");
		
		// Magic Control Device
		//-------------------------------------------------------------------------
		AddNpc(150032, "Magic Control Device", "ep14_2_d_castle_2", -1365.801, 651.5099, 90, "EP14_2_DCASTLE2_MANA2");
		
		// Magic Control Device
		//-------------------------------------------------------------------------
		AddNpc(150032, "Magic Control Device", "ep14_2_d_castle_2", -1467.873, -756.5397, 106, "EP14_2_DCASTLE2_MANA3");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(40095, "", "ep14_2_d_castle_2", 488.2943, 652.4831, 90, "", "EP14_2_DCASTLE2_MQ_6_TRIGGER", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(40095, "", "ep14_2_d_castle_2", -373.234, 634.7499, 90, "", "EP14_2_DCASTLE2_MQ_10_TRIGGER", "");
		
		// Pajauta
		//-------------------------------------------------------------------------
		AddNpc(154120, "Pajauta", "ep14_2_d_castle_2", -962.5208, 1126.418, 110, "EP14_2_2_PAJAUTA2");
		
		// [Great Royal General] {nl} Ramin
		//-------------------------------------------------------------------------
		AddNpc(150287, "[Great Royal General] {nl} Ramin", "ep14_2_d_castle_2", -968.8201, 1180.229, 46, "EP14_2_2_LAMIN2");
		
		// Magic Control Device
		//-------------------------------------------------------------------------
		AddNpc(150032, "Magic Control Device", "ep14_2_d_castle_2", 1476.212, 646.769, 90, "EP14_2_DCASTLE2_MANA4");
		
		// Underground Tunnel
		//-------------------------------------------------------------------------
		AddNpc(155010, "Underground Tunnel", "ep14_2_d_castle_2", 700.0975, -992.1199, 90, "EP14_2_DCASTLE2_EXIT2", "EP14_2_DCASTLE2_CAVEWARP2");
		
		// Underground Tunnel
		//-------------------------------------------------------------------------
		AddNpc(155011, "Underground Tunnel", "ep14_2_d_castle_2", -870.0734, -1267.066, 90, "EP14_2_DCASTLE2_EXIT", "EP14_2_DCASTLE2_CAVEWARP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154046, " ", "ep14_2_d_castle_2", 90.9, 539.86, 90, "BAUBAS_GO_GUILDMISSION", "BAUBAS_GO_GUILDMISSION");
	}
}
