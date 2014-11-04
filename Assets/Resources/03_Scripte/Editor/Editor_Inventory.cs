using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;


using InventoryItem = ENUMS.InventoryItem;

[CustomEditor(typeof(Inventory))]
public class Editor_Inventory : Editor
{

    private string text = "";

    //private ArrayList objects = new ArrayList();
    private String[] objects = new String[0];

    int auswahl;


    public override void OnInspectorGUI()
    {
        if (objects.Length == 0) GetObjects();


        base.OnInspectorGUI();

        Inventory inventoryClass = (Inventory)target;

        List<InventoryItem> inventory = inventoryClass.inventory;
        //inventory[0].

        auswahl = EditorGUILayout.Popup(auswahl, objects);

        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory.Count == i)
            { }
            else
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(inventory[i].quantity.ToString());
                GUILayout.EndHorizontal();
            }
        }

        GUILayout.BeginHorizontal();
        text = GUILayout.TextField(text);

        if (GUILayout.Button("Set Text")) SetText(inventoryClass, text);
        GUILayout.EndHorizontal();



        if (GUILayout.Button("TESTButto"))
        {
            GetObjects();


            //    Assets

            //Debug.Log("TRET");
        }
        return;

      
        //if (objects[0] == null || objects[0] == "")GetObjects();
        
        

 

        //GUIContent test3 = new GUIContent(test);
        //auswahl = EditorGUILayout.Popup(auswahl, test2, "");

       
    }

    private void GetObjects()
    {
        //GameObject[] allObjects = (GameObject) Resources.FindObjectsOfTypeAll(typeof(GameObject));
        //objects = new String[Resources.FindObjectsOfTypeAll(typeof(GameObject)).Length];
        ArrayList tmpList = new ArrayList();
        //for (int i = 0; i < Resources.FindObjectsOfTypeAll(typeof(GameObject)).Length;i++)
        foreach (GameObject obj in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
        {

            //GameObject obj = (GameObject) Resources.FindObjectsOfTypeAll(typeof(GameObject))[i];
            //if (obj.tag == "Item") objects[i] = obj.name;
            //else objects[i] = "";

            if (obj.tag == "Item")
            {
                tmpList.Add(obj.name);
                Debug.Log(obj.name);
            }
            //objects.Add(obj.name);
        }
        objects = new String[tmpList.Count];
        for (int i = 0; i < tmpList.Count; i++)
        {
            objects[i] = tmpList[i].ToString();
        }
        //objects = tmpList.ToString();// .ToArray(typeof(String));
    }

    private void SetText(Inventory item, String text)
    {
        item.name = text;
    }
}