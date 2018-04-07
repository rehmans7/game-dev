using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAttackingLimbController : MonoBehaviour {

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Player") 
		{
			other.gameObject.GetComponent<Health> ().Hit ();
		}
	}

}
