using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Combat_test : MonoBehaviour
{
    //Combat system: By Brian and some edits made by Taylor
    //buttons
    public GameObject War;
    public GameObject Sam;
    public GameObject WarButton;
    public GameObject SamButton;
    public GameObject ATKbutton;
    //the decider thing
    private int test;
    private int playerDie;
    private int monsterDie;
    private int dmgDealt;
    //scripts
    public Warrior warrior;
    public Samuari samuari;
    public monster Monster;
    //UI
    public TMP_Text PlayerHPUI;
    public TMP_Text PlayerDEFUI;
    public TMP_Text PlayerATKUI;
    public TMP_Text MonsterHPUI;
    public TMP_Text MonsterDEFUI;
    public TMP_Text MonsterATKUI;
    public TMP_Text noti;
    public TMP_Text notiDMG;
    //public GameObject PlayerUI;`
    //public GameObject MonsterUI;
    public GameObject Noti;
    public GameObject NotiDMG;
    //the thingsss
    private int PlayerHP;
    private int PlayerDEF;
    private int PlayerATK;
    //public Warrior warrior;
    //private player Play;

    private int initialPlayerHP; // Store initial player HP
    private int initialPlayerDEF; // Store initial player DEF
    private int initialPlayerATK; // Store initial player ATK

    private int initialSamHP;
    private int initialSamDEF;
    private int initialSamATK;

    private int initialMonHP;
    private int initialMonDEF;
    private int initialMonATK;

    //message system
    public delegate void UpdateMessage(string message);
    public static UpdateMessage OnUpdateMessage;

    private void Awake()
    {
        // Store initial player stats
        initialPlayerHP = warrior.playerHP;
        initialPlayerDEF = warrior.playerDEF;
        initialPlayerATK = warrior.playerATK;

        initialSamHP = samuari.playerHP;
        initialSamDEF = samuari.playerDEF;
        initialSamATK = samuari.playerATK;

        initialMonHP = Monster.monsterHP;
        initialMonATK = Monster.monsterATK;
        initialMonDEF = Monster.monsterDF;
        
    }

    public void Start()
    {
        Noti.SetActive(false);
        NotiDMG.SetActive(false);
        WarButton.SetActive(true);
        SamButton.SetActive(true);
        ATKbutton.SetActive(false);
    }
    public void Update()
    {
        PlayerHPUI.text = ("Player's HP: " + PlayerHP);
        PlayerDEFUI.text = ("Player's DEF: " + PlayerDEF);
        PlayerATKUI.text = ("Player's ATK: " + PlayerATK);
        MonsterHPUI.text = ("Monster's HP: " + Monster.monsterHP);
        MonsterDEFUI.text = ("Monster's DEF: " + Monster.monsterDF);
        MonsterATKUI.text = ("Monster's ATK: " + Monster.monsterATK);
    }

    public void Chosewar()
    {
        War.SetActive(true);
        WarButton.SetActive(false);
        SamButton.SetActive(false);
        ATKbutton.SetActive(true);
        test = 1;
        OnUpdateMessage.Invoke("player chose War");
        Debug.Log("player chose War");
        PlayerHP = warrior.playerHP;
        PlayerDEF = warrior.playerDEF;
        PlayerATK = warrior.playerATK;

    }

    public void Chosesam()
    {
        Sam.SetActive(true);
        WarButton.SetActive(false);
        SamButton.SetActive(false);
        ATKbutton.SetActive(true);
        test = 0;
        Debug.Log("player chose Sam");
        PlayerHP = samuari.playerHP;
        PlayerDEF = samuari.playerDEF;
        PlayerATK = samuari.playerATK;
    }

    public void attack()
    {
        //sam will be 0
        //war will be 1
        if (test == 0)
        {
            Debug.Log(PlayerHP);
            Debug.Log("Sam");
            battleRoll();
        }
        else if (test == 1)
        {
            Debug.Log(PlayerHP);
            Debug.Log("war");
            battleRoll();
        }
        else
        {
            Debug.Log("uuuuuh");
        }
    }
    //this will be the fuction that plays whenever the the button "roll dice"
    public void battleRoll()
    {
        playerDie = Random.Range(1, 6);
        monsterDie = Random.Range(1, 6);
        Debug.Log(playerDie);
        Debug.Log(monsterDie);
        Noti.SetActive(true);
        dieCompare();

        if (Monster.monsterHP <= 0)
        {
            youWin();
        }
        else if (PlayerHP <= 0)
        {
            youLose();
        }
    }

    public void dieCompare()
    {
        if (playerDie > monsterDie)
        {
            Debug.Log("plyaer goes first");
            noti.text = ("player turn");

            playerAttack();
            //Player.PAttack();
        }
        else if (monsterDie > playerDie)
        {
            Debug.Log("Monster goes first");
            noti.text = ("monster turn");
            monsterAttack();
        }
        else
        {
            Debug.Log("TIE, roll again");
            noti.text = ("TIE, roll again");
        }
    }

    public void monsterAttack()
    {

        if (PlayerDEF >= Monster.monsterATK)
        {
            NotiDMG.SetActive(true);
            notiDMG.text = ("Monster did no damage");
            Debug.Log("Not a scratch for player");
        }
        else if (PlayerDEF < Monster.monsterATK)
        {
            NotiDMG.SetActive(true);
            dmgDealt = -1 * (PlayerDEF - Monster.monsterATK);
            PlayerHP = PlayerHP + (PlayerDEF - Monster.monsterATK);
            notiDMG.text = ("Monster did " + dmgDealt + " dmg");
            Debug.Log("player: ouch" + PlayerHP);
        }
    }

    public void playerAttack()
    {
        if (Monster.monsterDF >= PlayerATK)
        {
            NotiDMG.SetActive(true);
            notiDMG.text = ("Player did no damage");
            Debug.Log("Not a scratch for the monster");
        }
        else if (Monster.monsterDF < PlayerATK)
        {
            NotiDMG.SetActive(true);
            dmgDealt = -1 * (Monster.monsterDF - PlayerATK);
            Monster.monsterHP = Monster.monsterHP + (Monster.monsterDF - PlayerATK);
            notiDMG.text = ("Player did " + dmgDealt + " dmg");
            Debug.Log("monster: ouch" + Monster.monsterHP);
        }
    }

    public void youWin()
    {
        Debug.Log("you win :)");
        ATKbutton.SetActive(false);
        NotiDMG.SetActive(false );
        noti.text = ("You win :)");
        Start_Battle.instance.Battle_Cam.SetActive(false);
        Start_Battle.instance.Board_Cam.SetActive(true);
        Start_Battle.instance.HumanPanel_UI.SetActive(true);
        Start_Battle.instance.Battle_UI.SetActive(false);
        ResetBattle();

    }

    public void youLose()
    {
        Debug.Log("you lose :(");
        ATKbutton.SetActive(false);
        NotiDMG.SetActive(false);
        noti.text = ("You lose :(");
        Start_Battle.instance.Battle_Cam.SetActive(false);
        Start_Battle.instance.Board_Cam.SetActive(true);
        Start_Battle.instance.HumanPanel_UI.SetActive(true);
        Start_Battle.instance.Battle_UI.SetActive(false);
        ResetBattle();
    }

    //Taylor's Code
    public void ResetBattle()
    {
        // Reset player stats to initial values
        PlayerHP = initialPlayerHP;
        PlayerDEF = initialPlayerDEF;
        PlayerATK = initialPlayerATK;

        Monster.monsterHP = initialMonHP;
        Monster.monsterDF = initialMonDEF;
        Monster.monsterATK = initialMonATK;

        // Reset UI elements
        PlayerHPUI.text = ("Player's HP: " + PlayerHP);
        PlayerDEFUI.text = ("Player's DEF: " + PlayerDEF);
        PlayerATKUI.text = ("Player's ATK: " + PlayerATK);
        MonsterHPUI.text = ("Monster's HP: " + Monster.monsterHP);
        MonsterDEFUI.text = ("Monster's DEF: " + Monster.monsterDF);
        MonsterATKUI.text = ("Monster's ATK: " + Monster.monsterATK);

        // Disable notification UI
        Noti.SetActive(false);
        NotiDMG.SetActive(false);

        // Enable necessary buttons
        WarButton.SetActive(true);
        SamButton.SetActive(true);
        ATKbutton.SetActive(false);
    }
}
