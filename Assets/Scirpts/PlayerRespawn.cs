using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    //References: https://www.youtube.com/watch?v=FPU3uR3HYGo


    // public GameObject Player;
    public GameObject respawnPoint;
    
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        //If the player collides with an object tagged with "Death Barrier",
        //Respawn player at the respawn point
        if(col.collider.tag == "Death Barrier")
        {
            transform.position = respawnPoint.transform.position;

           
        }
    }
}
