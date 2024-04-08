using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
   public enum PlayerType
    {
        Human,
        AI
    }

    public PlayerType playertype;
    public string name;
    int money;
    TileNode currentnode;
    bool warpPlayer;

    [SerializeField] GameObject myToken; //token player plays with
    [SerializeField] List<Heroes> myHeroes = new List<Heroes>();

    //playerinfo
    PlayerInfo myInfo;

    //return info
    public GameObject MyToken => myToken; //gets player token
    public TileNode MyTileNode => currentnode; //gets player current tile

    //message system
    public delegate void UpdateMessage(string message);
    public static UpdateMessage OnUpdateMessage;

    public void Inititalize(TileNode startNode, int startMoney, PlayerInfo info, GameObject token)
    {
        currentnode = startNode;
        money = startMoney;
        myInfo = info;
        myInfo.SetPlayerNameandCash(name, money);
        myToken = token;
    }


    public void SetMyCurrentNode(TileNode newNode)
    {
        currentnode = newNode;
        //PLAYER LANDED ON NODE SO DO SOMETHING BATTLE/EVENT/SHOP/WARP
        newNode.PlayerLandedOnNode(this);
        
        //IF AI PLAYER

        //If Human Player
    }

    public void CollectMoney(int amount)
    {
        money+= amount;
        myInfo.SetPlayerCash(money);
    }

    //----------------Warp Player-----------------
    public void Warp()
    {

        

        warpPlayer = true;

        if (currentnode == Board.instance.route[3])
        {
            int randomWarp = Random.Range(0, 3);
            Debug.Log("Player is picking warp location");

            switch (randomWarp)
            {
                case 0:
                    myToken.transform.position = Board.instance.route[11].transform.position;
                    currentnode = Board.instance.route[11];
                    Debug.Log("Warp11");

                    break;
                case 1:
                    myToken.transform.position = Board.instance.route[19].transform.position;
                    currentnode = Board.instance.route[19];
                    Debug.Log("Warp19");

                    break;
                case 2:
                    myToken.transform.position = Board.instance.route[27].transform.position;
                    currentnode = Board.instance.route[27];
                    Debug.Log("Warp27");

                    break;
                default:
                           Debug.Log("Invalid something happened");
                           break;

            }
        }

        else if (currentnode == Board.instance.route[11])
        {
            int randomWarp = Random.Range(0, 2);

            switch (randomWarp)
            {
                case 0:
                    myToken.transform.position = Board.instance.route[3].transform.position;
                    currentnode = Board.instance.route[3];
                    break;
                case 1:
                    myToken.transform.position = Board.instance.route[19].transform.position;
                    currentnode = Board.instance.route[19];
                    break;
                case 2:
                    myToken.transform.position = Board.instance.route[27].transform.position;
                    currentnode = Board.instance.route[27];
                    break;

            }
        }

        else if (currentnode == Board.instance.route[19])
        {
            int randomWarp = Random.Range(0, 2);

            switch (randomWarp)
            {
                case 0:
                    myToken.transform.position = Board.instance.route[11].transform.position;
                    currentnode = Board.instance.route[11];
                    break;
                case 1:
                    myToken.transform.position = Board.instance.route[3].transform.position;
                    currentnode = Board.instance.route[3];
                    break;
                case 2:
                    myToken.transform.position = Board.instance.route[27].transform.position;
                    currentnode = Board.instance.route[27];
                    break;

            }
        }

        else if (currentnode == Board.instance.route[27])
        {
            int randomWarp = Random.Range(0, 2);

            switch (randomWarp)
            {
                case 0:
                    myToken.transform.position = Board.instance.route[11].transform.position;
                    currentnode = Board.instance.route[11];
                    break;
                case 1:
                    myToken.transform.position = Board.instance.route[19].transform.position;
                    currentnode = Board.instance.route[19];
                    break;
                case 2:
                    myToken.transform.position = Board.instance.route[3].transform.position;
                    currentnode = Board.instance.route[3];
                    break;

            }
        }

    }

    public void MoveBackwards3()
    {
        Board.instance.MovePlayertoken(-3, this); //moves the player backwards (x steps, current player)
    }
}
