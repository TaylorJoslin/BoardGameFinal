using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Board : MonoBehaviour    
{
    public static Board instance;

    public List<TileNode> route = new List<TileNode> ();


    [System.Serializable]
    public class WarpSet
    {
        public List<TileNode> nodesInSetList = new List<TileNode> ();
    }


    [SerializeField] List<WarpSet> WarpSetList = new List<WarpSet> ();

    private void Awake()
    {
        instance = this;
    }

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
        bool isMovingForward = steps > 0;

        
        if (isMovingForward) //controls moving current player forward
        {
            while (stepsLeft > 0)
            {
                indexOnboard++;
                //is this over start allows to loop around the board
                if (indexOnboard > route.Count - 1)
                {
                    indexOnboard = 0;
                    moveOverStart = true;
                }
                //get start and end position
                Vector3 startPos = tokenToMove.transform.position;
                Vector3 endPos = route[indexOnboard].transform.position;

                //perform move
                while (MoveToNextNode(tokenToMove, endPos, 50))
                {
                    yield return null;
                }
                stepsLeft--;
            }
            
        } 
        else //contrls moving current player backwards
        {
            while (stepsLeft < 0)
            {
                indexOnboard--;
                //is this moving over start backwards
                if (indexOnboard < 0)
                {
                    indexOnboard = route.Count - 1;
                    
                }
                //get start and end position
                //Vector3 startPos = tokenToMove.transform.position;
                Vector3 endPos = route[indexOnboard].transform.position;

                //perform move
                while (MoveToNextNode(tokenToMove, endPos, 50))
                {
                    yield return null;
                }
                stepsLeft++;
            }
        }

        //get start money
        if (moveOverStart)
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
