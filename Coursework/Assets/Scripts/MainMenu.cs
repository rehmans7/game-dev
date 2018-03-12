using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	public void PlayGame () {
        SceneManager.LoadSceneAsync(1);
	}

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
