using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

public class TurnManager : MonoBehaviour
{
    public List<Stone> players;
    private int currentPlayerIndex = 0;

    [System.Obsolete]
    void Start()
    {
        // Initialize players list with references to player objects
        players = new List<Stone>(FindObjectsOfType<Stone>());
        
        
        StartTurn();
    }

    void StartTurn()
    {
        Stone currentPlayer = players[currentPlayerIndex];
        Debug.Log( currentPlayer.name + "'s turn");
        // Implement any UI updates to indicate current player's turn
        currentPlayer.TakeTurn(); // Call function to handle player's turn actions
    }

    public void EndTurn()
    {
        // Increment index to move to next player
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
        StartTurn();
    }
}

public class Player : MonoBehaviour
{
    public void TakeTurn()
    {
        // Implement player's turn logic here
        Debug.Log("Taking turn...");
    }
}
