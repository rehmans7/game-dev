using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

    public GameObject destroyedEnemy;

    private void OnMouseDown()
    {
        Instantiate(destroyedEnemy, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
