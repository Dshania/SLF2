using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScoreSystem : ScriptableObject
{
    public float levelScore;
    public float ChatterPoints;

    public float TotalScore;

    PlayerStats playerStats;
    private void OnEnable()
    {
        levelScore = 0;
        ChatterPoints = 0;
        TotalScore = 0;
    }

}
