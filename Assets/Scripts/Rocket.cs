using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidbody;
    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        Thrust();
        Rotate();
    }
    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void Rotate()
    {
        rigidbody.freezeRotation = true; //take manual control of rotation

        if (Input.GetKey(KeyCode.A))
        {
            print("rotating left");
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            print("rotating right");
            transform.Rotate(-Vector3.forward);
        }
        rigidbody.freezeRotation = false; // resume physics control of rotation
    }
}
