using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] float speed = 50f;
    [SerializeField] GameObject explosionEffect; 
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Propel the missile forward upon spawning
        rb.linearVelocity = transform.forward * speed;
        
        // Destroy the missile after 4 seconds if it hits nothing to prevent lag
        Destroy(gameObject, 4f);
    }

    void OnTriggerEnter(Collider other)
    {
        // Ignore the player so the drone doesn't blow itself up instantly
        if (other.CompareTag("Player")) return;

        // Spawn the explosion particle effect upon hitting anything
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }

        // Destroy ONLY the missile itself. The EnemyHealth script handles destroying the enemy.
        Destroy(gameObject);
    }
}