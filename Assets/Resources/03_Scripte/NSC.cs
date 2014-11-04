using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

class NSC
{
    public List<Quest> quests = null;
    public bool isTrader = false;

    public bool isFocused = false; //TODO Private machen

    void Update()
    {
        isFocused = false;
    }

    void OnGUI()
    {
        float useLabelWidth = 100.0f;
        float useLabelHeight = 50.0f;

        if (isFocused &
            (
            isTrader ||
            quests != null
            )
           )
        {
            GUILayout.BeginArea(new Rect(Screen.width / 2 - useLabelWidth / 2, Screen.height - useLabelHeight - 100, useLabelWidth, useLabelHeight));
            GUI.Label(new Rect(0, 0, useLabelWidth, useLabelHeight), "Press E to talk");
            GUILayout.EndArea();
        }
    }

    void OnMouseOver()
    { 
        isFocused = true; 
    }

    void Dialog()
    {
        
        float dialogBoxWidth = 500.0f;
        float dialogBoxHeight = 200.0f;
        Time.timeScale = 0;

        GUILayout.BeginArea(new Rect(Screen.width / 2 - dialogBoxWidth / 2, Screen.height - dialogBoxHeight - 100, dialogBoxWidth, dialogBoxHeight));
        foreach (Quest quest in quests)
        {
            if (quest.questSolved) quests.Remove(quest);
            else
            {
                //GUI.BeginGroup(new Rect())
                //if GUI.Button( quest.GetInitText()

            }

        }
        GUILayout.EndArea();

    }


}
