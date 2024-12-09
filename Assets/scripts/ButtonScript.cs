using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Import Scene Management

public class Button3D : MonoBehaviour
{
    private bool playerIsNear = false; // Flag to track if the player is close to the button

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player enters the trigger zone
        {
            playerIsNear = true;
            Debug.Log("Player is near the button.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player leaves the trigger zone
        {
            playerIsNear = false;
            Debug.Log("Player left the button area.");
        }
    }

    void Update()
    {
        // Check if player is near and presses the E key
        if (playerIsNear && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Button Pressed! Loading Scene...");
            SceneManager.LoadScene("Level1"); // Load Scene2 (change to your scene name)
        }
    }
}
