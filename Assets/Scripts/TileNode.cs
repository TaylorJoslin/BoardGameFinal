using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

//code by Taylor Joslin
public enum TileNodeType
{
    Battle,
    Event,
    Warp,
    Shop,
    Start
}

public class TileNode : MonoBehaviour
{
    public Player owner;
    //public Start_Battle battle;

    //message system
    public delegate void UpdateMessage(string message);
    public static UpdateMessage OnUpdateMessage;

    //human panel
    public delegate void ShowHumanPanel(bool activatePanel, bool activateRollDice, bool acitaveEndTurn);
    public static ShowHumanPanel OnShowHumanPanel;

    public TileNodeType tilenodetype;
    [SerializeField] internal new string name;


    private GameManager gameManager;
    private Player player;
    

    private List<TileNode> route;

    private void OnValidate()
    {
        OnOwnerUpdated();
    }

    public void OnOwnerUpdated()
    {

    }

    public void PlayerLandedOnNode(Player currentplayer)
    {
        bool playerIsHuman = currentplayer.playertype == Player.PlayerType.Human;
        bool continueTurn = true;

        //check for node type then act
        switch (tilenodetype)
        {
            case TileNodeType.Battle:

                //battle script
                if(!playerIsHuman)//AI
                {
                    //currentplayer.MoveBackwards3();
                    //continueTurn = false;

                }else//Human
                {
                    OnUpdateMessage.Invoke(currentplayer.name + " is going to battle");
                    currentplayer.Battletile();
                }
                break;

            case TileNodeType.Event:

                //Event script
                if (!playerIsHuman)//AI
                {

                }
                else//Human
                {
                    OnUpdateMessage.Invoke(currentplayer.name + " earned $200!!");
                    currentplayer.CollectMoney(200);
                }
                break;

            case TileNodeType.Warp:

                //Warp script
                if (!playerIsHuman)//AI
                {
                    OnUpdateMessage.Invoke(currentplayer.name + " has warpped!!");
                    currentplayer.Warp();
                    GameManager.instance.WarpSound.Play();
                   
                }
                else//Human
                {
                    OnUpdateMessage.Invoke(currentplayer.name + " has warpped!!");
                    currentplayer.Warp();
                    GameManager.instance.WarpSound.Play();
                }
                break;

            case TileNodeType.Shop:

                //Shop script
                if (!playerIsHuman)//AI
                {

                }
                else//Human
                {
                    OnUpdateMessage.Invoke(currentplayer.name + " enters the Shop");
                    currentplayer.openPlayerShop();
                    Debug.Log("player landed on shop");
                }
                break;
        }

        //stop here if needed
        if(!continueTurn)
        {
            return;
        }

        //if not a human player then wait 2seconds before continuing
        if (!playerIsHuman)
        {
            Invoke("ContinueGame", GameManager.instance.secondsBetweenTurns);
        }
        else
        {
            //SHOW UI
            OnShowHumanPanel.Invoke(true,false,true);
        }
    }
    void ContinueGame()
    {
        //IF LAST ROLL WAS A DOUBLE
        //ROLL AGAIN

        //NOT A DOUBLE ROLL
        //SWITCH PLAYER
        GameManager.instance.SwitchPlayer();
    }





}
