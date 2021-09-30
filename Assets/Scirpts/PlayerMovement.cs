using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rb;
    private float speed;
    private float dirX, dirY;

    //Jump logic variables
    public float jumpForce = 1f;
    private bool isGrounded = false;
    private bool canJump = false;

    //rb.mass will set the mass of an rigidbody
    //rb. mass = -1 for gravity flipping.

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

      
      

    }

     //Set Player Input
       void FixedUpdate()
      {
       
        dirX = Input.GetAxis("Horizontal") * speed;
   
        //Apply force to rigid body to move character
        rb.velocity = new Vector3(dirX, rb.velocity.y, 0f);


        //Gravity flipping mechanic
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                //If the spacebar is pressed, flip the gravity on the rigid body
                Physics.gravity = new Vector3(0f, -Gravity, 0f);

                //Reset the y value velocity to 0
                // rb.velocity = new Vector3(rb.velocity.x, 0f, 0f);

                //rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);

                Gravity = -Gravity;

                // isGrounded = false;

                //Set the Mass variable to the new mass. This variable is passed each iteration changin between positve 1 and negative 1

            }
            else
            {

                //Reset the
                isGrounded = true;

                Physics.gravity = new Vector3(0f, Gravity, 0f);

                // rb.AddForce(new Vector3(0f, -jumpForce, 0f), ForceMode.Impulse);

                //jumpForce = -jumpForce;
            }
        }

     
       


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
