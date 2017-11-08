using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Rocket rocket;

    private Vector3 offset;
    // Use this for initialization
    void Start () {
        offset = transform.position - rocket.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = rocket.transform.position + offset;
	}
}
