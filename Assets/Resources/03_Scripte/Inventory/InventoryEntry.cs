using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryEntry : MonoBehaviour {

    public Camera playerCamera;
    //public InventoryEntryTooltip inventoryEntryTooltip;
    public ENUMS.InventoryItem inventoryItem;
    private Item item;
    public GameObject playerObject;
    public GUIController guiController;

    public UITexture itemImage;
    public UILabel itemName;

    private bool dontDoAnythinWithThisItem = true;



	// Use this for initialization
	void Start () 
    {
        playerCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PostStart()
    {
        dontDoAnythinWithThisItem = true;

        item = inventoryItem.itemObject.GetComponent<Item>();

        UIPopupList uipopupList = this.gameObject.GetComponent<UIPopupList>();
        
        uipopupList.items.Add(item.itemName);
        uipopupList.value = item.itemName;
        

        if (item.isEquipable) uipopupList.items.Add("Equip"); 
        if (item.isUseable) uipopupList.items.Add("Use");
        if (item.isDropable) uipopupList.items.Add("Drop");

        

        dontDoAnythinWithThisItem = false;
    }



    public void PopUp_OnValueChange()
    {
        if (!dontDoAnythinWithThisItem)
        {
            string choiceString = this.gameObject.GetComponent<UIPopupList>().value;
            Inventory inventory;

            switch (choiceString)
            {
                case "Equip":
                    break;
                case "Use":
                    Debug.Log(dontDoAnythinWithThisItem +" - Benutze Item: " + item.itemName);
                    inventory = playerObject.GetComponent<Inventory>();
                    
                    for (int i = 0; i < item.buffs.Length; i++)
                    //foreach (ENUMS.BUFFS buff in item.buffs)
                    {
                        ENUMS.BUFFS buff = item.buffs[i];
                        switch (buff)
                        {
                            case ENUMS.BUFFS.Health:
                                playerObject.GetComponent<Player_Data>().Heal(item.values[i]);
                                break;
                            default:
                                break;
                        }
                    }

                    inventory.RemoveItem(item.gameObject, item.status);
                    guiController.RefreshInventoryWindow();
                    break;
                case "Drop":
                    inventory = playerObject.GetComponent<Inventory>();
                    Vector3 posToDrop = new Vector3(playerObject.transform.position.x,playerObject.transform.position.y,playerObject.transform.position.z);
                    posToDrop.y += 0.5f;
                    posToDrop += playerObject.transform.forward*0.5f;
                    GameObject itemToDrop = (GameObject) Instantiate(item.gameObject,posToDrop,item.gameObject.transform.rotation);
                    

                    inventory.RemoveItem(item.gameObject, item.status);
                    guiController.RefreshInventoryWindow();
                    break;
                default:
                    break;
            }
        }
    }

}
