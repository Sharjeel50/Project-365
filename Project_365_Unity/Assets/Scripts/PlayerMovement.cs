using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //Variables
    [SerializeField]
    public float speed = 1000f;

    [SerializeField]
    public float gravity = 150f;

    [SerializeField]
    public float jumpForce;



    public Rigidbody rb;
    public Vector3 Movement;
    private bool isGrounded = false;

   // public LayerMask groundLayers;

    // Use this for initialization
    void Awake () {
        rb = GetComponent<Rigidbody>();
    }


    //Set collision for ground
    void OnCollisionStay(Collision coll)
    {
        isGrounded = true;
    }

    void OnCollisionExit(Collision coll)
    {
        isGrounded = false;
    }



    private void Update()
    {
        //Non-Physics
        float deltaX = Input.GetAxis("Horizontal"); //Get the inputs from 
        float deltaZ = Input.GetAxis("Vertical");


        //Hold Movement values
        Movement = (deltaX * transform.right + deltaZ * transform.forward);// .normalize
        Movement = Vector3.ClampMagnitude(Movement, speed); //clamps speed so movement is always the same

        if (Input.GetKeyDown(KeyCode.LeftShift)) //should be sprint(Doesnt Work)
        {
            speed = 5000f;
        }
        else
        {
            speed = 1000f;
        }

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //Physics
        Move();

        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
      
    }

    void Move()
    {
        //apply movement
        Vector3 yvelFix = new Vector3(0, rb.velocity.y, 0);
        rb.velocity = (Movement * speed) * Time.deltaTime;
        rb.velocity += yvelFix;
       
    }
}

