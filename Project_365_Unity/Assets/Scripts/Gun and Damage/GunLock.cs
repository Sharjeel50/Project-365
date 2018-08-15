using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLock : MonoBehaviour {
    public MeshFilter GunR;
    // Use this for initialization
    void Start () {
        GunR = GetComponent<MeshFilter>();
	}
	
	// Update is called once per frame
	void Update () {
        GunR.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
    }
}
