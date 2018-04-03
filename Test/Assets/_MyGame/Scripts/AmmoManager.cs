/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmmoManager : MonoBehaviour
{

    public static AmmoManager Instance;

    public bool HasAmmo { get { return currentAmmo > 0; } }

    public Transform player;

    public int maxAmmo = 10;
    public int currentAmmo =10;
    public float reloadTime = 1f;

    private bool isReloading = false;
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {

    }

   /* public void IncreaseScore()
    {
        score += Mathf.CeilToInt(Vector3.Distance(player.position, hoop.position));
    }*/

 /*   public void DecreaseAmmo()
    {
        currentAmmo--;
        // no need for audio here as covered by firing sound
    }

    public void IncreaseAmmo()
    {
        currentAmmo += 10;
        currentAmmo = Mathf.Min(currentAmmo, 20);
    }

    IEnumerator Reload()
    {
       isReloading = true;
       Debug.Log("Reloading...");
       //set ammo
       yield return new WaitForSeconds(reloadTime);
       currentAmmo = maxAmmo;
       //once done, set to false
       isReloading = false;
    }

    public void Update()
    {
        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());

            //stop here and do not continue to next if statement
            return;
        }
    }
}
*/