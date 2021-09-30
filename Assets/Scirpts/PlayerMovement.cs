using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code referenced from: https://gamedev.stackexchange.com/questions/88433/how-to-reverse-gravity-in-unity

//Christian Riggi
//100752293


public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rb;
    private float speed;
    private float dirX = 4f;

    //Jump logic variables
    public float jumpForce = 10f;
    private bool isGrounded = false;
    public float Gravity = 1;

    // Start is called before the first frame update
    void Start()
    {
        //Set player movement speed
       speed = 6.0f;
       rb = GetComponent<Rigidbody>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
          
            //Gravity flipping mechanic
            if (isGrounded == true)
            {
                //if the gravity is set to one and is grounded,
                // when the player presses the space bar, gravity is inverted
                if (Gravity == 1)
                {
                    //If the spacebar is pressed, flip the gravity on the rigid body
                    Physics.gravity = new Vector3(0f, -1f, 0f);

                    //Velocity is applied to the rigidbody with transform.up
                    rb.velocity = transform.up * jumpForce * Time.deltaTime;

                    //Change the Gravity value to negative 1
                    Gravity = -1;

                }
                //Since Gravity is et to -1 once the player flips to the other platform, 
                //jumping again will ignore the first if statement and move to this one.
                //Gravity is inverted once again and becomes positive
                else if (Gravity == -1)
                {

                    Physics.gravity = new Vector3(0f, 1f, 0f);

                    //Velocity is applied to the rigidbody with transform.up
                    rb.velocity = transform.up * -jumpForce * Time.deltaTime;

                    //Change the Gravity value to positive 1
                    Gravity = 1;

                }

            }
        }
    }

     //Set Player Input
       void FixedUpdate()
      {
       
        //dirX = Input.GetAxis("Horizontal") * speed;
   
        //Apply force to rigid body to move character
        rb.velocity = new Vector3(dirX, rb.velocity.y, 0f);

    }

    //Layer Collision Detetction

    void OnCollisionEnter(Collision col)
    {
        //Layer 6 is the ground layer used to identify all platforms in the game
        if(col.gameObject.layer == 6 && !isGrounded)
        {

            isGrounded = true;

            Debug.Log("On Ground");
        
        }



    }

    void OnCollisionExit(Collision col)
    {
        //Layer 6 is the ground layer used to identify all platforms in the game
        if (col.gameObject.layer == 6 && isGrounded)
        {

            isGrounded = false;

            Debug.Log("Off Ground");
        }



    }


}
