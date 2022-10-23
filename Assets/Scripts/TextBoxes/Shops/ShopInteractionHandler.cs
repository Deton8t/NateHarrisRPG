using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This script will handle how the shop gives
// the player items and checks for money and such!
public class ShopInteractionHandler : MonoBehaviour
{
    public ShopMenuRewrite shopMenu;
    private BuyTab mainMenu;
    public int shopItemIndex;
    private List<int> itemIDs;
    private string shopName;
    private int currentID;

    void Start()
    {
        shopMenu = this.GetComponent<ShopMenuRewrite>();
        mainMenu = this.GetComponent<BuyTab>();
        shopItemIndex = shopMenu.currentItemIndex;
        shopName = shopMenu.shopName;
    }

    void Update()
    {
        if (!mainMenu.inOtherMenu)
        {
            return;
        }
        shopItemIndex = shopMenu.currentItemIndex;
        itemIDs = ShopInfoHolder.itemIDs;
        currentID = itemIDs[shopItemIndex];
        if (Input.GetKeyDown(KeyBinds.enter))
        {
            initializeItemWindow();
        }
    }

    private void initializeItemWindow()
    {

    }
}
