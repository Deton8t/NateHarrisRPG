using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemID;
    private bool isColliding;
    private bool canPickup;
    private GameObject collidingPlayer;
    public Inventory characterInventory;
    private int itemCount;
    void Start()
    {
        canPickup = true;

    }

    void FixedUpdate()
    {
        itemCount = ItemSheet.itemCount;
        triggerCheck();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!(col.tag == "Player"))
        {
            return;
        }
        isColliding = true;
        collidingPlayer = col.gameObject.GetComponent<GameObject>();
        characterInventory = col.gameObject.GetComponent<Inventory>();
    }

    void OnTriggerExit2D(Collider2D col)
    {
        isColliding = false;
        collidingPlayer = null;
        characterInventory = null;
    }

    void triggerCheck()
    {
        if (!isColliding)
        {
            return;
        }
        if (!canPickup)
        {
            return;
        }
        if (Input.GetKey(ChrBinds.interact))
        {
            canPickup = false;
            itemCollect();
        }
    }

    void itemCollect()
    {
        characterInventory.itemInventory[itemCount] = itemID;
        itemCount++;
        ItemSheet.itemCount = itemCount;
        Destroy(this.gameObject);
    }
}
