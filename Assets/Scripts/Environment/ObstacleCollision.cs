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
        playerJumpScript = thePlayer.GetComponent<PlayerJump>();
        playerAnimator = charModel.GetComponent<Animator>();
        playerController = thePlayer.GetComponent<CharacterController>();
        playerLivesScript = thePlayer.GetComponent<PlayerLives>();
        playerRespawnScript = thePlayer.GetComponent<PlayerRespawn>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (playerLivesScript == null || playerLivesScript.GetLives() <= 0)
        {
            return;
        }

        playerJumpScript.enabled = false;
        playerAnimator.SetTrigger("Collide");

        playerLivesScript.TakeDamage();

        if (playerLivesScript.GetLives() > 0)
        {
            playerRespawnScript.Respawn();
        }
    }

}
