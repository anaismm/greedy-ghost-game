using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLimits : MonoBehaviour
{
    // Liste des positions des colonnes
    [SerializeField] private float[] LanePositions = { -3.41f, -1.7f, 0f };

    public int GetLaneCount()
    {
        return LanePositions.Length;
    }

    public float GetLanePosition(int laneIndex)
    {
        if (laneIndex >= 0 && laneIndex < LanePositions.Length)
        {
            return LanePositions[laneIndex];
        }
        else
        {
            Debug.LogWarning("Lane index out of bounds: " + laneIndex);
            return 0f; // Valeur par défaut au cas où
        }
    }

    public bool IsLaneValid(int laneIndex)
    {
        return laneIndex >= 0 && laneIndex < LanePositions.Length;
    }
}

