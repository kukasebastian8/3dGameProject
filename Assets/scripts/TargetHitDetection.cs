using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHitDetection : MonoBehaviour
{
   public GameObject hitEffect; // Assign a particle effect prefab in the Inspector (optional)

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) // Check if the colliding object has the tag "Bullet"
        {
            if (hitEffect != null)
            {
                // Instantiate hit effect at the target's position
                Instantiate(hitEffect, transform.position, Quaternion.identity);
            }

            // Destroy the target after being hit
            Destroy(gameObject);
        }
    }
}
