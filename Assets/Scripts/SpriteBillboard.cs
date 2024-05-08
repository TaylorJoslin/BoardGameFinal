using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//code by Taylor Joslin
public class SpriteBillboard : MonoBehaviour
{
    [SerializeField] bool freezeXZAxis;


    // Update is called once per frame
    void LateUpdate()
    {
        //Controls if the sprite will look at the camera
        if (freezeXZAxis)
        {
            transform.rotation = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);
        }
        else
        {
            transform.rotation = Camera.main.transform.rotation;
        }
    }
}
