using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

//code by Taylor Joslin
public class TurnManager : MonoBehaviour
{
    bool startGame, P1Turn, P2Turn;

    public GameObject P1Move, P2Move;
    public GameObject P1Roll, P2Roll;

    private void Start()
    {
        startGame = true;
        P1Move.SetActive(false);
    }

    private void Update()
    {
        if (startGame)
        {
            P1Turn = true;

            if (P1Turn)
            {
                Debug.Log("Player 1's turn");
                P1Roll.SetActive(true);

            }
        }
    }
}
