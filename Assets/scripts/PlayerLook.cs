using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;

    private float xRotation = 0f;
    public float xSensitivity = 10f;  // Lower base sensitivity
    public float ySensitivity = 10f;  // Lower base sensitivity

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x * xSensitivity * 0.02f;  // Apply a low scaling factor to the input
        float mouseY = input.y * ySensitivity * 0.02f;  // Apply a low scaling factor to the input

        // Calculate camera rotation for looking up and down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Restrict rotation to prevent flipping

        // Apply rotation to camera transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate player to look left and right
        transform.Rotate(Vector3.up * mouseX);
    }
}

