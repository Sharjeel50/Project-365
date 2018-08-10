using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public float speed = 6f;
    public float gravity = -9.8f;
    private CharacterController _charCont;

	// Use this for initialization
	void Start () {
        _charCont = GetComponent<CharacterController>();
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
	}
}
