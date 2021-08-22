using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controll : MonoBehaviour
{
    //conection to physics engine
    public Rigidbody rb = null;
    //the true looking direction
    public Transform Looking_rig = null;

    //speed setting
    public float terminalVelocity = 5f;
    public float moveforce = 10f;

    public float speed = 0;
    //private float sidewayspeed = 0;

    //jumping
    bool isGrounded = false;
    bool isJumping = false;
    float Jumptime = 0f;

    User_Input usr_input = null;
    //float speed_decay = 0.99f;

    //visual 
    public Transform visual_ball;
    public float visualballrotatespeed = 10f;
    Vector3 ball_visula_rotation = Vector3.zero;
    float degree_of_distance=(3.14f/360f);//2rpi/360=0.5*2*pi/360

    // Start is called before the first frame update
    void Start()
    {
        //last_pos = transform.position;
        //calculate drag
        //drag = moveforce / terminalVelocity;

        // Get all the component from childs
        usr_input = User_Input.Single;  //GetComponent<User_Input>();
        if (usr_input == null)
            Debug.LogError("user_input is null.");
        rb = GetComponent<Rigidbody>();
        if (rb == null)
            Debug.LogError("rigidbody is null.");
    }

    void FixedUpdate()
    {


        speed = Vector3.Dot(rb.velocity, transform.forward);
        //sidewayspeed = Vector3.Dot(rb.velocity, Looking_rig.right);

        Vector3 newforward = Looking_rig.forward;
        Vector3 newright = Looking_rig.right;
        Vector3 newdirection = newforward * usr_input.Forward + newright * usr_input.Right;
        newdirection.y = 0;
        newdirection = newdirection.normalized;

        if (usr_input.Forward != 0 || usr_input.Right != 0)
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newdirection, Vector3.up), Time.deltaTime * 3f);//TODO change this 3f to some variable
            rb.AddForce(transform.forward * Time.fixedDeltaTime * moveforce);


        }

        Vector3 xz = rb.velocity;
        float y = rb.velocity.y;
        xz.y = 0;
        xz = Vector3.ClampMagnitude(xz, terminalVelocity);

        if (usr_input.Forward == 0 && usr_input.Right == 0)
            xz -= xz * 0.1f;
        else
            xz -= xz * 0.05f;

        xz -= xz * 0.05f;//dampaning


        xz.y = y;
        //rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxspeed);
        rb.velocity = xz;
        // Update is called once per frame
        
    }
    void Jump()
    {
        if(GameInputManager.GetKeyDown("jump"))
        {
            if(isGrounded)
            {
                rb.AddForce(Vector3.up * 10f, ForceMode.Impulse) ;
                isJumping = true;
                isGrounded = false;
            }
        }
    }
   
    void Update()
    {
        Jump();
        ball_visual_rotate();
    }





    
    void ball_visual_rotate()
    {
        ball_visula_rotation.x += rb.velocity.magnitude*Time.deltaTime / degree_of_distance;
        visual_ball.transform.localRotation = Quaternion.Euler(ball_visula_rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        for(int i=0;i< collision.contactCount;i++)
        {
        Vector3 contact_normal = collision.contacts[i].normal;
        //is it a ground
        if (Vector3.Dot(contact_normal,Vector3.up)<45f)
            {
                //this is a floor
                isGrounded = true;
                isJumping = false;
            }

        }
    }









}
