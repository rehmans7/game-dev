using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {

    public float health = 100f;

	// Use this for initialization
	public void Hit(float amount)
    {
        health -= amount;
        Debug.Log("hit");

        if (health <= 0f)
        {
            health = 0;
            Debug.Log("hit");
            SceneManager.LoadScene("gameOver");
        }
    }
}