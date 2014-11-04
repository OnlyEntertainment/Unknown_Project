using UnityEngine;
using UnityEditor;
using System.Collections;

public class MenuCreateItem
{

    [MenuItem("Inventory/CreateItem")]
    static void CreateAsset()
    {
        ScriptableObject asset = ScriptableObject.CreateInstance<ScriptableItem>();
        AssetDatabase.CreateAsset(asset, "Assets/NewInventoryItem.asset");
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;


    }
}
