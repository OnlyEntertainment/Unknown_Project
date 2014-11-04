using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

class Quest_Old : UnityEngine.Object
    {
        public string questTitle;

        public GameObject questGeber = null;
        public Item questItem = null;

        public GameObject questVorherigeQuest = null;

        public Boolean questAccepted = false;
        public Boolean questSolved = false;

        public float questRewardExperience = 0.0f;
        public Item questRewardItem1 = null;
        public Item questRewardItem2 = null;
        public Item questRewardItem3 = null;

        public String questLogText = "";

        public void Dialog()
        { }

        public string GetInitText()
        {
            return "";
        }

    }

 