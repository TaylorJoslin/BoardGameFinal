using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    //Changes scene to the choosen scene using buttons
    //By Brian
    //
    public string MainGame;
    public string CreditName;
    public string Description;
    public string MainMenu;


    public void SceneGame()
    {
        SceneManager.LoadScene(MainGame);
    }

    public void SceneMM()
    {
        SceneManager.LoadScene(MainMenu);
    }

    public void SceneCredit()
    {
        SceneManager.LoadScene(CreditName);
    }
}
