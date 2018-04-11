using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float ballSpeed = 10;
    public Rigidbody ball;
    public float ballCount = 10;
    public float ballFired = 1;

    public Text Ammo;
    public AudioSource throwBallSound;
    public AudioSource BallFinishedSound;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (ballCount == 0)
            {
                BallFinishedSound.Play();
            }
            else
            {
                fireBullet();
            }

        }

    }

    void fireBullet()
    {

        Rigidbody ballPrefab = (Rigidbody)Instantiate(ball, transform.position, transform.rotation);
        ballPrefab.velocity = transform.forward * ballSpeed;
        throwBallSound.Play();
        updateText();

    }

    void updateText()
    {
        ballCount -= ballFired;
        Ammo.text = ballCount.ToString();
    }
}

