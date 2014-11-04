using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using ATTRIBUTE = ENUMS.ATTRIBUTE;
using SKILLS = ENUMS.SKILLS;
using ENVIROMENT = ENUMS.ENVIROMENT;

using InventoryItem = ENUMS.InventoryItem;

public class HUD : MonoBehaviour
{

    enum CHARACKTERPAGE { Attribute, Wiederstände, Sontiges };
    private CHARACKTERPAGE charackterPage = CHARACKTERPAGE.Attribute;

    public GUISkin skinHUD;

    Character character;

    private bool showCharacter = false;
    private bool showInventory = false;


    private Vector2 inventoryRightScroll = Vector2.zero;

    public GameObject guiInventoryWindow = null;
    public GameObject guiInventoryGrid = null;
    public GameObject guiInventoryEntry = null;

    // Use this for initialization
    void Start()
    {
        character = gameObject.GetComponent<Character>();
        guiInventoryWindow = GameObject.Find("Game_Globals").GetComponent<GameProperties>().guiInventoryWindow;
        guiInventoryGrid = guiInventoryWindow.transform.FindChild("InventoryScrollView").FindChild("InventoryGrid").gameObject;
        guiInventoryEntry = GameObject.Find("Game_Globals").GetComponent<GameProperties>().guiInventoryEntry;
    }

    public void test ()
    {Debug.Log("TEST");}

    // Update is called once per frame
    void Update()
    {


        guiInventoryGrid.GetComponent<UIGrid>().Reposition();
        if (Input.GetKeyDown(KeyCode.C)) { showCharacter = !showCharacter; }
        if (Input.GetKeyDown(KeyCode.I))
        {
            showInventory = !showInventory;

            List<GameObject> inventoryEntries = new List<GameObject>();
            for (int i = 0; i < guiInventoryGrid.transform.childCount; i++) { inventoryEntries.Add(guiInventoryGrid.transform.GetChild(i).gameObject); }
            foreach (GameObject go in inventoryEntries) { GameObject.Destroy(go); }

            if (showInventory)
            {
                Inventory inventory = gameObject.GetComponent<Inventory>();
                foreach (InventoryItem inventoryItem in inventory.inventory)
                {
                    Item item = inventoryItem.itemObject.GetComponent<Item>();

                    GameObject inventoryObject = (GameObject)Instantiate(guiInventoryEntry);
                    //inventoryObject.transform.IsChildOf(guiInventoryGrid.transform);
                    
                    inventoryObject.transform.parent = guiInventoryGrid.transform;

                    inventoryObject.transform.FindChild("Image").GetComponent<UITexture>().mainTexture = item.image;
                    inventoryObject.transform.FindChild("ItemName").GetComponent<UILabel>().text = item.itemName;
                    inventoryObject.transform.FindChild("ItemDescription").GetComponent<UILabel>().text = item.itemSlot.ToString() + " / " + item.itemType.ToString();
                    inventoryObject.transform.localScale = new Vector3(1, 1, 1);
                }
                guiInventoryGrid.GetComponent<UIGrid>().Reposition();
            }

        }

        guiInventoryWindow.SetActive(showInventory);

        //GameObject.Find("Game_Globals").GetComponent<GameProperties>().guiInventoryWindow.SetActive(showInventory);
        //GameProperties.guiInventoryWindow.tag = showInventory.ToString();// .enab .SetActive(showInventory);

        if (Input.GetKeyDown(KeyCode.J))
        {
            Inventory inventory = gameObject.GetComponent<Inventory>();
            if (inventory != null)
            {
                foreach (InventoryItem inventoryItem in inventory.inventory)
                {
                    Item item = inventoryItem.itemObject.GetComponent<Item>();
                    Debug.Log(item.itemName + ", " +
                        "Anzahl = " + inventoryItem.quantity + ", " +
                        "Status = " + inventoryItem.status + ", " +
                        "Wert = " + item.value + ", " +
                        "Wert-Total = " + inventoryItem.valueTotal + ", " +
                        "Gewicht = " + item.weight + ", " +
                        "Gewicht-Total = " + inventoryItem.weightTotal);
                }

            }


        }

        if (showCharacter || showInventory) GameProperties.isMenuOpen = true; else GameProperties.isMenuOpen = false;


    }



    void OnGUI()
    {

        GUILayout.Label("All " + Resources.FindObjectsOfTypeAll(typeof(UnityEngine.Object)).Length);
        GUILayout.Label("Textures " + Resources.FindObjectsOfTypeAll(typeof(Texture)).Length);
        GUILayout.Label("AudioClips " + Resources.FindObjectsOfTypeAll(typeof(AudioClip)).Length);
        GUILayout.Label("Meshes " + Resources.FindObjectsOfTypeAll(typeof(Mesh)).Length);
        GUILayout.Label("Materials " + Resources.FindObjectsOfTypeAll(typeof(Material)).Length);
        GUILayout.Label("GameObjects " + Resources.FindObjectsOfTypeAll(typeof(GameObject)).Length);
        GUILayout.Label("Components " + Resources.FindObjectsOfTypeAll(typeof(Component)).Length);

        GUI.Box(new Rect(Screen.width / 2 - 5, Screen.height / 2 - 5, 10, 10), "");

        if (GameProperties.focusedItemText != "") GUI.TextArea(new Rect(0, Screen.height / 2, 100, 50), GameProperties.focusedItemText);
        //Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 10, Color.red,1);


        if (showCharacter) { DrawCharacter(); }
        if (showInventory) { DrawInventory(); }
        //DrawEnviroment();
    }

    void DrawInventory()
    {
        //while (guiInventoryGrid.transform.GetChild(0) != null)
        //{ GameObject.Destroy(guiInventoryGrid.transform.GetChild(0).gameObject); }





        Inventory inventory = gameObject.GetComponent<Inventory>();


        foreach (InventoryItem inventoryItem in inventory.inventory)
        {


            ////foreach (KeyValuePair<Item, int> itemEntry in inventory.inventory)
            ////{
            //Item item = inventoryItem.itemObject.GetComponent<Item>();
            //GUI.DrawTexture(new Rect(entryX, entryY, entryHeight, entryHeight), item.image, ScaleMode.ScaleToFit);
            //Rect itemRect = new Rect(entryX + entryHeight + entryXSpacing, entryY, rechtsBreite - entryXSpacing * 2 - entryHeight, entryHeight);
            //GUI.Label(itemRect, inventoryItem.quantity.ToString() + "X " + item.itemName + " [" + inventoryItem.valueTotal.ToString() + "/" + inventoryItem.weightTotal.ToString() + "]");
            ////GUI.Button(itemRect
            //entryY += entryHeight + entryYSpacing;


        }


    }
    void DrawInventory_OLD()
    {
        float boxHoehe = 500.0f;
        float boxBreite = 600.0f;

        float abstand = 10.0f;
        float abstandMitte = 15.0f;

        float linksBreite = (boxBreite - 2 * abstand - abstandMitte) / 2;
        float linksHoehe = boxHoehe - 2 * abstand;

        float rechtsBreite = (boxBreite - 2 * abstand - abstandMitte) / 2;
        float rechtsHoehe = boxHoehe - 2 * abstand;


        float bildschirmabstandLinksRechts = Mathf.Clamp((Screen.width - 2 * boxBreite) / 3, 0, (Screen.width - 2 * boxBreite) / 3);
        //GUILayout.BeginArea(new Rect(Screen.width / 2 - boxBreite / 2, Screen.height / 2 - boxHoehe / 2, boxBreite, boxHoehe));
        //GUI.Box(new Rect(Screen.width - boxBreite - bildschirmabstandLinksRechts, Screen.height / 2 - boxHoehe / 2, boxBreite, boxHoehe),"");

        GUILayout.BeginArea(new Rect(Screen.width - boxBreite - bildschirmabstandLinksRechts, Screen.height / 2 - boxHoehe / 2, boxBreite, boxHoehe));
        GUI.Box(new Rect(0, 0, boxBreite, boxHoehe), "");

        //Linke Seite
        GUILayout.BeginArea(new Rect(abstand, abstand, linksBreite, linksHoehe));
        GUI.Box(new Rect(0, 0, linksBreite, linksHoehe), "");

        GUILayout.EndArea();
        //Linke Seite


        //Rechte Seite
        //GUILayout.BeginArea(new Rect(linksBreite + abstand + abstandMitte, abstand, rechtsBreite, rechtsHoehe));
        //inventoryRightScroll = GUI.BeginScrollView(new Rect(linksBreite + abstand + abstandMitte, abstand, rechtsBreite, rechtsHoehe), inventoryRightScroll, new Rect(linksBreite + abstand + abstandMitte, abstand, rechtsBreite, rechtsHoehe));
        Rect viewRect = new Rect(linksBreite + abstand + abstandMitte, abstand, rechtsBreite, rechtsHoehe);
        Rect innerRect = new Rect(0, 0, rechtsBreite, rechtsHoehe * 2);
        inventoryRightScroll = GUI.BeginScrollView(viewRect, inventoryRightScroll, innerRect);
        GUI.Box(new Rect(0, 0, rechtsBreite, rechtsHoehe), "");


        float entryHeight = 25.0f;
        float entryYSpacing = 10.0f;
        float entryXSpacing = 5.0f;
        float entryX = entryXSpacing;
        float entryY = entryYSpacing;

        Inventory inventory = gameObject.GetComponent<Inventory>();


        foreach (InventoryItem inventoryItem in inventory.inventory)
        {


            //foreach (KeyValuePair<Item, int> itemEntry in inventory.inventory)
            //{
            Item item = inventoryItem.itemObject.GetComponent<Item>();
            GUI.DrawTexture(new Rect(entryX, entryY, entryHeight, entryHeight), item.image, ScaleMode.ScaleToFit);
            Rect itemRect = new Rect(entryX + entryHeight + entryXSpacing, entryY, rechtsBreite - entryXSpacing * 2 - entryHeight, entryHeight);
            GUI.Label(itemRect, inventoryItem.quantity.ToString() + "X " + item.itemName + " [" + inventoryItem.valueTotal.ToString() + "/" + inventoryItem.weightTotal.ToString() + "]");
            //GUI.Button(itemRect
            entryY += entryHeight + entryYSpacing;


        }
        //GUILayout.EndArea();
        GUI.EndScrollView();
        //Rechte Seite


        GUILayout.EndArea();
    }

    void DrawCharacter()
    {
        float boxHoehe = 500.0f;
        float boxBreite = 600.0f;

        float abstand = 10.0f;
        float abstandMitte = 15.0f;

        float linksBreite = (boxBreite - 2 * abstand - abstandMitte) / 2;
        float linksHoehe = boxHoehe - 2 * abstand;

        float rechtsBreite = (boxBreite - 2 * abstand - abstandMitte) / 2;
        float rechtsHoehe = boxHoehe - 2 * abstand;


        float bildschirmabstandLinksRechts = Mathf.Clamp((Screen.width - 2 * boxBreite) / 3, 0, (Screen.width - 2 * boxBreite) / 3);
        //GUILayout.BeginArea(new Rect(Screen.width / 2 - boxBreite / 2, Screen.height / 2 - boxHoehe / 2, boxBreite, boxHoehe));
        //GUI.Box(new Rect(Screen.width - boxBreite - bildschirmabstandLinksRechts, Screen.height / 2 - boxHoehe / 2, boxBreite, boxHoehe),"");

        GUILayout.BeginArea(new Rect(bildschirmabstandLinksRechts, Screen.height / 2 - boxHoehe / 2, boxBreite, boxHoehe));
        GUI.Box(new Rect(0, 0, boxBreite, boxHoehe), "");



        //Linke Seite
        GUILayout.BeginArea(new Rect(abstand, abstand, linksBreite, linksHoehe));
        GUI.Box(new Rect(0, 0, linksBreite, linksHoehe), "");

        string[] content = new string[] { CHARACKTERPAGE.Attribute.ToString(), CHARACKTERPAGE.Wiederstände.ToString(), CHARACKTERPAGE.Sontiges.ToString() };
        charackterPage = (CHARACKTERPAGE)GUI.SelectionGrid(new Rect(0, 0, linksBreite, 25), (int)charackterPage, content, content.Length, skinHUD.button);
        GUI.Box(new Rect(0, 30, linksBreite, linksHoehe - 30), "");
        /*
        switch (charackterPage)
            {
            case CHARACKTERPAGE.Attribute:
                
                break;
            }
        GUI.Button(new Rect(0, 0, linksBreite / 3, 25), "Attribute", skinHUD.button.normal);

        */

        GUILayout.EndArea();
        //Linke Seite


        //Rechte Seite
        GUILayout.BeginArea(new Rect(linksBreite + abstand + abstandMitte, abstand, rechtsBreite, rechtsHoehe));
        GUI.Box(new Rect(0, 0, rechtsBreite, rechtsHoehe), "");


        DrawItemSlot(1, 2, "Kopf");
        DrawItemSlot(1, 3, "Rucksack");

        DrawItemSlot(2, 1, "Schulter L");
        DrawItemSlot(2, 2, "Hals");
        DrawItemSlot(2, 3, "Schulter R");

        DrawItemSlot(3, 1, "Arm L");
        DrawItemSlot(3, 2, "Brust");
        DrawItemSlot(3, 3, "Arm R");

        DrawItemSlot(4, 1, "Hand L");
        DrawItemSlot(4, 2, "Gürtel");
        DrawItemSlot(4, 3, "Hand R");

        DrawItemSlot(5, 1, "Waffe 1");
        DrawItemSlot(5, 2, "Hose");
        DrawItemSlot(5, 3, "Waffe 2");

        DrawItemSlot(6, 2, "Schuhe");


        GUILayout.EndArea();
        //Rechte Seite


        GUILayout.EndArea();
    }

    void DrawItemSlot(int reihe, int spalte, string title)
    {
        float y = (reihe - 1) * 80 + 10;
        float x = (spalte - 1) * 90 + 20f;
        GUI.Box(new Rect(x, y, 60, 60), title);
    }

    void DrawEnviroment()
    {

        float boxHoehe = 95.0f;
        float boxBreite = 300.0f;
        float abstand = 50.0f;

        GUILayout.BeginArea(new Rect(abstand, Screen.height - abstand - boxHoehe, boxBreite, boxHoehe));
        GUI.Box(new Rect(0, 0, boxBreite, boxHoehe), "");

        GUI.Label(new Rect(10, 10, 75, 25), "Hunger", skinHUD.label);
        GUI.Box(new Rect(95, 10, 195 / 100 * character.enviroment[ENVIROMENT.Hunger], 25), "", skinHUD.GetStyle("boxHunger"));
        GUI.Label(new Rect(95, 10, 195, 25), ((int)character.enviroment[ENVIROMENT.Hunger]).ToString() + " / 100", skinHUD.GetStyle("labelCentered"));

        GUI.Label(new Rect(10, 35, 75, 25), "Durst", skinHUD.label);
        GUI.Box(new Rect(95, 35, 195 / 100 * character.enviroment[ENVIROMENT.Durst], 25), "", skinHUD.GetStyle("boxDurst"));
        GUI.Label(new Rect(95, 35, 195, 25), ((int)character.enviroment[ENVIROMENT.Durst]).ToString() + " / 100", skinHUD.GetStyle("labelCentered"));

        GUI.Label(new Rect(10, 60, 75, 25), "Müdigkeit", skinHUD.label);
        GUI.Box(new Rect(95, 60, 195 / 100 * character.enviroment[ENVIROMENT.Müdigkeit], 25), "", skinHUD.GetStyle("boxMüdigkeit"));
        GUI.Label(new Rect(95, 60, 195, 25), ((int)character.enviroment[ENVIROMENT.Müdigkeit]).ToString() + " / 100", skinHUD.GetStyle("labelCentered"));

        //GUI.Box(new Rect(10, 10, 75, 25), "");
        //GUI.Box(new Rect(95, 10, 195, 25), "");

        GUILayout.EndArea();

    }

}
