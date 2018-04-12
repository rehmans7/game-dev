using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWayTriggerHandler : MonoBehaviour {

    public AudioSource audio;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            audio.Play();
        }
    }
}
