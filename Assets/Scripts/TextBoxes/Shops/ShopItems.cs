using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShopItems : MonoBehaviour
{
    public int itemCount;
    [SerializeField]
    public List<string> shopText;
    public string shopName;
    [SerializeField]
    public static GameObject Text1, Text2, Text3, Text4;
    public GameObject[] textBoxArray = { Text1, Text2, Text3, Text4 };
    [SerializeField]
    private TMP_Text boxText;
    private int textBoxLineIndexer;
    private KeyBinds binds;
    public bool inPreview = true;
    public bool inBuyMenu;
    public bool firstRun = true;
    public BuyTab mainMenu;

    void Start()
    {
        mainMenu = this.GetComponent<BuyTab>();
        binds = this.GetComponent<KeyBinds>();
        initializeText(shopName);
    }

    // Work on having the text system check which thing to write to.
    //This could be done with another script. I think that would be wisest.
    void Update()
    {
        if (Input.GetKeyDown(KeyBinds.exit))
        {
            textBoxLineIndexer = 0;
            boxText = textBoxArray[0].GetComponent<TMP_Text>();
            inBuyMenu = false;
            firstRun = true;
            inPreview = true;
            mainMenu.inOtherMenu = false;
            initializeText(shopName);
            itemCount = 0;
        }
        if (inPreview)
        {
            itemCount = 0;
        }
        if (!inBuyMenu)
        {
            return;
        }
        if (Input.GetKeyDown(KeyBinds.UpArr) || Input.GetKeyDown(KeyBinds.upW))
        {
            textBoxLineIndexer--;
            if (textBoxLineIndexer < 0)
            {
                writeText(textBoxLineIndexer + 1, false);
                textBoxLineIndexer = itemCount - 1;
            }
            else
            {
                writeText(textBoxLineIndexer + 1, false);
            }
            writeText(textBoxLineIndexer, true);
        }
        if (Input.GetKeyDown(KeyBinds.DownS) || Input.GetKeyDown(KeyBinds.DownArr))
        {
            textBoxLineIndexer++;
            if (textBoxLineIndexer > itemCount - 1)
            {
                writeText(textBoxLineIndexer - 1, false);
                textBoxLineIndexer = 0;
            }
            else
            {
                writeText(textBoxLineIndexer - 1, false);
            }
            writeText(textBoxLineIndexer, true);
        }
    }

    public void initializeText(string textGroupName)
    {
        ShopInfoHolder.initShopText(textGroupName, 0);
        shopText = ShopInfoHolder.textLines;
        Debug.Log(shopText[1]);
        bool buyIsSelected = true;
        for (int i = 0; i < 4; i++)
        {
            writeText(i, buyIsSelected);
            buyIsSelected = false;
        }
        firstRun = false;
    }

    void writeText(int i, bool isSelected)
    {
        string cursor = "*  ";
        if (isSelected & !inPreview)
        {
            cursor = ">  ";
        }
        GameObject placeholder = textBoxArray[i];
        boxText = placeholder.GetComponent<TMP_Text>();
        if (shopText[i] == "")
        {
            boxText.text = "";
        }
        else
        {
            if (firstRun)
            {
                itemCount = itemCount + 1;
            }
            boxText.text = cursor + shopText[i];
        }
        textBoxArray[i] = placeholder;

    }
}
