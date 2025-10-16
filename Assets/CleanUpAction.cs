using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpAction : MonoBehaviour
{
    public bool isCleanedUp = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCleanedUp)
        {
            Debug.Log("You cleaned up the scene.");
            isCleanedUp = true;

            // Disable any evidence or change the game state (e.g., starting police investigation)
            // Optionally, you can trigger a successful cleanup message.
        }
    }
}
