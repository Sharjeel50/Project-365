using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    

    public enum RotationAxis //enum with both types of axes
    {
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxis axes = RotationAxis.MouseX; // create axes variable that can be set to mouse x or y

    public float minvert = -45.0f;
    public float maxvert = 45.0f;
    public float sensHorizontal = 10.0f;   //sensitivity
    public float sensVertical = 10.0f;

    public float _rotationX = 0;

    // Update is called once per frame
    void FixedUpdate () {
        if (axes == RotationAxis.MouseX) // if axes is set Mouse X
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensHorizontal, 0); // transform the rotation of the camera by the input from mouse and multiply that by the sensitivity

        }else if (axes == RotationAxis.MouseY)

        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensVertical; // _rotationX = _rotationX - input * sens 
            _rotationX = Mathf.Clamp(_rotationX, minvert, maxvert); // Clamps vert angle within  min and max angles

            float rotationY = transform.localEulerAngles.y; //???
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);//???
        }

    }
}
