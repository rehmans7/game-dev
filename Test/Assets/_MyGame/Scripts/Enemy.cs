using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    //health variable
    public float health = 50f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //takes damage, and specify amount
    public void TakeDamage(float amount)
    {
        //amount is the damage of the gun
        health -= amount;

        //if health is less than or equal to zero, enemy dies
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        //destory the enemy
        Destroy(gameObject);
    }
}
