using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigationSystem : MonoBehaviour
{
    public bool investigationStarted = false;
    public float timeRemaining = 60f; // Time for investigation to start

    void Update()
    {
        if (investigationStarted)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                Debug.Log("The police are investigating! You failed to clean up.");
                // Trigger game-over or need to adapt
            }
        }
    }

    public void StartInvestigation()
    {
        investigationStarted = true;
        timeRemaining = 60f; // Reset time for investigation
        Debug.Log("Investigation started! Clean up fast.");
    }
}
