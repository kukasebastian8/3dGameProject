using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button3D : MonoBehaviour
{
    private bool playerIsNear = false; // Flag to track if the player is close to the button
    private string buttonTag; // To store the tag of the button the player is near

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player enters the trigger zone
        {
            playerIsNear = true;
            buttonTag = gameObject.tag; // Store the tag of this button
            Debug.Log("Player is near the button: " + buttonTag);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player leaves the trigger zone
        {
            playerIsNear = false;
            buttonTag = null; // Clear the stored tag
            Debug.Log("Player left the button area.");
        }
    }

    void Update()
    {
        // Check if player is near and presses the E key
        if (playerIsNear && Input.GetKeyDown(KeyCode.E))
        {
            if (buttonTag == "button 1")
            {
                Debug.Log("Button 1 Pressed! Loading Level 1...");
                SceneManager.LoadScene("Level1"); // Load Level 1
            }
            else if (buttonTag == "button 2")
            {
                Debug.Log("Button 2 Pressed! Loading Level 2...");
                SceneManager.LoadScene("level2"); // Load Level 2
            }
            else
            {
                Debug.Log("Unknown button tag detected.");
            }
        }
    }
}
