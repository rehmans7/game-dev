using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickupController : MonoBehaviour
{
    public PlayerController player;
    public AudioSource reloadAmmoSound;

    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("walked over the ball");
            player.Ammo.text = player.Ammo.text + 10;
            player.ammoCount = player.ammoCount + 10;

            int maxAmmo = 20;

            if (player.ammoCount > maxAmmo)
            {
                player.ammoCount = 20;
            }
            reloadAmmoSound.Play();
            player.Ammo.text = player.ammoCount.ToString();
            GetComponent<Renderer>().enabled = false;
            StartCoroutine(ShowObject());
        }
    }

    private IEnumerator ShowObject()
    {
        float secs = 5f;
        yield return new WaitForSeconds(secs);
        GetComponent<Renderer>().enabled = true;
    }
}

