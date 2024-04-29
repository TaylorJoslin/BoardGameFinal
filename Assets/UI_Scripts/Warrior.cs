using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    //Stats for Warrior
    //By Brian
    public int playerHP;
    public int playerATK;
    public int playerDEF;

    public virtual void PAttack()
    {
        Debug.Log("playerhp: " + playerHP);
        Debug.Log("playeratk: " + playerATK);
        Debug.Log("playerdef" + playerDEF);
    }
}
