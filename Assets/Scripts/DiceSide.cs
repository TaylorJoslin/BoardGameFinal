using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//code by Taylor Joslin
public class DiceSide : MonoBehaviour
{
    bool onGround;
    public int sideValue;
    public bool OnGround => onGround;    //() { return onGround; }
    [SerializeField] GameObject diceImage1;


    private void Start()
    {
        diceImage1.SetActive(false);
    }

    private void OnTriggerStay(Collider col)
    {
        if(col.tag == "Ground")
        {
            onGround = true;
            diceImage1.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.tag == "Ground")
        {
            onGround = false;
            diceImage1.SetActive(false);
        }
    }

    
}
