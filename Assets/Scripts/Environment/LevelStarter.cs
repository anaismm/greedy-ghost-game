using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    [SerializeField] private GameObject countdown3;
    [SerializeField] private GameObject countdown2;
    [SerializeField] private GameObject countdown1;
    [SerializeField] private GameObject countdownGo;
    [SerializeField] private GameObject fadeIn;
    [SerializeField] private AudioSource readyFX;
    [SerializeField] private AudioSource goFx;

    private float delayBetweenCounts = 1.0f; 
    private float initialDelay = 0.5f;

   
    void Start()
    {
        StartCoroutine(CountSequence());
    }

    // THE 3,2,1, GO 
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
