using Melia.Shared.Data.Database;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Items;


public class TxItemScripts : GeneralScript
{
	/// <summary>
	/// Register's an item in "Goddess" Cabinet
	/// </summary>
	/// <param name="character"></param>
	/// <param name="item"></param>
	/// <param name="strArg"></param>
	/// <param name="numArg1"></param>
	/// <param name="numArg2"></param>
	/// <returns></returns>
	[ScriptableFunction("SCR_OPEN_CABINET_GODDESS")]
	public ItemUseResult SCR_OPEN_CABINET_GODDESS(Character character, Item item, string strArg, float numArg1, float numArg2)
	{
		if (!ZoneServer.Instance.Data.CabinetDb.TryFind(CabinetType.Armor, (int)numArg2, out var data))
			return ItemUseResult.Fail;
		if (!string.IsNullOrEmpty(data.AccountProperty))
			character.SetAccountProperty(data.AccountProperty, 1);

		if (!string.IsNullOrEmpty(data.UpgradeAccountProperty))
			character.SetAccountProperty(data.UpgradeAccountProperty, (int)numArg1);

		return ItemUseResult.Okay;
	}
}
