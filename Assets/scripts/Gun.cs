using UnityEngine;
using System.Collections;


public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // The bullet prefab to instantiate
    [SerializeField] private Transform firePoint;     // The point where the bullet spawns
    [SerializeField] private float bulletSpeed = 1000f; // Force applied to the bullet for realistic movement
    [SerializeField] private float bulletLifetime = 2f; // Time before the bullet is destroyed
    [SerializeField] private Light muzzleFlashLight; // Light component for the muzzle flash
    [SerializeField] private float flashDuration = 0.05f; // Duration the flash is visible
    [SerializeField] private ParticleSystem muzzleFlashEffect; // Particle system for the muzzle flash effect

    void Update()
    {
        // Detect when the player presses the left mouse button (Fire1)
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log("Shoot!"); // Log shooting action for debugging

        // Trigger muzzle flash light and particle effect
        StartCoroutine(TriggerMuzzleFlash());
        muzzleFlashEffect.Play();

        // Instantiate the bullet prefab at the fire point's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Apply force to the bullet's Rigidbody
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * bulletSpeed); // Add force in the forward direction
        }

        // Destroy the bullet after a set time to avoid clutter in the scene
        Destroy(bullet, bulletLifetime);
    }

    IEnumerator TriggerMuzzleFlash()
    {
        muzzleFlashLight.enabled = true;  // Turn on the muzzle flash light
        yield return new WaitForSeconds(flashDuration);  // Wait for the flash duration
        muzzleFlashLight.enabled = false;  // Turn off the muzzle flash light
    }
}
