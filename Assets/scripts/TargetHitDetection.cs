using UnityEngine;

public class TargetHitDetection : MonoBehaviour
{
    //public GameObject hitEffect; // Optional: Assign a particle effect prefab in the Inspector for visual effects on hit

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet")) // Ensure your bullet prefab has the tag "Bullet"
        {
            // Optional: instantiate a hit effect at the target's position
            // if (hitEffect != null)
            // {
            //     Instantiate(hitEffect, transform.position, Quaternion.identity);
            // }

            // Increment score by 100 using the GameManager instance
            GameManager.Instance.AddScore(100);

            // Destroy the target after being hit
            Destroy(gameObject);
        }
    }
}
