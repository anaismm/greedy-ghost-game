using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCandy : MonoBehaviour
{
    public AudioSource coinFX;
    void OnTriggerEnter(Collider other) {
        coinFX.Play();
        CollectableControls.candyCount += 1;
        this.gameObject.SetActive(false); 
    }
}
