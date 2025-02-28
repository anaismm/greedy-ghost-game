using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 3f; // Force du saut augmentée pour un meilleur ressenti
    public float gravity = -15f; // Gravité de Unity (négatif car dirigé vers le bas)
    public float fallMultiplier = 1.8f; // Accélération de la chute pour un saut plus naturel
    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        // Vérifie si le joueur est au sol
        isGrounded = characterController.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f; // Empêche une accumulation de vélocité négative
        }
        characterController.Move(Vector3.down * 0.1f * Time.deltaTime);

        // Applique la gravité
        velocity.y += gravity * fallMultiplier * Time.deltaTime;

        // **Ajout du déplacement vers l'avant**
        float moveSpeed = 4f; // Vitesse de déplacement
        velocity.z = moveSpeed; // Ajout de la vitesse vers l'avant

        // Applique le mouvement
        characterController.Move(velocity * Time.deltaTime);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity); // Formule réaliste du saut
    }
}

