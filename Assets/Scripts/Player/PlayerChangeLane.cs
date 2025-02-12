using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerChangeLane : MonoBehaviour
{
    public InputActionReference moveAction; 
    private GameLimits gameLimits;
    private int currentLaneIndex;
    private bool isMoving;
    private bool canChangeLane = false;
    private float moveSpeed = 5f; // Vitesse de déplacement
    public float laneSwitchDelay = 0.2f; // Délai avant d'accepter un nouveau changement de colonne

    private void Awake()
    {
        gameLimits = GameObject.Find("LevelControl").GetComponent<GameLimits>();
        currentLaneIndex = 1; 

        // Always start on the middle lane
        Vector3 startPosition = new Vector3(gameLimits.GetLanePosition(currentLaneIndex), transform.position.y, transform.position.z);
        transform.position = startPosition;
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
        // Désactiver l'action lorsque le script est désactivé
        if (moveAction != null)
        {
            moveAction.action.performed -= OnMovePerformed;
            moveAction.action.Disable();
        }
    }

    private void Update()
    {
        // Si le joueur est en train de se déplacer entre deux colonnes, ignorer les entrées car il y a un temps de delai avant de pouvoir encore changer de colonne
        if (isMoving)
            return;

        // Récupérer la position de la colonne actuelle
        float targetLanePosition = gameLimits.GetLanePosition(currentLaneIndex);

        // Déplacer le joueur vers la colonne
        Vector3 targetPosition = new Vector3(targetLanePosition, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    private IEnumerator SwitchLane(int newLaneIndex)
    {
        // Lorsqu'il est en train de changer de colonne
        isMoving = true;

        currentLaneIndex = newLaneIndex;

        // Il y a un petit temps d'attente avant de pouvoir changer de colonne
        yield return new WaitForSeconds(laneSwitchDelay);
        isMoving = false;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        if (!canChangeLane || isMoving)
            return;

        float direction = context.ReadValue<float>();
        
        if (direction > 0) // Mouvement à droite
        {
            if (gameLimits.IsLaneValid(currentLaneIndex + 1))
            {
                StartCoroutine(SwitchLane(currentLaneIndex + 1));
            }
        }
        else if (direction < 0) // Mouvement à gauche
        {
            if (gameLimits.IsLaneValid(currentLaneIndex - 1))
            {
                StartCoroutine(SwitchLane(currentLaneIndex - 1));
            }
        }
    }

    public void SetCanChangeLane(bool value)
    {
        canChangeLane = value;
    }
}
