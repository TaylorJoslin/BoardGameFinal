using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpTile : MonoBehaviour
{
    public bool isTeleporttile = false;
    public Transform teleportDestination;


    private void OnTriggerStay(Collider other)
    {
       if (isTeleporttile)
        {
            TeleportPlayer(other.transform);
        }
        
    }

    void TeleportPlayer(Transform playerTransform)
    {
        playerTransform.position = teleportDestination.position;
    }
}
