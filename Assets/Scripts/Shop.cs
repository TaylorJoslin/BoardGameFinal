using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//by Taylor Joslin
public class Shop : MonoBehaviour
{
    //[SerializeField] GameObject shop;
    [SerializeField] Player player;
    public static Shop instance;

    private void Awake()
    {
        instance = this;
    }


    //public void OpenShop()
    //{
    //    shop.SetActive(true);
    //    Debug.Log("Shop UI is Open");
    //}

    //public void CloseShop()
    //{
    //    shop.SetActive(false);
    //}

    public void buySamurai()
    {
        GameManager gameManager = GameManager.instance;
        Player currentPlayer = gameManager.playerList[gameManager.currentPlayer];

        Player.SpendMoney(currentPlayer, 300);
    }

    public void buyWarrior()
    {
        GameManager gameManager = GameManager.instance;
        Player currentPlayer = gameManager.playerList[gameManager.currentPlayer];

        Player.SpendMoney(currentPlayer, 100);
    }

    public void buyPrincess()
    {
        GameManager gameManager = GameManager.instance;
        Player currentPlayer = gameManager.playerList[gameManager.currentPlayer];

        Player.SpendMoney(currentPlayer, 1000);
    }

    public void buySummoner()
    {
        GameManager gameManager = GameManager.instance;
        Player currentPlayer = gameManager.playerList[gameManager.currentPlayer];

        Player.SpendMoney(currentPlayer, 500);
    }

    public void TileEvent()
    {
        GameManager gameManager = GameManager.instance;
        Player currentPlayer = gameManager.playerList[gameManager.currentPlayer];


        Player.AddMoney(currentPlayer, 200);
    }
}
