using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float health = 100f;

	// Use this for initialization
	public void RemoveHealth (float amount) {
        health -= amount;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
