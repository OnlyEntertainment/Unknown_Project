using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using InventoryItem = ENUMS.InventoryItem;

public class GUIController : MonoBehaviour
{

    public KeyBindings keyBinding;
    public GameObject playerObject;
    public Camera playerCamera;
    public Camera guiCamera;

    public GameObject inventoryWindow;
    public UIGrid inventoryGrid;
    public GameObject inventoryEntryPrefab;
    public Inventory inventory;
    public InventoryEntry hoveredItem = null;

    public Context_Menu contextMenu;

    public bool showInventory = false;
    public bool showCharacter = false;
    public bool showPauseMenu = false;

    public bool showAnyWindow = false;

    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //hoveredItem = null;

        if (showInventory ||
            showCharacter ||
            showPauseMenu)
        { showAnyWindow = true; }
        else
        { showAnyWindow = false; }


        if (Input.GetKeyDown(keyBinding.keyToggleInventory))
        {
            showInventory = !showInventory;
            inventoryWindow.SetActive(showInventory);
            hoveredItem = null;
            if (showInventory) RefreshInventoryWindow();
        }

        if ((Input.GetMouseButton(0) || Input.GetMouseButton(1)) && contextMenu.gameObject.active)
        { contextMenu.gameObject.SetActive(false); }

        if (Input.GetMouseButton(1) && showInventory && hoveredItem != null) 
        {
            
            Vector3 mousePos = Input.mousePosition;

            contextMenu.transform.localPosition = new Vector2(mousePos.x - Screen.width/2, mousePos.y - Screen.height/2);
            contextMenu.gameObject.SetActive(true);
        }

    }


    public void RefreshInventoryWindow()
    {
        foreach (Transform gridEntry in inventoryGrid.GetChildList())
        {
            DestroyImmediate(gridEntry.gameObject);
        }

        foreach (InventoryItem item in inventory.inventory)
        {
            GameObject entry = (GameObject)GameObject.Instantiate(inventoryEntryPrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
            entry.transform.parent = inventoryGrid.transform;
            entry.transform.localScale = new Vector3(1, 1, 1);
            InventoryEntry inventoryEntry = entry.GetComponent<InventoryEntry>();
            inventoryEntry.playerCamera = playerCamera;
            inventoryEntry.inventoryItem = item;
            inventoryEntry.playerObject = playerObject;
            inventoryEntry.itemImage.mainTexture = item.itemObject.GetComponent<Item>().image;
            inventoryEntry.itemName.text = item.itemObject.GetComponent<Item>().itemName;
            inventoryEntry.guiController = this;
            inventoryEntry.PostStart();
        }
        inventoryGrid.Reposition();
        inventoryGrid.transform.parent.gameObject.GetComponent<UIScrollView>().ResetPosition();
        //List<GameObject> children = new List<GameObject>();
        //for (int i = 0; i < inventoryWindow.transform.GetChild(0).GetChild(0).childCount; i++)
        //{ children.Add(inventoryWindow.transform.GetChild(0).GetChild(0).GetChild(i).gameObject); }

        //while (children.Count > 0)
        //{ 
        //    DestroyImmediate(children[0]);
        //    children.RemoveAt(0);
        //}

        //foreach (InventoryItem item in inventory.inventory)
        //{
        //    GameObject entry = (GameObject) GameObject.Instantiate(inventoryEntry);
        //    entry.GetComponent<InventoryEntry>().itemImage.mainTexture = item.itemObject.GetComponent<Item>().image;
        //    entry.GetComponent<InventoryEntry>().itemName.text = item.itemObject.GetComponent<Item>().itemName;
        //    entry.transform.parent = inventoryWindow.transform.GetChild(0).GetChild(0);
        //}
        //UIGrid inventoryGrid = inventoryWindow.transform.GetChild(0).GetChild(0).gameObject.GetComponent<UIGrid>();
        //inventoryGrid.Reposition();

    }

}
