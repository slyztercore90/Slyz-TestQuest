//--- Melia Script ----------------------------------------------------------
// Narvas Temple Annex
//--- Description -----------------------------------------------------------
// NPCs found in and around Narvas Temple Annex.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DAbbey225NpcScript : GeneralScript
{
	public override void Load()
	{
		// Narvas Temple
		//-------------------------------------------------------------------------
		AddNpc(40001, "Narvas Temple", "d_abbey_22_5", 28.36045, 1276.747, 176, "", "ABBEY22_5_ABBEY22_4", "");
		
		// Mishekan Forest
		//-------------------------------------------------------------------------
		AddNpc(40001, "Mishekan Forest", "d_abbey_22_5", -1461.984, -1121.876, -3, "", "ABBEY22_5_WHITETREES56_1", "");
		
		// Agailla Flurry Apparition
		//-------------------------------------------------------------------------
		AddNpc(154087, "Agailla Flurry Apparition", "d_abbey_22_5", -63.74786, 1166.061, 41, "ABBEY225_FLURRY1", "ABBEY225_FLURRY1_IN");
		
		// Unidentified Facility
		//-------------------------------------------------------------------------
		AddNpc(153184, "Unidentified Facility", "d_abbey_22_5", -81.51931, 1156.813, 45, "ABBEY225_SUBQ2_NPC1");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20026, "", "d_abbey_22_5", 1519.946, 802.2214, 90, "", "ABBEY225_SUBQ1_HIDDEN_IN", "");
		
		// Monk Aistis
		//-------------------------------------------------------------------------
		AddNpc(155045, "Monk Aistis", "d_abbey_22_5", 1931.37, 864.05, 77, "ABBEY225_SUBQ1_NPC1");
		
		// Deception Hauberk
		//-------------------------------------------------------------------------
		AddNpc(57840, "Deception Hauberk", "d_abbey_22_5", 1904.628, 758.1877, 259, "ABBEY225_DECEPTION_HAUBERK");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "d_abbey_22_5", -1480.916, 901.4473, 90, "", "ABBEY225_SUBQ5_NPC1_IN", "");
		
		// Agailla Flurry Apparition
		//-------------------------------------------------------------------------
		AddNpc(154087, "Agailla Flurry Apparition", "d_abbey_22_5", -1679.925, 1465.352, 40, "ABBEY225_FLURRY2");
		
		// Unidentified Facility
		//-------------------------------------------------------------------------
		AddNpc(153184, "Unidentified Facility", "d_abbey_22_5", -1679.061, 1491.459, 131, "ABBEY22_AGAFLARY_DLG");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(151000, " ", "d_abbey_22_5", -1580.06, 1415.809, 90, "ABBEY225_SUBQ5_NPC2");
		
		// Agailla Flurry Apparition
		//-------------------------------------------------------------------------
		AddNpc(154087, "Agailla Flurry Apparition", "d_abbey_22_5", 1837.288, 181.447, 15, "ABBEY225_FLURRY3", "ABBEY225_FLURRY3_IN");
		
		// Registry Orb Generator
		//-------------------------------------------------------------------------
		AddNpc(147475, "Registry Orb Generator", "d_abbey_22_5", 1775.916, 192.8382, 90, "ABBEY225_SUBQ7_OBJ1");
		
		// Unidentified Facility
		//-------------------------------------------------------------------------
		AddNpc(153184, "Unidentified Facility", "d_abbey_22_5", 1857.397, 200.3151, 47, "ABBEY22_5_SUBQ9_NPC1");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "d_abbey_22_5", -1338.093, -86.07137, 90, "", "ABBEY22_5_SUBQ11_NPC1_IN", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(152078, " ", "d_abbey_22_5", -723.2693, -694.3865, 90, "ABBEY22_5_SUBQ14_PORTAL");
		
		// Control Terminal
		//-------------------------------------------------------------------------
		AddNpc(47250, "Control Terminal", "d_abbey_22_5", -722.5114, -837.6592, 90, "ABBEY22_5_SUBQ13_DEVICE");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(153184, " ", "d_abbey_22_5", -775.6501, -651.9524, 222, "ABBEY22_AGAFLARY_DLG");
		
		// Agailla Flurry Apparition
		//-------------------------------------------------------------------------
		AddNpc(154087, "Agailla Flurry Apparition", "d_abbey_22_5", -764.6105, -683.9967, -3, "ABBEY225_FLURRY4");
		
		// Monk Aistis
		//-------------------------------------------------------------------------
		AddNpc(155045, "Monk Aistis", "d_abbey_22_5", 2002.22, 972.94, 90, "ABBEY225_SUBQ15_NPC1");
		
		// Agailla Flurry Apparition
		//-------------------------------------------------------------------------
		AddNpc(154087, "Agailla Flurry Apparition", "d_abbey_22_5", 1929.194, 905.2536, -18, "ABBEY225_FLURRY5");
	}
}
