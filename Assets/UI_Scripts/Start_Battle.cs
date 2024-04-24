using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_Battle : MonoBehaviour
{
    public static Start_Battle instance;

    //this will switch to the battle  
    public GameObject Battle_Cam;
    public GameObject Board_Cam;
    public GameObject Battle_UI;
    public GameObject HumanPanel_UI;

    void Awake()
    {
        instance = this;
    }

    public void Battle()
    {
        Battle_Cam.SetActive(true);
        Board_Cam.SetActive(false);
        HumanPanel_UI.SetActive(false);
        Battle_UI.SetActive(true);
        Debug.Log("going to battle");
    }
}
