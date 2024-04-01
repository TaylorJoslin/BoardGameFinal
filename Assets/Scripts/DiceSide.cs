using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSide : MonoBehaviour
{
    bool onGround;
    public int sideValue;
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

    public bool OnGround() { return onGround; }
}
