using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UIElements;


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
                    testWarp();
                    
                    //DoWarp(8, gameManager.playerList[gameManager.currentPlayer]);

                    //StartCoroutine(MovePlayerInSteps(steps, player));
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

    void DoWarp(int steps, Player player)
    {
        StartCoroutine(WarpPlayer(steps, player));
    }

    void testWarp()
    {
        GameObject tokenToMove = player.MyToken;
        tokenToMove.transform.position = gameManager.teleportDestination.position;
    }

    //------------------------------------------------------------------------------------------------------------------------

    IEnumerator WarpPlayer(int steps, Player player)
    {
        int stepsLeft = steps;
        GameObject tokenToMove = player.MyToken;
        int indexOnboard = route.IndexOf(player.MyTileNode); //what node the player is on

        while (stepsLeft > 0)
        {
            indexOnboard++;

            //get start and end position
            Vector3 startPos = tokenToMove.transform.position;
            Vector3 endPos = route[indexOnboard].transform.position;

            //perform move
            while (MoveToNextNode(tokenToMove, endPos, 15))
            {
                yield return null;
            }

            

            stepsLeft--;

        }
        //set new node on current player
        player.SetMyCurrentNode(route[indexOnboard]);



    }

    //------------------------------------------------------------------------------------------------------------------------

    bool MoveToNextNode(GameObject tokenToMove, Vector3 endPos, float speed)
    {
        return endPos != (tokenToMove.transform.position = Vector3.MoveTowards(tokenToMove.transform.position, endPos, speed * Time.deltaTime));
    }
}
