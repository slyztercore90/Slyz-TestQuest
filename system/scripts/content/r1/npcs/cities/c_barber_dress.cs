//--- Melia Script ----------------------------------------------------------
// Beauty Shop
//--- Description -----------------------------------------------------------
// NPCs found in and around Beauty Shop.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class CBarberDressNpcScript : GeneralScript
{
	public override void Load()
	{
		// Barber Shop
		//-------------------------------------------------------------------------
		AddNpc(40001, "Barber Shop", "c_barber_dress", 119.494, 1199.081, 90, "BEAUTY_HAIRSHOP_MOVE", "BEAUTY_HAIRSHOP_MOVE");
		
		// Boutique
		//-------------------------------------------------------------------------
		AddNpc(40001, "Boutique", "c_barber_dress", -6.559355, 111.2336, 270, "BEAUTY_BOUTIQUE_MOVE", "BEAUTY_BOUTIQUE_MOVE");
		
		// Klaipeda
		//-------------------------------------------------------------------------
		AddNpc(40001, "Klaipeda", "c_barber_dress", -5.580346, -111.731, 0, "BEAUTY_OUT_MOVE", "BEAUTY_OUT_MOVE");
		
		// [Hair Stylist]{nl}Anabell Swyn
		//-------------------------------------------------------------------------
		AddNpc(161004, "[Hair Stylist]{nl}Anabell Swyn", "c_barber_dress", -15.95927, -55.1233, 90, "BEAUTY_SHOP_HAIR_F");
		
		// [Hair Stylist]{nl}Henry Swyn
		//-------------------------------------------------------------------------
		AddNpc(161005, "[Hair Stylist]{nl}Henry Swyn", "c_barber_dress", -6.081351, 41.64191, 90, "BEAUTY_SHOP_HAIR_M");
		
		// [Fashion Designer]{nl}Kastytis
		//-------------------------------------------------------------------------
		AddNpc(161003, "[Fashion Designer]{nl}Kastytis", "c_barber_dress", 23.59928, 1063.969, 90, "BEAUTY_SHOP_FASHION");
		
		// Goddess' Blessing
		//-------------------------------------------------------------------------
		AddNpc(160121, "Goddess' Blessing", "c_barber_dress", 21.01138, 1172.341, 200, "BLESSED_CUBE");
	}
}
