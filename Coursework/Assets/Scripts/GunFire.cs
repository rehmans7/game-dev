using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunFire : MonoBehaviour {

    public AudioSource gunFireSound;

	// Use this for initialization
	void Start () {
        gunFireSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            gunFireSound.Play();
           // GetComponent.<Animation>().Play("Shoot");
        }
    }
}
