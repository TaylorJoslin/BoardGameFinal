using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public List<Player> players;
    private int currentPlayerIndex = 0;

    void Start()
    {
        // Initialize players list with references to player objects
        players = new List<Player>((IEnumerable<Player>)FindFirstObjectByType<Player>());
        
        
        StartTurn();
    }

    void StartTurn()
    {
        Player currentPlayer = players[currentPlayerIndex];
        Debug.Log("Player " + currentPlayer.name + "'s turn");
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
