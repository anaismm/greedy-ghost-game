using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private string parentName;
    [SerializeField] private float timeBeforeDestruction = 50f; 
    [SerializeField] private float destructionInterval = 5f; 

    private static List<GameObject> sectionsToDestroy = new List<GameObject>(); 

    void Start()
    {
        parentName = transform.name;
        sectionsToDestroy.Add(gameObject); 
        if (sectionsToDestroy.Count == 1)
        {
            StartCoroutine(DestroySections());
        }
    }

    //Destroy sections of the road that are passed 
    IEnumerator DestroySections()
    {
        yield return new WaitForSeconds(timeBeforeDestruction);

        while (sectionsToDestroy.Count > 0)
        {
            
            GameObject section = sectionsToDestroy[0];
            sectionsToDestroy.RemoveAt(0); 

            if (section != null && section.name == "Section(Clone)")
            {
                Destroy(section); 
            }

            yield return new WaitForSeconds(destructionInterval); 
        }
    }
}
