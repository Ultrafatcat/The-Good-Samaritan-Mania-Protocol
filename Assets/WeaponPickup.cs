using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public string pickupTag = "Player";             // Tag on the player
    public KeyCode pickupKey = KeyCode.E;           // Key to pick up
    public Transform attachPoint;                   // Optional: override attach point
    private bool playerInRange = false;
    private Transform player;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(pickupTag))
        {
            playerInRange = true;
            player = other.transform;
            Debug.Log("Player in range. Press E to pick up.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(pickupTag))
        {
            playerInRange = false;
            player = null;
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(pickupKey))
        {
            PickUp();
        }
    }

    void PickUp()
    {
        Debug.Log("Weapon picked up!");

        // Find the attach point (e.g., a child empty GameObject like "WeaponHolder")
        Transform targetPoint = attachPoint;
        if (targetPoint == null && player != null)
        {
            targetPoint = player.Find("WeaponHolder");
        }

        if (targetPoint != null)
        {
            transform.SetParent(targetPoint);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            GetComponent<Collider>().enabled = false;
            if (GetComponent<Rigidbody>()) Destroy(GetComponent<Rigidbody>());
        }
        else
        {
            Debug.LogWarning("No attach point found on player.");
        }
    }
}
