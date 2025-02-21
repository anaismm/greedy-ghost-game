using System.Collections;
using UnityEngine;

public class EndRunSequence : MonoBehaviour
{
    public GameObject candies;
    public GameObject endScreen;
    public GameObject fadeOut;

    private bool hasEnded = false; // Empêche le déclenchement multiple

    public void TriggerEndSequence()
    {
        if (!hasEnded) // Vérifie si la fin a déjà été déclenchée
        {
            hasEnded = true;
            StartCoroutine(EndSequence());
        }
    }

    IEnumerator EndSequence()
    {
        yield return new WaitForSeconds(1);
        candies.SetActive(false);
        endScreen.SetActive(true);
        yield return new WaitForSeconds(2);
        fadeOut.SetActive(true);
    }
}
