using System.Collections;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject thePlayer;

    public void Respawn()
    {
        StartCoroutine(RespawnRoutine());
    }

    IEnumerator RespawnRoutine()
    {
        thePlayer.GetComponent<PlayerMove>().enabled = false; 

        yield return new WaitForSeconds(1f); 

        Vector3 startPos = transform.position;
        Vector3 targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 3);
        float timeToMove = 0.5f;
        float elapsedTime = 0f;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        thePlayer.GetComponent<PlayerMove>().enabled = true; 
    }
}

