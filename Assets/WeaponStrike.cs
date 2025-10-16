using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStrike : MonoBehaviour
{
    public bool isTargetStruck = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTargetStruck)
        {
            // Perform strike action
            Debug.Log("You have struck the target!");
            isTargetStruck = true;

            // Enable cleanup action if target is struck
            // Show some UI elements or update the game state
        }
    }
}
