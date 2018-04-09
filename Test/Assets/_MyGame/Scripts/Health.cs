using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public AudioClip pain;
	public AudioSource audio;

	public void Hit() 
	{
		audio.PlayOneShot (pain);
	}

}
