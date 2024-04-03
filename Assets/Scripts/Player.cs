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
    [SerializeField] GameObject myToken; //token player plays with
    [SerializeField] List<Heroes> myHeroes = new List<Heroes>();

    //playerinfo
    PlayerInfo myInfo;

    //return info
    public GameObject MyToken => myToken; //gets player token
    public TileNode MyTileNode => currentnode; //gets player current tile

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
    }

    public void CollectMoney(int amount)
    {
        money+= amount;
        myInfo.SetPlayerCash(money);
    }
}
