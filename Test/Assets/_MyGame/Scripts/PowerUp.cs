using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public GameObject pickupEffect;
    public float multiplier;
    public float duration = 4f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    ///    if (Input.GetKey(KeyCode.U))
    ///    {
    ///        StartCoroutine(Pickup());
    ///    }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        //   Debug.Log("Power up picked up!");

        //spawn a cool effect
        Instantiate(pickupEffect, transform.position, transform.rotation);

        //apply effect to the player
        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.health *= multiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        //wait x amount of seconds
        yield return new WaitForSeconds(duration);

        //reverse the effect on our player
        stats.health /= multiplier;

        //remove power up object
        Destroy(gameObject);
    }
}
