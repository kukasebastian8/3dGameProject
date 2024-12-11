using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetHitDetection : MonoBehaviour
{
    //public GameObject hitEffect; // Assign a particle effect prefab in the Inspector (optional)

    /* void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.CompareTag("Bullet")) // Check if the colliding object has the tag "Bullet"
         {


             if (hitEffect != null)
             {
                 // Instantiate hit effect at the target's position
                 Instantiate(hitEffect, transform.position, Quaternion.identity);
             }


             //increment score by 100


             // Destroy the target after being hit
             Destroy(gameObject);
         }
     }*/

    private void OnTriggerEnter(Collider other)
     {
        

        if (other.CompareTag("Bullet"))
         {
            
             // Increment score by 100
             GameManager.Instance.AddScore(100);

            // Destroy the target 
            Destroy(gameObject);
             
        }
     }
    
    
}