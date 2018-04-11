using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    //amount of damage from gun
    public float damage = 10f;
    public float range = 100f;


    public ParticleSystem gunFlash;
    //to shoot a ray to the camera
    public Camera fpsCam;
    //had a flash when something is hit variable
    public GameObject hitEffect;

    //   public GameObject bulletPrefab;
    public float impactForce = 30f;
    //to limit how quickly to fire the gun
    public float fireRate = 15f;

    //next time to fire
    public float nextFireTime = 0f;

 //   public Transform firingPosition;
  //  public float firePower;


    // Use this for initialization
    void Start () {
        //everytime an ammo is shot, take one away
   //      currentAmmo = maxAmmo;
	}
	
	// Update is called once per frame
	void Update () {
        //if the button is pressed and the current time is greater or equal to the next fire time, shoot
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            //next fire time is the current time + the 0.25 fire rate
            nextFireTime = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        gunFlash.Play();

        Debug.Log("shoot...");

      //  currentAmmo--;

        //stores info about what to hit with our ray
        RaycastHit hit;

        //to shoot out the ray starting at the position of the camera, to shoot in position its facing (forward), outhit- put al info in here, range - how far to hit
        //if - returns true if something is hit with the ray
             Debug.DrawLine(fpsCam.transform.position, fpsCam.transform.position + (fpsCam.transform.forward * range), Color.red, 1f);
       //      AmmoManager.Instance.DecreaseAmmo();
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //to check if it has been hit
            Debug.Log(hit.transform.name);

            //find the enemy component on the enemy that is hit.
            Enemy enemy = hit.transform.GetComponent<Enemy>();

            //hit enemy only if a component has been found
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            //if the object has a rigidbody, add a force (for when it is hit). 
            if (hit.rigidbody != null)
            {
                //add a force to the direction, backwards and muliple it by an impact force
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            //had the flash impact if something is hit, hit the point, take the direction and turn it into a quaternion
            GameObject shootbullet = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));

            //destroy the hit effect after one second
            Destroy(shootbullet, 1f);
        }




        //    GameObject bullet = Instantiate(bulletPrefab, firingPosition.position, firingPosition.rotation);
        //    Destroy(bullet, 1f);
        //   Rigidbody rb = bullet.GetComponent<Rigidbody>();
        //   rb.AddForce(firingPosition.transform.forward * firePower, ForceMode.Impulse);
        //    GameManager.Instance.DecreaseAmmo();
        //}
    }

}