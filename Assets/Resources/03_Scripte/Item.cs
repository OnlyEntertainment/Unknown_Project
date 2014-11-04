using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

using ITEMTYPE = ENUMS.ITEMTYPE;
using ITEMSLOT = ENUMS.ITEMSLOT;
using DAMAGETYPE = ENUMS.DAMAGETYPE;


	
//[CustomEditor(typeof(Item))] 
public class Item  : MonoBehaviour
{
    public Texture2D image;
    public String id;
    public String itemName;
    public String prefabPath;

    public float quality = 100.0f;
       
    public float weight = 1.0f;
    public float volume = 1.0f;
    public float value = 1.0f;
    public bool isSellable = true;
    public bool isUseable;
    public bool isEquipable;
    public bool isDropable = true;

    public ITEMTYPE itemType = ITEMTYPE.Undefined;
    public ITEMSLOT itemSlot = ITEMSLOT.Undefined;

    //Waffe
    public float attackSpeed = 0.0f;
    public float damagePerHit = 0.0f;
    public DAMAGETYPE damageType = DAMAGETYPE.Undefined;

    //Rüstung
    public float resistancePhysical;
    public float resistanceFire;
    public float resistanceWater;
    public float resistanceEarth;
    public float resistanceAir;
    public float resistancePoision;

    //Nur relevant als 3d Objekt
    public float status = 100.0f; 


    //

    //public Dictionary<ENUMS.BUFFS, float> buffs;

    public ENUMS.BUFFS[] buffs;
    public float[] values;




    /// <summary>
    /// DummyItem
    /// </summary>


    public Item(String id, String itemName)
    {
        this.id = id;
        this.itemName = itemName;
    }

    /// <summary>
    /// Extended DummyItem
    /// </summary>
    public Item(String id, String itemName, float gewicht, ITEMTYPE typ, float wert, bool verkaufbar, float quality, float status)
        : this(id, itemName)
    {
        this.weight = gewicht;
        this.itemType = typ;
        this.value = wert;
        this.isSellable = verkaufbar;
        this.quality = quality;
        this.status = status;

    }

    /// <summary>
    /// Verbrauchsgegenstand
    /// </summary>
    public Item(String id, String itemName, float gewicht, float wert, bool verkaufbar, float quality, float status)
        : this(id, itemName, gewicht, ITEMTYPE.Verbrauch, wert, verkaufbar, quality, status)
    {}

    /// <summary>
    /// Questitem
    /// </summary>
    public Item(String id, String itemName, float gewicht)
        : this(id, itemName, 0.0f, ITEMTYPE.Quest, 0.0f, false, 100.0f, 100.0f)
    { }

    /// <summary>
    /// Waffe
    /// </summary>
    public Item(String id, String itemName, float gewicht, ITEMSLOT itemSlot, float wert, bool verkaufbar, float quality, float status, float attackSpeed, float damage, DAMAGETYPE damageType)
        : this(id, itemName, gewicht, ITEMTYPE.Ausrüstung, wert, verkaufbar, quality, status)
    {
        this.itemSlot = itemSlot;        
        this.attackSpeed = attackSpeed;
        this.damagePerHit = damage;
        this.damageType = damageType;

        //new Item(id, name, gewicht, ITEMTYP.Ausrüstung, itemSlot, wert, true, angriffsgeschindigkeit, damage, damageType, 0, 0, 0, 0, 0, 0); }
    }
    /// <summary>
    /// Rüstung
    /// </summary>
    public Item(String id, String itemName, float gewicht, ITEMSLOT itemSlot, float wert, bool verkaufbar, float quality, float status, float resistancePhysical, float resistanceFire, float resistanceWater, float resistanceEarth, float resistanceAir, float resistancePoision)
        : this(id, itemName, gewicht, ITEMTYPE.Ausrüstung, wert, verkaufbar, quality, status)
    {
        this.itemSlot = itemSlot;   
        this.resistancePhysical = resistancePhysical;
        this.resistanceFire = resistanceFire;
        this.resistanceWater = resistanceWater;
        this.resistanceEarth = resistanceEarth;
        this.resistanceAir = resistanceAir;
        this.resistancePoision = resistancePoision;
        //new Item(id, name, gewicht, ITEMTYP.Ausrüstung, itemSlot, wert, true, 0, 0, damageType.Undefined, resistancePhysical, resistanceFire, resistanceWater, resistanceEarth, resistanceAir, resistancePoision); 
    }

    ///// <summary>
    ///// StandardItem
    ///// </summary>
    //public Item(String id, String name, float gewicht, ITEMTYP typ, ITEMSLOT itemSlot, float wert, bool verkaufbar)
    //{ 

    ////    new Item(id, name, gewicht, typ, itemSlot, wert, true, 0, 0, damageType.Undefined, 0, 0, 0, 0, 0, 0); 
    //}


    ///// <summary>
    ///// richtiger Konstruktor (Voll)
    ///// </summary>
    //public Item(
    //            String id,
    //            String name,
    //            float gewicht,
    //            ITEMTYP typ,
    //            ITEMSLOT itemSlot,
    //            float wert,
    //            bool verkaufbar,
    //            float attackSpeed,
    //            float damage,
    //            damageType damageType,
    //            float resistancePhysical,
    //            float resistanceFire,
    //            float resistanceWater,
    //            float resistanceEarth,
    //            float resistanceAir,
    //            float resistancePoision)
    //{
    //    this.id = id;
    //    this.name = name;
    //    this.gewicht = gewicht;
    //    this.typ = typ;
    //    this.itemSlot = itemSlot;
    //    this.wert = wert;

    //    this.resistancePhysical = resistancePhysical;
    //    this.resistanceFire = resistanceFire;
    //    this.resistanceWater = resistanceWater;
    //    this.resistanceEarth = resistanceEarth;
    //    this.resistanceAir = resistanceAir;
    //    this.resistancePoision = resistancePoision;

    //}


}

