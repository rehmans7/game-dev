using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour {
    // Use this for initialization
    void Start()
    {
        //dieHashId = Animator.StringToHash("die");
        StartCoroutine(Cutscene());
    }

    public Image imageToFade;
    public Transform cameraEndPosition;
    public Transform cam;
    // public AudioSource enemyDieAudio;
    public AudioSource clownAudio;
    public Animator enemyAnim;
    public EnemyController enemy;
    public int danceHashId;


    IEnumerator Cutscene()
    {
        yield return new WaitForSeconds(1);
        imageToFade.DOFade(0, 2);
        cam.DOMove(cameraEndPosition.position, 10);
        yield return new WaitForSeconds(8);
        clownAudio.Play();
        enemyAnim.SetTrigger(danceHashId);
        yield return new WaitForSeconds(10);
        enemy.EnableEnemy();
        clownAudio.Stop();
        yield return new WaitForSeconds(5);
        imageToFade.DOFade(1, 2);
    }
}
