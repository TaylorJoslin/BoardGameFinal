using System.Collections;
using System.Collections.Generic;

using UnityEngine;

//code by Taylor Joslin
public class Stone : MonoBehaviour
{
    public Route currentRoute;
    public float speed;
    int routePosition;
    public int steps;
    bool isMoving;

    public GameObject MoveButton, p2MoveButton;
    public GameObject RollDiceButton, p2RollDice;

    public DiceRoll Dice1;
    public DiceRoll Dice2;

    private void Start()
    {
        MoveButton.SetActive(false);
        p2RollDice.SetActive(false);
        p2MoveButton.SetActive(false);
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

    public void TakeTurn()
    {
        // Implement player's turn logic here
        Debug.Log("Taking turn...");
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
        p2RollDice.SetActive(true);
    }

    public void P2StartRoll()
    {
        Dice1.RollDice();
        Dice2.RollDice();

        //steps = Dice1.diceValue + Dice2.diceValue;

        //steps = Random.Range(1,7);

        p2MoveButton.SetActive(true);
        p2RollDice.SetActive(false);

        //StartCoroutine(Move());

    }


    public void MovePlayer2()
    {
        steps = Dice1.diceValue + Dice2.diceValue;
        StartCoroutine(Move());
        Dice1.RollDice();
        Dice2.RollDice();

        p2MoveButton.SetActive(false);
        RollDiceButton.SetActive(true);
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
