using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    public GameObject countdown3;
    public GameObject countdown2;
    public GameObject countdown1;
    public GameObject countdownGo;
    public GameObject fadeIn;
    public AudioSource readyFX;
    public AudioSource goFx;

    private float delayBetweenCounts = 1.0f; 
    private float initialDelay = 0.5f;

   
    void Start()
    {
        StartCoroutine(CountSequence());
    }

    IEnumerator CountSequence() 
    {
        GameObject.FindObjectOfType<PlayerChangeLane>().SetCanChangeLane(false);
        
        yield return new WaitForSeconds(initialDelay);
        countdown3.SetActive(true);
        readyFX.Play();

        yield return new WaitForSeconds(delayBetweenCounts);
        countdown2.SetActive(true);
        readyFX.Play();

        yield return new WaitForSeconds(delayBetweenCounts);
        countdown1.SetActive(true);
        readyFX.Play();

        yield return new WaitForSeconds(delayBetweenCounts);
        countdownGo.SetActive(true);
        goFx.Play();

        GameObject.FindObjectOfType<PlayerChangeLane>().SetCanChangeLane(true);
    }

}
