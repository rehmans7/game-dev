
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunDamage : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public ParticleSystem gunFlash;
    public GameObject impactEffect;
    public float impactForce = 30f;
    public float fireRate = 15f;
    public float nextTimeToFire = 0f;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") && Time.time>= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
	}

    void Shoot()
    {
        gunFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            //find the target component for what is hit.
            Target target = hit.transform.GetComponent<Target>();

            //hit target only if a component has been found
            if (target != null)
            {
                target.TakeDamage(damage);
                
            }

            //if the object has a rigidbody, add a force. 
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
