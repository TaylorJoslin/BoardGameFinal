using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

    [SerializeField] Board gameBoard;
    public List<Player> playerList = new List<Player>();
    public int currentPlayer;
    [Header("Game Settings")]
    [SerializeField] int startMoney = 200;
    [SerializeField] int goMoney = 300;
    public float secondsBetweenTurns = 3;
    [Header("PlayerInfo")]
    [SerializeField] GameObject playerInfoPrefab;
    [SerializeField] Transform playerPanel; //for player info prefab
    [SerializeField] List<GameObject> playerTokenList = new List<GameObject>();
    [Header("Audio")]
    public AudioSource WarpSound;
    [Header("Dice")]
    [SerializeField] DiceRoll dice1;
    [SerializeField] DiceRoll dice2;
    [SerializeField] Camera Battle_Cam;
    [SerializeField] GameObject shop;





    //dice info
    List<int > rolledDice = new List<int>();
    bool rolledADouble;

    //pass start to get money
    public int GetGoMoney => goMoney;

    //dice rolled


    //message system
    public delegate void UpdateMessage(string message);
    public static UpdateMessage OnUpdateMessage;

    //human panel
    public delegate void ShowHumanPanel(bool activatePanel, bool activateRollDice, bool acitaveEndTurn);
    public static ShowHumanPanel OnShowHumanPanel;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        

       Inititialize();
        if (playerList[currentPlayer].playertype == Player.PlayerType.AI)
        {
            RollPhysicalDice();
            //Rolldice();
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

        if (playerList[currentPlayer].playertype == Player.PlayerType.Human)
        {
            OnShowHumanPanel.Invoke(true, true, false); //if Human show panel
        }
        else
        {
            OnShowHumanPanel.Invoke(false, false, false); //if AI hide panel
        }
    }

    public void RollPhysicalDice()
    {
        rolledDice.Clear();
        dice1.RollDice();
        dice2.RollDice();
    }

    public void ReportDiceRolled(int diceValue)
    {
        rolledDice.Add(diceValue);

        //used only for if doubles are rolled
        if (rolledDice.Count == 2)
        {
            Rolldice();
        }
    }



     void Rolldice() //press button for human input or auto for ai
    {
        bool allowdToMove = true;

        //reset last roll
        //rolledDice = new int[2];
        ////store rolled dice
        //rolledDice[0] = 4;//Random.Range(1, 7); //will need code to wait for physical dice
        //rolledDice[1] =4;//Random.Range(1, 7);
        Debug.Log("rolled dice are: " + rolledDice[0] + " & " + rolledDice[1]);

        

        //check for double
        //rolledADouble = rolledDice[0] == rolledDice[1];

        //3 doubles in a row -> end turn

        
            //playerList.[currentPlayer]

       

        //move anyhow if allowed
        if (allowdToMove)
        {
            OnUpdateMessage.Invoke(playerList[currentPlayer].name + " has rolled <color=red>" + rolledDice[0] + "</color> and a <color=red>" + rolledDice[1] + "</color>");
            StartCoroutine(DelayBeforeMove(rolledDice[0] + rolledDice[1]));
        }
        else //Switc Player
        {
            OnUpdateMessage.Invoke(playerList[currentPlayer].name + " Turn has ended");
            StartCoroutine(DelayBetweenSwitchPlayer());
        }


        //show or hide ui
        if (playerList[currentPlayer].playertype == Player.PlayerType.Human)
        {
            OnShowHumanPanel.Invoke(true,false,false);
        }
    }

    public void OpenShop()
    {
        shop.SetActive(true);
        Debug.Log("Shop UI is Open");
    }

    public void CloseShop()
    {
        shop.SetActive(false);
    }

   

IEnumerator DelayBeforeMove(int rolledDice)
    {
        yield return new WaitForSeconds(secondsBetweenTurns);
        //if we are allowed to move
        gameBoard.MovePlayertoken(rolledDice, playerList[currentPlayer]);
        //else we switch
    }

    IEnumerator DelayBetweenSwitchPlayer()
    {
        yield return new WaitForSeconds(secondsBetweenTurns);
        SwitchPlayer();
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
            RollPhysicalDice();
            //Rolldice();
            OnShowHumanPanel.Invoke(false, false, false);
        }
        else //IF HUMAN SHOW UI
        {
            OnShowHumanPanel.Invoke(true, true, false);
        }
        

    }



    public List<int> LastRolledDice => rolledDice;

    




}
