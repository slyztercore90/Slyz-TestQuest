//--- Melia Script ----------------------------------------------------------
// Sulivinas Lair
//--- Description -----------------------------------------------------------
// NPCs found in and around Sulivinas Lair.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DLimestonecave701RestNpcScript : GeneralScript
{
	public override void Load()
	{
		// Vedas Plateau
		//-------------------------------------------------------------------------
		AddNpc(40001, "Vedas Plateau", "d_limestonecave_70_1_rest", 96.82263, -2115.716, -7, "", "RVR_BK_REST_TO_TABLE111", "");
		
		// Cave's Depths
		//-------------------------------------------------------------------------
		AddNpc(154069, "Cave's Depths", "d_limestonecave_70_1_rest", -741.6858, -1123.854, 90, "RVR_BK_REST1_TO_REST2");
		
		// Cave Exit
		//-------------------------------------------------------------------------
		AddNpc(154069, "Cave Exit", "d_limestonecave_70_1_rest", -342.0088, 945.9113, 90, "RVR_BK_REST2_TO_REST1");
		
		// Fatigued Boruta
		//-------------------------------------------------------------------------
		AddNpc(59212, "Fatigued Boruta", "d_limestonecave_70_1_rest", 823.8431, 1329.019, -70, "", "RVR_BK_701_REST_BORUTA_NPC", "");
	}
}
