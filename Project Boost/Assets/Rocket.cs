using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    Rigidbody body;
    AudioSource audioThrust;
    [SerializeField]
    Timer scoreTimer;
    public float rotateSpeed = 1;
    public float thrustSpeed = 1;
    [SerializeField]
    float deathDropTime = 2f;

    enum Feras
    {
        Alive,
        Dying,
        Transcending
    }
    Feras state = Feras.Alive;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        audioThrust = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(state == Feras.Alive)
        {
            Rotate();
            Thrust();
        }
        if(state == Feras.Transcending)
        {
            //Spin and win
        }
    }

    private void Rotate()
    {
        body.freezeRotation = true;
        if (Input.GetKey(KeyCode.A))
        {
            //print("A pressed");
            transform.Rotate(Vector3.left * rotateSpeed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            //print("D pressed");
            transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
        }
        body.freezeRotation = false;
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //print("Space pressed");
            body.AddRelativeForce(Vector3.up * thrustSpeed);
            if (!audioThrust.isPlaying)
            {
                audioThrust.Play();
            }
        }
        else
        {
            audioThrust.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //switch(collision.gameObject.tag)
        //{
        //    case "Friendly":
        //        print("safe");
        //        break;

        //    default:
        //        print("Destroy");
        //        break;
        //}
        if (state != Feras.Alive)
            return;

        if (collision.gameObject.tag == "Friendly" || collision.gameObject.tag == "Start")
        {
            print("safe");
        }
        else if (collision.gameObject.tag == "Goal")
        {
            state = Feras.Transcending;
            scoreTimer.timerStarted = false;
            print("Winner!");
            Invoke("LoadNextLevel", deathDropTime);
        }
        else
        {
            audioThrust.Stop();
            state = Feras.Dying;
            print("Destroy by " + collision.gameObject.name);
            Invoke("ResetToLevel_1", deathDropTime);
        }
    }

    private void ResetToLevel_1()
    {
        SceneManager.LoadScene(0);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Start")
        {
            scoreTimer.timerStarted = true;

        }
    }
}
