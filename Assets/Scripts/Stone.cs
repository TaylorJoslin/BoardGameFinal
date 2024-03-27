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

    void Update()
    {
        //roll the dice "add my dice script"
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            steps = Random.Range(1,7);
            Debug.Log ("Dice Rolled " + steps);

            StartCoroutine(Move());
        }
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
            
        }




        isMoving = false;
    }

    //if goal node has not been reached move to next node
    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal,speed*Time.deltaTime));
    }
}
