using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


    public static class ENUMS
    {
        //Character
        public enum SKILLS { Nahkampf, Hacken, Projektilwaffen, HandFirewaffen };
        public enum ATTRIBUTE { Stärke, Geschicklichkeit, Konstitution, Intelligenz, Charisma };
        public enum ENVIROMENT { Hunger, Durst, Müdigkeit, Tragkapazität };
        
        //ITEMS
        //public enum ITEMTYP { NahEinhand, NahZweihand, Brust, Beine, Füße, Kopf, Arme, Hände, Verbrauch, Quest, Undefined };
        

        public enum ITEMTYPE { Ausrüstung, Verbrauch, Quest, Undefined };
        public enum ITEMSLOT { Einhand, Zweihand, Brust, Bein, Fuß, Kopf, Arm, Ring, Schulter, Hals,Undefined}

        public enum DAMAGETYPE { Physical, Water, Fire, Air, Earth, Poision, Undefined };

        public enum BUFFS{ Health, HealthPerSecond, Poison, Damage, DamagePerSecond };


        public struct InventoryItem
        {
            public GameObject itemObject;
            public int quantity;
            public float status;
            public float weightTotal;
            public float volumenTotal;
            public float valueTotal;
        }
    }

