using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public float speed = 6f;
    public float gravity = 20.0f;
    private CharacterController _charCont;
    public bool jumpkey;

	// Use this for initialization
	void Start () {
        _charCont = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		float deltaX = Input.GetAxis("Horizontal") * speed; //Get the inputs from 
        float deltaZ = Input.GetAxis("Vertical")* speed;

        Vector3 Movement = new Vector3(deltaX, 0, deltaZ);
        Movement = Vector3.ClampMagnitude(Movement, speed); //clamps speed so movement is always the same

        //Jump Below

        if (Input.GetButton("Jump"))
        {
            jumpkey = true;
        } else
        {
            jumpkey = false;
        }

        if (_charCont.isGrounded && jumpkey == true)
        {
            while (jumpkey == true)
            {
                Movement.y += 2.0f;
            }
            
        }
        else if (_charCont.isGrounded)
        {
            Movement.y = 0.0f;
        }
        else
        {
            Movement.y -= gravity * Time.deltaTime;
        }


        Movement *= Time.deltaTime; // fixes the movement so that its the same across different frame rates.
        Movement = transform.TransformDirection(Movement);
        _charCont.Move(Movement); 
	}
}
