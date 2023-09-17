//--- Melia Script ----------------------------------------------------------
// Salvia Forest
//--- Description -----------------------------------------------------------
// NPCs found in and around Salvia Forest.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class GuildColonyFPilgrimroad412NpcScript : GeneralScript
{
	public override void Load()
	{
		// Thaumas Trail
		//-------------------------------------------------------------------------
		AddNpc(40001, "Thaumas Trail", "GuildColony_f_pilgrimroad_41_2", -1859.174, 597.5132, 238, "", "PILGRIM41_2_PILGRIM41_1", "");
		
		// Sekta Forest
		//-------------------------------------------------------------------------
		AddNpc(40001, "Sekta Forest", "GuildColony_f_pilgrimroad_41_2", 7.247588, -1548.198, 5, "", "PILGRIM41_2_PILGRIM41_4", "");
		
		// Rasvoy Lake
		//-------------------------------------------------------------------------
		AddNpc(40001, "Rasvoy Lake", "GuildColony_f_pilgrimroad_41_2", 2007.936, -1021.727, 90, "", "PILGRIM41_2_PILGRIM41_3", "");
		
		// Khonot Forest
		//-------------------------------------------------------------------------
		AddNpc(40001, "Khonot Forest", "GuildColony_f_pilgrimroad_41_2", 107.4228, 1605.379, 188, "", "PILGRIM41_2_TO_BRACKEN42_1", "");
	}
}
