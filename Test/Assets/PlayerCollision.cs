using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour {

    //   public PlayerController movement;

   // public float gameOverDelay = 20f;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            Debug.Log("We hit an ");
            //        movement.enabled = false;
      //      Invoke("gameOver", gameOverDelay);
            SceneManager.LoadScene("gameOver");
        }
    }


}
