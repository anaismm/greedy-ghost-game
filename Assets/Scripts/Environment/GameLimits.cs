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
            return 0f; 
        }
    }

    public bool IsLaneValid(int laneIndex)
    {
        return laneIndex >= 0 && laneIndex < LanePositions.Length;
    }
}

