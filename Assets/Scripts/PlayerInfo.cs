using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] TMP_Text playerNametext;
    [SerializeField] TMP_Text playerCashtext;
    

    public void SetPlayerName(string newName)
    {
        playerNametext.text = newName;
    }

    public void SetPlayerCash(int currentCash)
    {
        playerCashtext.text = "$ " + currentCash;
    }

   

    public void SetPlayerNameandCash(string _newName, int _currentCash)
    {
        SetPlayerName(_newName);
        SetPlayerCash(_currentCash);
        
    }
}
