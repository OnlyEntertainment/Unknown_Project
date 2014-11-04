using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

using ITEMTYP = ENUMS.ITEMTYPE;
using damageType = ENUMS.DAMAGETYPE;

public class GameProperties : MonoBehaviour     
{
    //public Dictionary<String,Item> items = new Dictionary<String,Item>();
    public GameObject guiInventoryWindow = null;
    public GameObject guiInventoryGrid = null;
    public GameObject guiInventoryEntry = null;


    public static string focusedItemText = "";

    public static Dictionary<string,GameObject> items = new Dictionary<string,GameObject>();

    public static bool isMenuOpen = false;
     
    //void Start()
    //{ 
        
        
    //    /*
    //    foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
    //    {
    //        if (gameObject.tag == "Item")
    //        {
    //            Debug.Log("Adde Item = " + gameObject.GetComponent<Item>().itemName);
    //            gameObject.ge
    //            items.Add(gameObject.GetComponent<Item>().id, gameObject);
    //        }
    //    }*/
    //}





}
