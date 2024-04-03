using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

    [SerializeField] Board gameBoard;
    [SerializeField] List<Player> playerList = new List<Player>();
    [SerializeField] int currentPlayer;
    [Header("Game Settings")]
    [SerializeField] int startMoney = 200;
    [SerializeField] int goMoney = 300;
    [Header("PlayerInfo")]
    [SerializeField] GameObject playerInfoPrefab;
    [SerializeField] Transform playerPanel; //for player info prefab
    [SerializeField] List<GameObject> playerTokenList = new List<GameObject>();

    //dice info
    int[] rolledDice;
    bool rolledADouble;

    //pass start to get money
    public int GetGoMoney => goMoney;


    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
       Inititialize();
        if (playerList[currentPlayer].playertype == Player.PlayerType.AI)
        {
            Rolldice();
        }
        
    }

    void Inititialize()
    {
        //create all players
        for (int i = 0; i < playerList.Count; i++)
        {
            GameObject infoObject = Instantiate(playerInfoPrefab, playerPanel, false);
            PlayerInfo info = infoObject.GetComponent<PlayerInfo>();

            //Select randomtoken list
            int randomIndex = Random.Range(0,playerTokenList.Count);
            //initalite token
            GameObject newtoken = Instantiate(playerTokenList[randomIndex],gameBoard.route[0].transform.position, Quaternion.identity);

            playerList[i].Inititalize(gameBoard.route[0], startMoney, info,newtoken);  //gameBoard.route[0] gets a certain node on board  can use for warping
        }
    }

    public void Rolldice() //press button for human input or auto for ai
    {
        //reset last roll
        rolledDice = new int[2];
        //store rolled dice
        rolledDice[0] = Random.Range(1, 7); //will need code to wait for physical dice
        rolledDice[1] = Random.Range(1, 7);
        Debug.Log("rolled dice are: " + rolledDice[0] + " & " + rolledDice[1]);
        //check for double
        rolledADouble = rolledDice[0] == rolledDice[1];
        //3 doubles in a row -> end turn

        //move anyhow if allowed
        StartCoroutine(DelayBeforeMove(rolledDice[0] + rolledDice[1]));
        //show or hide ui

    } 

    IEnumerator DelayBeforeMove(int rolledDice)
    {
        yield return new WaitForSeconds(2f);
        //if we are allowed to move
        gameBoard.MovePlayertoken(rolledDice, playerList[currentPlayer]);
        //else we switch
    }

    public void SwitchPlayer()
    {
        currentPlayer++;
        //ROLLDOUBLE?

        //OVERFLOW CHECK
        if (currentPlayer >= playerList.Count)
        {
            currentPlayer = 0;
        }

        //IF IS AI
        if (playerList[currentPlayer].playertype == Player.PlayerType.AI)
        {
            Rolldice();
        }

        //IF HUMAN SHOW UI
    }
}
