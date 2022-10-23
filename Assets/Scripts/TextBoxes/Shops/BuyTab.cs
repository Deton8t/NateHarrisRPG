using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BuyTab : MonoBehaviour
{

    public GameObject[] mainMenu;
    public List<string> buyMenuText;
    public TMP_Text buyMenuTextHolder;
    public int indexer;
    public ShopMenuRewrite items;
    public bool inOtherMenu = false;


    void Start()
    {
        items = this.GetComponent<ShopMenuRewrite>();
        ShopInfoHolder.initShopText("BuyMenu1", 0);
        buyMenuText = ShopInfoHolder.mainMenuLines;
        initShopText();
    }
    // Update is called once per frame

    void Update()
    {
        if (inOtherMenu)
        {
            return;
        }
        if (Input.GetKeyDown(KeyBinds.DownArr) || Input.GetKeyDown(KeyBinds.DownS))
        {
            indexer++;
            if (indexer > 2)
            {
                indexer = 0;
                UpdateShopText(indexer, 2);
            }
            else
            {
                UpdateShopText(indexer, indexer - 1);
            }
        };
        if (Input.GetKeyDown(KeyBinds.upW) || Input.GetKeyDown(KeyBinds.UpArr))
        {
            indexer--;
            if (indexer < 0)
            {
                indexer = 2;
                UpdateShopText(indexer, 0);
            }
            else
            {
                UpdateShopText(indexer, indexer + 1);
            }
        }
        if (Input.GetKeyDown(KeyBinds.enter))
        {
            items.onSwitch();
            inOtherMenu = true;
        }

    }

    void initShopText()
    {
        string cursor = "> ";
        for (int i = 0; i < buyMenuText.Count; i++)
        {
            buyMenuTextHolder = mainMenu[i].GetComponent<TMP_Text>();
            buyMenuTextHolder.text = cursor + buyMenuText[i];
            cursor = "* ";
        }
    }

    void UpdateShopText(int index, int previous)
    {
        buyMenuTextHolder = mainMenu[index].GetComponent<TMP_Text>();
        buyMenuTextHolder.text = "> " + buyMenuText[index];
        buyMenuTextHolder = mainMenu[previous].GetComponent<TMP_Text>();
        buyMenuTextHolder.text = "* " + buyMenuText[previous];
    }

}
