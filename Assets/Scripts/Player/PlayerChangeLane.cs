using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerChangeLane : MonoBehaviour
{
    public InputActionReference moveAction;
    private GameLimits gameLimits;
    private int currentLaneIndex;
    private bool isMoving = true;
    private bool canChangeLane = true; // Pour tester, le laisser activé par défaut
    private float moveSpeed = 5f;
    public float laneSwitchDelay = 0.1f;


    private CharacterController characterController;
    private Vector3 targetPosition;
    private Vector3 moveDirection;

    private void Awake()
    {
        gameLimits = GameObject.Find("LevelControl").GetComponent<GameLimits>();
        characterController = GetComponent<CharacterController>();
        currentLaneIndex = 1;

        isMoving = false;
    }


    private void OnEnable()
    {
        if (moveAction != null)
        {
            moveAction.action.Enable();
            moveAction.action.performed += OnMovePerformed;
        }
        else
        {
            Debug.LogWarning("Move Action Reference is not assigned!");
        }
    }

    private void OnDisable()
    {
        if (moveAction != null)
        {
            moveAction.action.performed -= OnMovePerformed;
            moveAction.action.Disable();
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            float targetLanePosition = gameLimits.GetLanePosition(currentLaneIndex);
            targetPosition = new Vector3(targetLanePosition, transform.position.y, transform.position.z);

           
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, targetPosition);

          
            characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

            if (distance <= moveSpeed * Time.deltaTime)
            {
                characterController.Move(targetPosition - transform.position); 
                isMoving = false; 
            }
        }
    }




    private IEnumerator SwitchLane(int newLaneIndex)
    {
        if (!gameLimits.IsLaneValid(newLaneIndex) || isMoving)
            yield break;

        isMoving = true;
        currentLaneIndex = newLaneIndex;

        float targetLanePosition = gameLimits.GetLanePosition(currentLaneIndex);
        Vector3 targetPosition = new Vector3(targetLanePosition, transform.position.y, transform.position.z);

        float distance = Mathf.Abs(transform.position.x - targetLanePosition);

        while (distance > 0.05f) 
        {
           
            Vector3 moveDirection = new Vector3(targetLanePosition - transform.position.x, 0, 0).normalized;
            Vector3 forwardMovement = new Vector3(0, 0, moveSpeed * Time.deltaTime);

            
            characterController.Move(moveDirection * moveSpeed * Time.deltaTime + forwardMovement);

            distance = Mathf.Abs(transform.position.x - targetLanePosition);
            yield return null;
        }

        
        transform.position = new Vector3(targetLanePosition, transform.position.y, transform.position.z);

        isMoving = false;
    }





    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        if (!canChangeLane || isMoving)
            return;

        float direction = context.ReadValue<float>();

        if (direction > 0 && gameLimits.IsLaneValid(currentLaneIndex + 1)) // Droite
        {
            StartCoroutine(SwitchLane(currentLaneIndex + 1));
        }
        else if (direction < 0 && gameLimits.IsLaneValid(currentLaneIndex - 1)) // Gauche
        {
            StartCoroutine(SwitchLane(currentLaneIndex - 1));
        }
    }



    public void SetCanChangeLane(bool value)
    {
        canChangeLane = value;
        isMoving = false;
    }

    public void SetIsMoving(bool value)
    {
        isMoving = value;
    }



}
