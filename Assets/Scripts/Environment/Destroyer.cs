using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public string parentName;
    public float timeBeforeDestruction = 50f; 
    public float destructionInterval = 5f; 

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
