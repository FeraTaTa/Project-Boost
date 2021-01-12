using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {

        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            print("Space pressed");
            body.AddRelativeForce(Vector3.up);
        }        

        if (Input.GetKey(KeyCode.A))
        {
            print("A pressed");
            transform.Rotate(Vector3.forward);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            print("D pressed");
        }
    }
}
