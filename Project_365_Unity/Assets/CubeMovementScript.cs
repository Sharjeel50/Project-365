using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovementScript : MonoBehaviour {

    public Rigidbody a;
   
	// Update is called once per frame
	void Update () {


        if (Input.GetKey("w"))
        {
            a.AddForce(100 * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("s"))
        {
            a.AddForce(-100 * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("d"))
        {
            a.AddForce(0,0,-100 * Time.deltaTime);
        }

        if (Input.GetKey("a"))
        {
            a.AddForce(0, 0, 100 * Time.deltaTime);
        }

        if (Input.GetKey("w") && Input.GetKey("shift"))
        {
            a.AddForce(200 * Time.deltaTime, 0, 0);
        }



    }
}
