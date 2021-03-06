using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMove : MonoBehaviour
{
    public float speed = 10.0f;
    private float translation;
    private float straffe;
    public bool running;


    void Start () {
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;
        running = false;
    }

    // Update is called once per frame
    void Update () {
        // Input.GetAxis() is used to get the user's input
        // You can furthor set it on Unity. (Edit, Project Settings, Input)
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        // hold shift to run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            running = true;
            translation = translation*3;
            straffe = straffe*3;
        }
        else
        {
            running = false;
        }

        transform.Translate(straffe, 0, translation);


       if (Input.GetKeyDown("escape")) {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
