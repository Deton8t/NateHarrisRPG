using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInfoHolder : MonoBehaviour
{
    public static List<string> textLines;
    public static List<string> mainMenuLines;
    public static List<int> itemIDs;
    public static void initShopText(string shopName, int index)
    {
        if (shopName == "JakeShop")
        {
            if (index == 0)
            {
                textLines = new List<string>
                {
                "Meth Amphetamine (99% pure)",
                "Silly String",
                "Fart Potion",
                "Blank Item",
                "Blank Item2",
                "Haha",
                ""
                };
                itemIDs = new List<int>
                {
                    3,
                    4,
                    5,
                    6,
                    7,
                    8
                };
            }
            if (index == 1)
            {
                textLines = new List<string> { };
                int i = 0;
                while (i < ItemSheet.itemCount + 1)
                {
                    textLines.Add("no items To sell");
                    i++;
                }
                if (textLines.Count < 4)
                    for (int indexer = 0; indexer < (5 - (textLines.Count - 1)); indexer++)
                    {
                        textLines.Add("");
                    }
            }
            if (index == 2)
            {
                textLines = new List<string>
                {
                    "PlaceHolder",
                    "",
                    "",
                    ""
                };
            }
        }
        if (shopName == "BuyMenu1")
        {
            mainMenuLines = new List<string>
            {
                "BUY",
                "SELL",
                "CHAT",
            };
        }
        if (shopName == "Sell")
        {
            mainMenuLines = new List<string>
            {
                "PlaceHolder 1",
                "PlaceHolder 2",
                "PlaceHolder 3",
                "PlaceHolder 4",
                ""
            };
        }
    }
}
