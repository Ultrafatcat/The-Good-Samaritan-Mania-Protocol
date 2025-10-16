using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrypticNote : MonoBehaviour
{
    public string clueMessage = "Clue: Look for the target in the alley";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(clueMessage);
            // Add functionality to display the clue in UI or log
            // You can also enable the next objective after the note is read
        }
    }
}
