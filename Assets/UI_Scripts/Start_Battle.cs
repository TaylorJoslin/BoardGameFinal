using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Battle : MonoBehaviour
{
    //this will switch to the battle  
    public GameObject Battle_Cam;
    public GameObject Board_Cam;
    public void Battle()
    {
        Battle_Cam.SetActive(true);
        Board_Cam.SetActive(false);
        Debug.Log("going to battle");
    }
}
