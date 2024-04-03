using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    public TileNodeType tilenodetype;
    [SerializeField] internal new string name;

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

        //check for node type then act
        switch (tilenodetype)
        {
            case TileNodeType.Battle:

                //battle script
                if(!playerIsHuman)//AI
                {
                    
                }else//Human
                {

                }
                break;

            case TileNodeType.Event:

                //Event script
                if (!playerIsHuman)//AI
                {

                }
                else//Human
                {

                }
                break;

            case TileNodeType.Warp:

                //Warp script
                if (!playerIsHuman)//AI
                {
                    //WarpPlayer();

                    
                    //player.SetMyCurrentNode(route[indexOnboard]);
                }
                else//Human
                {

                }
                break;

            case TileNodeType.Shop:

                //Shop script
                if (!playerIsHuman)//AI
                {

                }
                else//Human
                {

                }
                break;
        }


        //if not a human player then wait 2seconds before continuing
        if (!playerIsHuman)
        {
            Invoke("ContinueGame", 2f);
        }
        else
        {
            //SHOW UI
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

    void WarpPlayer(int steps, Player player)
    {
       
        
        //int indexOnboard = route.IndexOf(player.MyTileNode); //what node the player is on
        //player.SetMyCurrentNode(route[indexOnboard]);
    }
}
