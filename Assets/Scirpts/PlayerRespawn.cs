using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
   // public GameObject Player;
    public GameObject respawnPoint;
    
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.collider.tag == "Death Barrier")
        {
            transform.position = respawnPoint.transform.position;

            Debug.Log("Amogus");
        }
    }
}
