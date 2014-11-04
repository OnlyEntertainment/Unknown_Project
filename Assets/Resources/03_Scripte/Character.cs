using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

using ATTRIBUTE = ENUMS.ATTRIBUTE;
using SKILLS = ENUMS.SKILLS;
using ENVIROMENT = ENUMS.ENVIROMENT;


class Character : MonoBehaviour
{


    public Dictionary<ATTRIBUTE, int> attribute = new Dictionary<ATTRIBUTE, int>();
    public Dictionary<SKILLS, int> skills = new Dictionary<SKILLS, int>();
    public Dictionary<ENVIROMENT, float> enviroment = new Dictionary<ENVIROMENT, float>();

    public Dictionary<Item, int> inventory = new Dictionary<Item, int>();

    void Awake()
    {
        for (int i = 0; i < Enum.GetValues(typeof(ATTRIBUTE)).Length; i++)
        { attribute[(ATTRIBUTE)i] = 10; }

        for (int i = 0; i < Enum.GetValues(typeof(SKILLS)).Length; i++)
        { skills[(SKILLS)i] = 0; }

        for (int i = 0; i < Enum.GetValues(typeof(ENVIROMENT)).Length; i++)
        { enviroment[(ENVIROMENT)i] = 0f; }
    }


    void OnLoad()
    {

    }

    private void Update()
    {
        float modifikator = 0.15f;

        ModEnviroment(ENVIROMENT.Durst, 2f * modifikator * Time.deltaTime);
        ModEnviroment(ENVIROMENT.Hunger, 1f * modifikator * Time.deltaTime);
        ModEnviroment(ENVIROMENT.Müdigkeit, 1.5f * modifikator * Time.deltaTime);
    }

    private void ModEnviroment(ENVIROMENT env, float value)
    {
        enviroment[env] = Mathf.Clamp(enviroment[env] + value, 0f, 100f);

    }

    //public void GetItem(Item item) { GetItem(item, 1); }
    //public void GetItem(Item item, int quantity)
    //{
    //    for (int i = 1; i <= quantity; i++)
    //    {
    //        if ((GetInventoryGewicht() + item.weight) <= enviroment[ENVIROMENT.Tragkapazität])
    //        {
    //            if (inventory.ContainsKey(item))
    //            { inventory[item]++; }
    //            else
    //            { inventory.Add(item, 1); }
    //        }
    //        else
    //        { return; }
    //    }
    //}

    //public float GetInventoryGewicht()
    //{
    //    float tmpGewicht = 0;
    //    foreach (Item item in inventory.Keys)
    //    {
    //        tmpGewicht += item.weight * inventory[item];
    //    }
    //    return tmpGewicht;
    //}

}

