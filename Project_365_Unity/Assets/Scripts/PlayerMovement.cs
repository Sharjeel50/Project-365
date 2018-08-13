using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public float speed = 6f;

    public float gravity = 150f;


    private CharacterController _charCont;
    public bool jumpkey;

    public float JumpForce = 70f;
    public LayerMask groundLayers;

   // private Vector3 moveDirection = Vector3.zero;

    // Use this for initialization
    void Start () {
        _charCont = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed; //Get the inputs from 
        float deltaY = Input.GetAxis("Vertical") * speed;
        Vector3 Movement = new Vector3(deltaX, 0, deltaY);
        Movement = Vector3.ClampMagnitude(Movement, speed); //clamps speed so movement is always the same


        if (_charCont.isGrounded && Input.GetButton("Jump"))
        {
            Movement.y += JumpForce;
        }
        else {
             Movement.y -= gravity * Time.deltaTime;
        }

        Movement *= Time.deltaTime; // fixes the movement so that its the same across different frame rates.
        Movement = transform.TransformDirection(Movement);
        _charCont.Move(Movement);

    }

}

