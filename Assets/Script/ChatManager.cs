using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    public GameObject talkPanel;
    public Text dialogText;
    public bool isAction;
    public void Action()
    {
        if(isAction) { // Exit dialog
            isAction = false;  
        }
        else { // Enter dialog
            isAction = true;
            dialogText.text = "Hi";
        }
        talkPanel.SetActive(isAction);
    }
}
