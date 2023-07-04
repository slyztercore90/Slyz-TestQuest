//--- Melia Script ----------------------------------------------------------
// Add Certificate Coin Items
//--- Description -----------------------------------------------------------
// Item scripts that add coin (Gabija/Vakrine) to an account.
//---------------------------------------------------------------------------

using System;
using Melia.Shared.ObjectProperties;
using Melia.Shared.Tos.Const;
using Melia.Shared.Tos.Properties;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Items;

public class CertificateCoinItemScript : GeneralScript
{
	[ScriptableFunction("SCR_USE_ITEM_CERTIFICATE_COIN")]
	public ItemUseResult SCR_USE_ITEM_CERTIFICATE_COIN(Character character, Item item, string propertyName, float coinAmount, float numArg2)
	{
		character.ModifyAccountProperty(propertyName, coinAmount);
		// Obtained Points message
		character.SystemMessage("PointGet{name}{count}", new MsgParameter("name", item.Data.Name), new MsgParameter("count", coinAmount.ToString()));
		return ItemUseResult.Okay;
	}
}
