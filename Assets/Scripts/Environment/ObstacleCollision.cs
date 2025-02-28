using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;
    private PlayerJump playerJumpScript; 
    private Animator playerAnimator;
    private CharacterController playerController;
    private PlayerLives playerLivesScript; 
    private PlayerRespawn playerRespawnScript; 

    void Awake()
    {
        // Initialiser les références
        playerJumpScript = thePlayer.GetComponent<PlayerJump>(); // Référence au script PlayerJump
        playerAnimator = charModel.GetComponent<Animator>();
        playerController = thePlayer.GetComponent<CharacterController>();
        playerLivesScript = thePlayer.GetComponent<PlayerLives>(); // Référence au script PlayerLives
        playerRespawnScript = thePlayer.GetComponent<PlayerRespawn>(); // Référence au script PlayerRespawn
    }

    void OnTriggerEnter(Collider other)
    {
       
        playerJumpScript.enabled = false;

       
        playerAnimator.SetTrigger("Collide");

    
        if (playerLivesScript != null && playerLivesScript.GetLives() > 0)
        {
           
            playerRespawnScript.Respawn();
            
        }
        else
        {
          
            Debug.Log("Game Over");
            
        }

        playerLivesScript.TakeDamage();
    }
}
