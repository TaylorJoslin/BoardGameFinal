using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public List<TileNode> route = new List<TileNode> ();

    void OnValidate()
    {
        route.Clear ();
        foreach (Transform node in transform.GetComponentInChildren<Transform>())
        {
            route.Add(node.GetComponent<TileNode>());
        }
    }

    void OnDrawGizmos()
    {
        if (route.Count > 0) 
        {
            for (int i = 0; i < route.Count; i++)
            {
                Vector3 current = route[i].transform.position;
                Vector3 next = (i + 1 < route.Count) ? route[i+1].transform.position:current;

                Gizmos.color = Color.green;
                Gizmos.DrawLine(current,next);
            }
        }
    }

    public void MovePlayertoken(int steps, Player player)
    {
        StartCoroutine(MovePlayerInSteps(steps, player));
    }

    IEnumerator MovePlayerInSteps(int steps, Player player)
    {
        int stepsLeft = steps;
        GameObject tokenToMove = player.MyToken;
        int indexOnboard = route.IndexOf(player.MyTileNode); //what node the player is on
        bool moveOverStart = false;

        while (stepsLeft > 0)
        {
            indexOnboard++;
            //is this over start
            if(indexOnboard>route.Count - 1)
            {
                indexOnboard = 0;
                moveOverStart = true;
            }
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

        //get start money
        if(moveOverStart)
        {
            //add money to player for passing start
            player.CollectMoney(GameManager.instance.GetGoMoney);
        }
        //set new node on current player
        player.SetMyCurrentNode(route[indexOnboard]);
    }

    bool MoveToNextNode(GameObject tokenToMove, Vector3 endPos, float speed)
    {
        return endPos !=(tokenToMove.transform.position = Vector3.MoveTowards(tokenToMove.transform.position, endPos, speed * Time.deltaTime));
    }
}
