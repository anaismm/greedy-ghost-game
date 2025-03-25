using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRunSequence : MonoBehaviour
{
    [SerializeField] private GameObject candies;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject fadeOut;

    private bool hasEnded = false; 
    public void TriggerEndSequence()
    {
        if (!hasEnded) 
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
        yield return new WaitForSeconds(3);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
