using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    private int lives = 3; // Nombre de vies du joueur
    public GameObject[] lifeIcons; // Tableau des images de vie
    public PlayerRespawn respawnScript; // Référence au script de respawn

    public void TakeDamage()
    {
        lives--;

        UpdateLivesUI();

        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            respawnScript.Respawn(); // Appelle la méthode de respawn
        }
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
        // Ici, tu peux ajouter du code pour afficher un écran de Game Over, arrêter le jeu, etc.
    }
}
