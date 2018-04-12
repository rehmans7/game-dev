using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    // public Rigidbody[] rigidbodies;
    Rigidbody[] rigidbodies;
    private void Awake()
    {
        /* Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
         for (int i = 0; i < rigidbodies.Length; i++)
         {
             rigidbodies[i].isKinematic = true;
         }*/

        rigidbodies = GetComponentsInChildren<Rigidbody>();

        for(int i = 0; i < rigidbodies.Length; i++)
        {
            rigidbodies[i].isKinematic = true;
        }
    }

    void Update () 
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			EnableEnemy();
		} 
	}

	public void EnableEnemy()
	{
        GetComponent<Animator>().enabled = false;

        for (int i = 0; i < rigidbodies.Length; i++)
        {
            rigidbodies[i].isKinematic = false;
        }
    }
}
