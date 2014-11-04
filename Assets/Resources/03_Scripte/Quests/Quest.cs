using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

class Quest
{
    public string questTitle = "Beginning Test";

    public GameObject questGeber;
    public GameObject questItem = null;

    public GameObject questVorherigeQuest = null;

    public Boolean questAccepted = false;
    public Boolean questSolved = false;

    public float questRewardExperience = 0.0f;
    public GameObject questRewardItem1 = null;
    public GameObject questRewardItem2 = null;
    public GameObject questRewardItem3 = null;


    public String questLogText = "";


    void Awake()
    {
    }

    public void Dialog()
    {

    }

    void OnMouseOver()
    {

    }
    public string GetInitText()
    {
        if (!questSolved)
        {
            //if (!questAccepted && Inventory.ContainsItem(questItem))
            //{return "Ich habe dieses Buch gefunden. Darin steht dein Name, ist das deins?";}
            //else if (questAccepted && Inventory.ContainsItem(questItem))
            //{ return "Ich habe das Buch gefunden das du gesucht hast."; }
            //else if (questAccepted && !Inventory.ContainsItem(questItem))
            //{return "Wie war das mit dem Buch das du verloren hast?"; }
        }
        return "";

    }


}




