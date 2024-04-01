using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public Route currentRoute;
    public float speed;
    int routePosition;
    public int steps;
    bool isMoving;

    public GameObject MoveButton;
    public GameObject RollDiceButton;

    public DiceRoll Dice1;
    public DiceRoll Dice2;

    private void Start()
    {
        MoveButton.SetActive(false);
    }

    void Update()
    {
        //roll the dice "add my dice script"
        //if (Input.GetMouseButtonDown(0) && !isMoving)
        //{
        //    Dice1.RollDice();
        //    Dice2.RollDice();

        //    steps = Dice1.diceValue + Dice2.diceValue;

        //    //steps = Random.Range(1,7);


        //    StartCoroutine(Move());
        //    Debug.Log("Player 1 moves " + steps + " spaces");
        //}


    }

    public void StartRoll()
    {
        Dice1.RollDice();
        Dice2.RollDice();

        //steps = Dice1.diceValue + Dice2.diceValue;

        //steps = Random.Range(1,7);

        MoveButton.SetActive(true);
        RollDiceButton.SetActive(false);

        //StartCoroutine(Move());
        
    }

    public void MovePlayer1()
    {
        steps = Dice1.diceValue + Dice2.diceValue;
        StartCoroutine(Move());
        Dice1.RollDice();
        Dice2.RollDice();
       
        MoveButton.SetActive(false);
        // Dice1.Reset();
        //Dice2.Reset();
    }

    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;

        //moves the player on the board to the next node
        while(steps>0)
        {

            routePosition++;
            routePosition %= currentRoute.childNodeList.Count;


            Vector3 nextPos = currentRoute.childNodeList[routePosition].position;
            while(MoveToNextNode(nextPos)) { yield return null; }

            yield return new WaitForSeconds(0.1f);
            steps--;
            Debug.Log(steps + " spaces to go");
        }




        isMoving = false;
    }

    //if goal node has not been reached move to next node
    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal,speed*Time.deltaTime));
    }
}
