using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {

    Rigidbody rigidbody;
    AudioSource audioSource;

    enum State{Alive, Dying, Transcending }
    State state = State.Alive;

    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (state == State.Alive)
        {
            Thrust();
            Rotate();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive)
        {
            return;
        }
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                state = State.Transcending;
                Invoke("LoadNextScene", 1f);
                break;
            default:
                state = State.Dying;
                Invoke("RestartGame", 1f);
                break;
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }

    private void Thrust()
    {
        

        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up * mainThrust);
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

        
        float rotationSpeed = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            print("rotating left");
            
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            print("rotating right");
            transform.Rotate(-Vector3.forward * rotationSpeed);
        }
        rigidbody.freezeRotation = false; // resume physics control of rotation
    }
}
