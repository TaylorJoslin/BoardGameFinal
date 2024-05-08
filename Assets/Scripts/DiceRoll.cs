using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//code by Taylor Joslin
public class DiceRoll : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
     [SerializeField] bool hasLanded;
    [SerializeField] bool thrown;

    Vector3 startPosition;

    public int diceValue;

    public DiceSide[] diceSides;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        rb.useGravity = false;
        rb.isKinematic = true;

        
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    RollDice();
        //}



        if (rb.IsSleeping() && !hasLanded && thrown) //dice is no longer moving
        {
            hasLanded = true;
            rb.useGravity = false;
            rb.isKinematic = true;
            SideValueCheck();
        }
        else if (rb.IsSleeping() && hasLanded && diceValue == 0) //if dice gets stuck then reroll
        {
            RollAgain();
        }
    }

    public void RollDice()
    {
        Reset();
        if (!thrown && !hasLanded)
        {
            thrown = true;
            rb.useGravity = true;
            rb.isKinematic = false;
            rb.AddTorque(Random.Range(100000, 200000), Random.Range(100000, 200000), Random.Range(100000, 200000));
        }
        //else if (thrown && hasLanded)
        //{
        //    Reset();
        //}
    }

    public void Reset()
    {
        transform.position = startPosition;
        thrown = false;
        hasLanded = false;
        rb.useGravity = false;
        rb.isKinematic = true;
        

    }
    void RollAgain()
    {
        Reset();
        thrown = true;
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
    }

    void SideValueCheck()
    {
        diceValue = 0;
        foreach (DiceSide side in diceSides)
        {
            if (side.OnGround)
            {
                diceValue = side.sideValue;
                Debug.Log(diceValue + " has been rolled!");
                
                break;
            }
        }
        GameManager.instance.ReportDiceRolled(diceValue);
        Debug.Log(" Dice have been reported");

    }
}
