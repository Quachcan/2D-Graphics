using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behemoth : MonoBehaviour
{
    public Transform player;
    public bool isTurned = false;
    // Start is called before the first frame update
    public void LookAtPlayer()
    {
        //xoay enemy theo player
        if (transform.position.x > player.position.x && isTurned)
        {
            transform.right = Vector3.left;
            isTurned = false;
        }
        else if (transform.position.x <  player.position.x && !isTurned)
        {
            transform.right = Vector3.right;
            isTurned = true;
        }
    }
}
