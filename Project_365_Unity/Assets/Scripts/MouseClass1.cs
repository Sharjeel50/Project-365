using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClass1 : MonoBehaviour {
    public bool lockCursor = true;


    // Use this for initialization
    void Start () {
        //Set Cursor to not be visible
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.M))
        {
            lockCursor = !lockCursor;
        }

        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }
}

