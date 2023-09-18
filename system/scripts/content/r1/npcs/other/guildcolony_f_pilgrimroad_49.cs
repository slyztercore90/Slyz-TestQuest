//--- Melia Script ----------------------------------------------------------
// Genar Field
//--- Description -----------------------------------------------------------
// NPCs found in and around Genar Field.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class GuildColonyFPilgrimroad49NpcScript : GeneralScript
{
	public override void Load()
	{
		// Manahas
		//-------------------------------------------------------------------------
		AddNpc(40001, "Manahas", "GuildColony_f_pilgrimroad_49", 2378.388, 184.8524, 124, "", "PILGRIM_49_TO_PILGRIM_48", "");
		
		// Pilgrim Path
		//-------------------------------------------------------------------------
		AddNpc(40001, "Pilgrim Path", "GuildColony_f_pilgrimroad_49", -2314.767, -647.9147, -15, "", "PILGRIM_49_TO_PILGRIM_47", "");
		
		// Altar Way
		//-------------------------------------------------------------------------
		AddNpc(40001, "Altar Way", "GuildColony_f_pilgrimroad_49", -85.97439, 1318.946, 179, "", "PILGRIM_49_TO_PILGRIM_50", "");
	}
}
