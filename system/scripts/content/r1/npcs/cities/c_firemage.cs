//--- Melia Script ----------------------------------------------------------
// Pyromancer Master's Lab
//--- Description -----------------------------------------------------------
// NPCs found in and around Pyromancer Master's Lab.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class CFiremageNpcScript : GeneralScript
{
	public override void Load()
	{
		// [Pyromancer Master]{nl}Abreh Melinn
		//-------------------------------------------------------------------------
		AddNpc(20027, "[Pyromancer Master]{nl}Abreh Melinn", "c_firemage", -172, -7, 49, "MASTER_FIREMAGE");
		
		// Advancement Quest Trigger of Cryomancer
		//-------------------------------------------------------------------------
		AddNpc(20041, "Advancement Quest Trigger of Cryomancer", "c_firemage", 195, 5, 90, "", "MASTER_FIREMAGE_BOX_TRIGGER", "");
		
		// [Keraunos Master]{nl}Owynia Dilben
		//-------------------------------------------------------------------------
		AddNpc(153223, "[Keraunos Master]{nl}Owynia Dilben", "c_firemage", -97.02818, 87.32312, 0, "MASTER_CHAR2_24_CITY");
	}
}
