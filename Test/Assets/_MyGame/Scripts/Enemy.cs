using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

    //health variable
    public float health = 50f;
    public AgentController agent;
    //   public Text healthScore;

    public int enemiesLeft = 0;
    bool killedAllEnemies = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

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
        StartCoroutine(agent.Die());
        //destory the enemy
        //Destroy(gameObject);
    }

    void killAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            SceneManager.LoadScene("finishGame");
        }
    }
}