using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupPrompt : MonoBehaviour
{
      public TextMeshProUGUI pickupText; // Reference to your TextMeshPro UI text
    public float detectionRadius = 5f; // Distance at which text will appear

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player has a "Player" tag
        {
            pickupText.gameObject.SetActive(true); // Show text when close
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickupText.gameObject.SetActive(false); // Hide text when player is away
        }
    }
//    public TextMeshProUGUI promptText;  // Instead of GameObject, now we directly reference the TMP Text
//     public string pickupTag = "Player";

//     void Start()
//     {
//         if (promptText != null)
//         {
//             promptText.gameObject.SetActive(false); // Hide prompt at start
//         }
//     }

//     void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag(pickupTag))
//         {
//             if (promptText != null)
//             {
//                 promptText.gameObject.SetActive(true); // Show prompt
//             }
//         }
//     }

//     void OnTriggerExit(Collider other)
//     {
//         if (other.CompareTag(pickupTag))
//         {
//             if (promptText != null)
//             {
//                 promptText.gameObject.SetActive(false); // Hide prompt
//             }
//         }
//     }
}
