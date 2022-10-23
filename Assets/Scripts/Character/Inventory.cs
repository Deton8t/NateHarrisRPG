using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{

    public int[] itemInventory;
    public TextAsset itemTable;

    void Start()
    {
        itemInventory = new int[50];
        string[][] organizedItemData = new string[255][];
        itemTable = Resources.Load<TextAsset>("Tables/ItemTable");
        string[] data = itemTable.text.Split(new char[] { '\n' });
        int i = 0;
        while (i < data.Length - 1)
        {
            i++;
            Debug.Log(data[i]);
            string[] dataHolder = data[i].Split(new char[] { ',' });
            Debug.Log(dataHolder[0]);
            organizedItemData[i - 1] = dataHolder;
            ItemSheet.itemList = organizedItemData;
        }
    }
}
