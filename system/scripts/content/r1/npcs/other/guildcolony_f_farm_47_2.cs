//--- Melia Script ----------------------------------------------------------
// Aqueduct Bridge Area
//--- Description -----------------------------------------------------------
// NPCs found in and around Aqueduct Bridge Area.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class GuildColonyFFarm472NpcScript : GeneralScript
{
	public override void Load()
	{
		// Myrkiti Farm
		//-------------------------------------------------------------------------
		AddNpc(40001, "Myrkiti Farm", "GuildColony_f_farm_47_2", 2559.683, -1202.66, 112, "", "FARM_47_2_TO_FARM_47_3", "");
		
		// Tenants' Farm
		//-------------------------------------------------------------------------
		AddNpc(40001, "Tenants' Farm", "GuildColony_f_farm_47_2", 1888.028, 1061.506, 92, "", "FARM_47_2_TO_FARM_47_1", "");
		
		// Greene Manor
		//-------------------------------------------------------------------------
		AddNpc(40001, "Greene Manor", "GuildColony_f_farm_47_2", -1805.981, 977.8495, -87, "", "FARM_47_2_TO_FARM_49_1", "");
		
		// Demon Prison District 1
		//-------------------------------------------------------------------------
		AddNpc(154069, "Demon Prison District 1", "GuildColony_f_farm_47_2", -1615.764, -1192.171, 90, "FARM_47_2_TO_VELNIASP511");
	}
}
