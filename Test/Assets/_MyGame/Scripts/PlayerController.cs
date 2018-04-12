using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float bulletSpeed = 10;
    public Rigidbody bullet;
    public float ammoCount = 10;
    public float shootAmmo = 1;

    public Text Ammo;
    public AudioSource shootBulletSound;
    public AudioSource emptyGunSound;
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
    private void Start()
    {
        Ammo.text = "10";
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (ammoCount == 0)
            {
                emptyGunSound.Play();
            }
            else
            {
                fireBullet();
            }

        }

    }

    void fireBullet()
    {
        gunFlash.Play();
        RaycastHit hit;

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
                //        enemy.GetComponent<AgentController>().type = AgentController.AgentType.Die;
            }



            //if the object has a rigidbody, add a force (for when it is hit). 
            if (hit.rigidbody != null)
            {
                //add a force to the direction, backwards and muliple it by an impact force
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            //had the flash impact if something is hit, hit the point, take the direction and turn it into a quaternion
            GameObject shootbullet = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));

            ///            if(hit.transform.tag == "Enemy")
            ///            {
            ///                hit.transform.GetComponent<EnemyHealth>().RemoveHealth(enemyDamage);
            ///            }
            ///            else
            ///            {
            ///                GameObject shootbullet = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            ///                shootBulletSound.Play();
            ///               Destroy(shootbullet, 1f);


            //      shootBulletSound.Play();
            //   updateText();

            //destroy the hit effect after one second
            Destroy(shootbullet, 1f);
        }
        updateText();

    }

    void updateText()
    {
        ammoCount -= shootAmmo;
        Ammo.text = ammoCount.ToString();
    }
}

