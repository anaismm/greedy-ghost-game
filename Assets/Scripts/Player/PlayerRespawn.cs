using System.Collections;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject thePlayer;
    private Animator playerAnimator;
    private PlayerChangeLane playerChangeLaneScript; 
    private PlayerJump playerJumpScript; 
    

    private void Awake()
    {
        
        playerAnimator = thePlayer.GetComponent<Animator>();
        playerChangeLaneScript = thePlayer.GetComponent<PlayerChangeLane>();
        playerJumpScript = thePlayer.GetComponent<PlayerJump>();
    }

    public void Respawn()
    {
        StartCoroutine(RespawnRoutine());
    }


    // To respawn the player
    IEnumerator RespawnRoutine()
    {
        playerJumpScript.enabled = false; 

        yield return new WaitForSeconds(1f); 

        Vector3 startPos = transform.position;
        Vector3 targetPos = new Vector3(thePlayer.transform.position.x, transform.position.y, transform.position.z - 3);
        float timeToMove = 0.5f;
        float elapsedTime = 0f;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        playerJumpScript.enabled = true; 

        if (playerChangeLaneScript != null)
        {
            playerChangeLaneScript.SetCanChangeLane(true); 
        }

      
        if (playerChangeLaneScript != null)
        {
            playerChangeLaneScript.SetIsMoving(true); 
        }
    }
}

