using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Refrenced from:https://www.youtube.com/watch?v=pyb3cKrj1ZE
//https://generalistprogrammer.com/unity/unity-2d-how-to-make-camera-follow-player/

public class CameraMovement : MonoBehaviour
{

    public GameObject player;

    //Offest varibale for camera position
    private Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        //Calculate the offset of the camera 
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Make the position of the camera follow the position of the player.
        //Add the offset so the camera stays in it's original location
        transform.position = player.transform.position + offset;
    }
}
