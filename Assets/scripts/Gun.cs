using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // The bullet prefab to instantiate
    [SerializeField] private Transform firePoint;     // The point where the bullet spawns
    [SerializeField] private float bulletSpeed = 1000f; // Force applied to the bullet for realistic movement
    [SerializeField] private float bulletLifetime = 2f; // Time before the bullet is destroyed

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
}
