using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageSystem : MonoBehaviour
{
    [SerializeField] TMP_Text messageText;


    //call the OnUpdateMessage function to pass text
     void OnEnable()
    {
        ClearMessage();
        GameManager.OnUpdateMessage += RecieveMessage;
        Player.OnUpdateMessage += RecieveMessage;
        TileNode.OnUpdateMessage += RecieveMessage;
    }

    void OnDisable()
    {
        GameManager.OnUpdateMessage -= RecieveMessage;
        Player.OnUpdateMessage -= RecieveMessage;
        TileNode.OnUpdateMessage -= RecieveMessage;
    }

    void RecieveMessage(string _message)
    {
        messageText.text = _message;
    }

    void ClearMessage() //clears text box
    {
        messageText.text = " ";
    }
}
