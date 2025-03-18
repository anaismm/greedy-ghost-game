using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    private int lives = 3; 
    public GameObject[] lifeIcons; 
    public PlayerRespawn respawnScript;
    public GameObject levelControl;

    public void TakeDamage()
    {
        lives--;

        UpdateLivesUI();

        if (lives <= 0)
        {
            lives = 0;
            GameOver();
            return;
        }
       
        respawnScript.Respawn(); 
        
    }

    void UpdateLivesUI()
    {
        if (lives >= 0 && lives < lifeIcons.Length)
        {
            lifeIcons[lives].SetActive(false);
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        GameObject.FindObjectOfType<PlayerChangeLane>().SetCanChangeLane(false);
        levelControl.GetComponent<EndRunSequence>().TriggerEndSequence(); 
    }

    public int GetLives()
    {
        return lives;
    }


}
