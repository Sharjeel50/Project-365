using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public float speed = 6f;
    public float gravity = -9.8f;
    private CharacterController _charCont;

    private Rigidbody rb;
    public float JumpForce = 7f;
    public GameObject bullet;
    public CapsuleCollider col;

    public LayerMask groundLayers;

	// Use this for initialization
	void Start () {
        _charCont = GetComponent<CharacterController>();
        col = GetComponent<CapsuleCollider>();
    }
	
	// Update is called once per frame
	void Update () {
		float deltaX = Input.GetAxis("Horizontal") * speed; //Get the inputs from 
        float deltaY = Input.GetAxis("Vertical") * speed;
        Vector3 Movement = new Vector3(deltaX, 0, deltaY);
        Movement = Vector3.ClampMagnitude(Movement, speed); //clamps speed so movement is always the same

        Movement.y = gravity; // sets gravity on y axis

        Movement *= Time.deltaTime; // fixes the movement so that its the same across different frame rates.
        Movement = transform.TransformDirection(Movement);
        _charCont.Move(Movement);

        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    
	}

    private bool IsGrounded()
    {

        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
            col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
    }

}

