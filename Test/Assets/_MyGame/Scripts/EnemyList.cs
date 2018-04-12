using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyList : MonoBehaviour {

    // public List<Transform> enemies;
    int enemiesLeft = 0;
    bool killedAllEnemies = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
