-- Create system button to toggle buy-in shop creation window.
Melia.Ui.SysMenu.AddButton("BtnBuyInShop", "sysmenu_wugushi", "Create Buy-in Shop", "M_TOGGLE_PERSONAL_SHOP()")

function M_TOGGLE_PERSONAL_SHOP()

	local frame = ui.GetFrame("personal_shop_register")
	if frame:IsVisible() == 1 then
		frame:ShowWindow(false)
	else
		OPEN_PERSONAL_SHOP_REGISTER()
	end
	
end

Melia.Override("OPEN_PERSONAL_SHOP_REGISTER", function()

--	if true == session.loginInfo.IsPremiumState(ITEM_TOKEN) then
--		ui.SysMsg(ClMsg("NeedPremiunState"));
--		return;
--	end

	if session.autoSeller.GetMyAutoSellerShopState(1) == true then
		ui.OpenFrame("buffseller_my");
	else
		local mapCls = GetClass("Map", session.GetMapName());
		if nil == mapCls then
			return;
		end
		if 'City' ~= mapCls.MapType then
			ui.SysMsg(ClMsg("AllowedInTown"));
			return;
		end
		ui.OpenFrame("personal_shop_register");
	end
end)