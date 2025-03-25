using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] section;
    public int zPos = 20;
    private bool creatingSection = false; 
    private int secNum;

    void Update()
    {
        if (creatingSection == false ) {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection ()
    {
        secNum = Random.Range(0,3);
        GameObject newSection = Instantiate(section[secNum], new Vector3(0,0,zPos), Quaternion.identity);
        newSection.layer = LayerMask.NameToLayer("Ground");
        zPos += 20;
        yield return new WaitForSeconds(3);
        creatingSection = false;
    }
}
