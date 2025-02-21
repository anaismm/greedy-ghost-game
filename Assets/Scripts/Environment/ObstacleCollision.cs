using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;
    private PlayerMove playerMoveScript; // Référence au script PlayerMove
    private Animator playerAnimator;
    private CharacterController playerController;



    void Awake()
    {
        // Initialiser les références
        playerMoveScript = thePlayer.GetComponent<PlayerMove>();
        playerAnimator = charModel.GetComponent<Animator>();
        playerController = thePlayer.GetComponent<CharacterController>();
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     // Vérifie si le joueur est en train de sauter
    //     bool isJumping = playerAnimator.GetBool("isJumping");

    //     // Si le joueur saute, on ignore la collision
    //     if (isJumping && other.CompareTag("Citrouille"))
    //     {
    //         // Si le joueur saute, on ne fait rien (ou on peut ajouter des effets visuels si besoin)
    //         return;
    //     }
    //     else
    //     {
    //         // Sinon, on exécute la logique de collision normale
    //         this.gameObject.GetComponent<BoxCollider>().enabled = false; // Désactive le collider de l'obstacle
    //         thePlayer.GetComponent<PlayerMove>().enabled = false; // Désactive le mouvement du player
    //         thePlayer.GetComponent<PlayerLives>().TakeDamage(); // Applique les dégâts au player
    //         charModel.GetComponent<Animator>().SetTrigger("Collide"); // Déclenche l'animation de collision
    //     }
    // }


    void OnTriggerEnter(Collider other)
    {
        // Vérifie si le joueur est en train de sauter
        bool isJumping = playerAnimator.GetBool("isJumping");

        // Vérifie si l'objet en collision a le layer "Citrouille"
        int citrouilleLayer = LayerMask.NameToLayer("Citrouille"); 

        // Si le joueur saute et que l'objet est une citrouille, on ignore la collision
        if (isJumping && other.gameObject.layer == citrouilleLayer)
        {
            // Ignore la collision pendant le saut avec la citrouille
            return;
        }

        // Sinon, on gère les collisions avec d'autres obstacles
        else
        {
            // Si ce n'est pas une citrouille ou que le joueur ne saute pas, applique la logique de collision normale
            this.gameObject.GetComponent<BoxCollider>().enabled = false; // Désactive le collider de l'obstacle
            thePlayer.GetComponent<PlayerMove>().enabled = false; // Désactive le mouvement du player
            thePlayer.GetComponent<PlayerLives>().TakeDamage(); // Applique les dégâts au player
            charModel.GetComponent<Animator>().SetTrigger("Collide"); // Déclenche l'animation de collision
        }
    }
}



