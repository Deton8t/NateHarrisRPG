using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMenuRewrite : MonoBehaviour
{
    [SerializeField]
    private static GameObject Text1, Text2, Text3, Text4;
    [SerializeField]
    private int offset;
    [SerializeField]
    private GameObject[] textBoxes = {
        Text1,
        Text2,
        Text3,
        Text4,
    };
    private TMP_Text text;
    [SerializeField]
    public string shopName;

    public List<string> shopText;
    private BuyTab buyMenu;
    [SerializeField]
    private int textListMax;
    [SerializeField]
    private int shopItemIndex;
    public bool isActive;
    public int previousState;
    public int textIndex;
    public int currentItemIndex;
    void Start()
    {
        buyMenu = this.GetComponent<BuyTab>();
        ShopInfoHolder.initShopText(shopName, 0);
        shopText = ShopInfoHolder.textLines;
        initializeText(shopText);
    }

    // Update is called once per frame
    void Update()
    {
        int buyMenuIndex = buyMenu.indexer;
        if (buyMenuIndex != previousState)
        {
            ShopInfoHolder.initShopText(shopName, buyMenuIndex);
            shopText = ShopInfoHolder.textLines;
            Debug.Log(shopText[0]);
            initializeText(shopText);
        }
        if (Input.GetKeyDown(KeyBinds.exit))
        {
            offSwitch();
        }
        previousState = buyMenuIndex;
        if (!isActive)
        {
            return;
        }
        if (Input.GetKeyDown(KeyBinds.DownArr) || Input.GetKeyDown(KeyBinds.DownS))
        {
            scrollText(1, shopText);
        }
        if (Input.GetKeyDown(KeyBinds.upW) || Input.GetKeyDown(KeyBinds.UpArr))
        {
            scrollText(-1, shopText);
        }
    }

    void initializeText(List<string> menuTextList)
    {
        string cursor = "* ";
        int i = 0;
        textListMax = menuTextList.Count - 2;
        currentItemIndex = shopItemIndex + offset;
        {
            while (i < 4)
            {
                textIndex = i + offset; // Where in the list we display
                if (textIndex >= menuTextList.Count - 1) // Accounting for overflow
                {
                    textIndex = menuTextList.Count - 1;
                }
                if (i == shopItemIndex) // If it matches the item we are on it diplays cursor
                {
                    if (!isActive)
                    { }
                    else
                    {
                        cursor = "> ";
                    }
                }
                else
                {
                    cursor = "* ";
                }
                text = textBoxes[i].GetComponent<TMP_Text>();
                text.text = cursor + menuTextList[textIndex];
                i++;
            }
        }

    }

    public void onSwitch()
    {
        isActive = true;
        scrollText(0, shopText);
    }

    public void offSwitch()
    {
        isActive = false;
        shopItemIndex = 0;
        offset = 0;
        initializeText(shopText);
        buyMenu.inOtherMenu = false;
    }

    void scrollText(int scrollDirection, List<string> menuTextList)
    {
        if (scrollDirection == 1)
        {
            shopItemIndex++;
            if (shopItemIndex > 3)
            {
                shopItemIndex = 3;
                offset++;
                if ((shopItemIndex + offset) > menuTextList.Count - 2) // -1 to account for blank space that repeats
                {
                    offset = 0;
                    shopItemIndex = 0;
                }
            }
        }
        if (scrollDirection == -1)
        {
            shopItemIndex--;
            if (shopItemIndex < 0)
            {
                shopItemIndex = 0;
                offset--;
                if (offset < 0)
                {
                    offset = (menuTextList.Count - 3 - 2);
                    if (offset < 0) //accounting for lists shorter than 4 item values
                    {
                        offset = 0;
                    }
                    shopItemIndex = 3;
                }
            }

        }
        initializeText(menuTextList);
    }

}
