using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
//using UnityEditor;

using InventoryItem = ENUMS.InventoryItem;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();
    
    public Camera playerCamera;
    public GUIController guiController;
    public KeyBindings keyBinding;

    public void Additem(GameObject itemObject)//, float status)
    {
        InventoryItem inventoryItem;

        Item item;

        for (int i = 0; i < inventory.Count; i++)
        {
            item = inventory[i].itemObject.GetComponent<Item>();
            
            if (item == itemObject.GetComponent<Item>() && inventory[i].status == itemObject.GetComponent<Item>().status)
            {
                inventoryItem = inventory[i];
                inventoryItem.quantity++;
                
                inventoryItem.valueTotal = (item.value * inventoryItem.quantity) * (inventoryItem.status / 100.0f);
                inventoryItem.weightTotal = (item.weight * inventoryItem.quantity);
                inventory[i] = inventoryItem;

                //guiController.RefreshInventoryWindow();
                return;
            }
        }


        item = itemObject.GetComponent<Item>();

        inventoryItem = new InventoryItem();
        inventoryItem.itemObject = itemObject;
        inventoryItem.status = item.status;
        inventoryItem.quantity = 1;
        inventoryItem.valueTotal = (item.status / 100.0f);
        inventoryItem.weightTotal = item.weight;

        inventory.Add(inventoryItem);

        //guiController.RefreshInventoryWindow();
    }

    public bool RemoveItem(GameObject itemObject)
    {
        return RemoveItem(itemObject, 999, false);
    }

    public bool RemoveItem(GameObject itemObject, float status)
    {
        return RemoveItem(itemObject, status, true);
    }

    private bool RemoveItem(GameObject itemObject, float quality, bool checkQuality)
    {
        InventoryItem inventoryItem;
        Item item;

        for (int i = 0; i < inventory.Count; i++)
        {
            item = inventory[i].itemObject.GetComponent<Item>();

            if (item == itemObject.GetComponent<Item>() && ((!checkQuality) || (checkQuality && inventory[i].status == itemObject.GetComponent<Item>().status)))
            //if (inventory[i].item == item & ( (!checkQuality ) || (checkQuality && inventory[i].quality == quality)))
            {
                inventoryItem = inventory[i];
                if (inventoryItem.quantity == 1)
                {
                    inventory.RemoveAt(i);
                }
                else
                {
                    inventoryItem.quantity--;
                    inventoryItem.valueTotal = (item.value * inventoryItem.quantity) * (inventoryItem.status / 100.0f);
                    inventoryItem.weightTotal = (item.weight * inventoryItem.quantity);
                    inventory[i] = inventoryItem;
                }
                //guiController.RefreshInventoryWindow();
                return true;
            }
        }
        return false;

    }

    void Start()
    {

    }


    void Update()
    {
        if (playerCamera != null) FocusItemAndPickUp();

        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Inventory:");
            foreach (InventoryItem inventoryItem in inventory)
            {
                Item item = inventoryItem.itemObject.GetComponent<Item>();
                Debug.Log(item.itemName + " - " + inventoryItem.quantity);

            }
        }
    }


    private void FocusItemAndPickUp()
    {
        GameProperties.focusedItemText = "";


        RaycastHit hit_MouseCourser;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit_MouseCourser, 3)) //512 = Layer 9 Terrain
        {

            GameObject itemObject = hit_MouseCourser.collider.transform.gameObject;
            Item item = itemObject.GetComponent<Item>(); ;



            while (item == null && itemObject != null)
            {
                if (itemObject.transform.parent != null)
                {
                    itemObject = itemObject.transform.parent.gameObject;
                    item = itemObject.GetComponent<Item>();
                }
                else
                {
                    itemObject = null;
                }
            }
            if (item != null)
            {
                //Debug.Log(item.itemName);
                GameProperties.focusedItemText = item.itemName;
                if (Input.GetKeyDown(keyBinding.keyItemPickUP))
                {
                    Debug.Log("Destroy Parent");

                    string prefabPath = item.prefabPath;
                    Debug.Log(prefabPath);
                    Additem((GameObject) Resources.Load<GameObject>(prefabPath));//.GetComponent<Item>().prefab);
                    //PrefabUtility.GetPrefabParent(itemObject));
                    
                    
                    //Resources.FindObjectsOfTypeAll(typeof(GameObject)).
                    //GameObjects " + Resources.FindObjectsOfTypeAll(typeof(GameObject)).Length

                    Destroy(itemObject);
                    
                }
            }
        }
    }


    private GameObject FindPrefab (GameObject objectToFind)
    {
        return GameProperties.items[objectToFind.GetComponent<Item>().id];
    }

}
