using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float lifetime = 2f; // Time before the bullet is destroyed

    void Start()
    {
        // Destroy the bullet after its lifetime
        Destroy(gameObject, lifetime);
    }
}
