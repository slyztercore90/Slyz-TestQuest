//--- Melia Script ----------------------------------------------------------
// Issaugoti Forest
//--- Description -----------------------------------------------------------
// NPCs found in and around Issaugoti Forest.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class Ep13FSiauliai4NpcScript : GeneralScript
{
	public override void Load()
	{
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "ep13_f_siauliai_4", 112.216, 75.66612, 90, "", "EP13_F_SIAULIAI_4_MQ03_TRIG", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "ep13_f_siauliai_4", 164.9881, -573.5817, 90, "", "EP13_F_SIAULIAI_4_MQ03_TRIG2", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "ep13_f_siauliai_4", 117.8256, -257.4228, 90, "EP13_F_SIAULIAI_4_MQ04_WAY01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "ep13_f_siauliai_4", 656.8864, -143.3087, 90, "EP13_F_SIAULIAI_4_MQ04_WAY02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "ep13_f_siauliai_4", 871.0787, 484.4627, 90, "EP13_F_SIAULIAI_4_MQ04_WAY03");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "ep13_f_siauliai_4", 96.89069, -279.044, 90, "", "EP13_F_SIAULIAI_4_MQ04_WAY04", "");
		
		// Goddess Lada
		//-------------------------------------------------------------------------
		AddNpc(156043, "Goddess Lada", "ep13_f_siauliai_4", 68.76344, -1014.144, 90, "EP13_GODDESS_LADA_ISA");
		
		// Ragana's Messenger
		//-------------------------------------------------------------------------
		AddNpc(59583, "Ragana's Messenger", "ep13_f_siauliai_4", -606.0184, -527.0504, 152, "EP13_F_SIAULIAI_4_MQ_05_MAIL");
		
		// Baiga's Messenger
		//-------------------------------------------------------------------------
		AddNpc(59584, "Baiga's Messenger", "ep13_f_siauliai_4", -772.1847, 279.823, 15, "EP13_F_SIAULIAI_4_MQ_06_MAIL");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "ep13_f_siauliai_4", 543.4092, -142.095, 90, "", "EP13_F_SIAULIAI_4_MQ07_TRIG", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "ep13_f_siauliai_4", 22.51642, -946.3156, 90, "WARP_EP13_F_SIAULIAI_4", "STOUP_CAMP", "STOUP_CAMP");
		
		// Statue of Goddess Zemyna
		//-------------------------------------------------------------------------
		AddNpc(40110, "Statue of Goddess Zemyna", "ep13_f_siauliai_4", 1142.392, 609.9449, 17, "EP13_F_SIAULIAI_4_ZEMINA", "EP13_F_SIAULIAI_4_ZEMINA", "EP13_F_SIAULIAI_4_ZEMINA");
		
		// Suspicious Pile of Box Containing Something
		//-------------------------------------------------------------------------
		AddNpc(151029, "Suspicious Pile of Box Containing Something", "ep13_f_siauliai_4", -241.1957, 855.1622, 90, "EP13_F_SIAULIAI_MQ08_BOX");
		
		// Paupys Crossing
		//-------------------------------------------------------------------------
		AddNpc(40001, "Paupys Crossing", "ep13_f_siauliai_4", 126.3742, -1144.248, 6, "", "WARP_EP13_F_SIAULIAI_4_TO_EP13_F_SIAULIAI_3", "");
		
		// Kirtimas Forest
		//-------------------------------------------------------------------------
		AddNpc(40001, "Kirtimas Forest", "ep13_f_siauliai_4", 73.92236, 1200.827, 166, "", "WARP_EP13_F_SIAULIAI_4_TO_EP13_F_SIAULIAI_5", "");
		
		// [Kingdom Reconstruction]{nl}Orsha Medical Solider
		//-------------------------------------------------------------------------
		AddNpc(153111, "[Kingdom Reconstruction]{nl}Orsha Medical Solider", "ep13_f_siauliai_4", 640.5109, 51.80798, 107, "EP13_F_SIAULIAI_4_REPUTATION_01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(155107, " ", "ep13_f_siauliai_4", -221.6736, 871.6878, 90, "", "EP13_F_SIAULIAI_4_BOMB", "");
		
		// [Pied Piper Master]{nl}Jogaila
		//-------------------------------------------------------------------------
		AddNpc(153207, "[Pied Piper Master]{nl}Jogaila", "ep13_f_siauliai_4", -845.7841, 329.1088, 33, "EP15_F_ABBEY2_6_NPC");
	}
}
