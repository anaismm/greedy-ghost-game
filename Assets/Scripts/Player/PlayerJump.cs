using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 3f; 
    [SerializeField] private float gravity = -15f; 
    [SerializeField] private float fallMultiplier = 1.8f; 
    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {

        isGrounded = characterController.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f; 
        }
        characterController.Move(Vector3.down * 0.1f * Time.deltaTime);

        velocity.y += gravity * fallMultiplier * Time.deltaTime;

      
        float moveSpeed = 4f; 
        velocity.z = moveSpeed; 

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
        velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity); 
    }
}

