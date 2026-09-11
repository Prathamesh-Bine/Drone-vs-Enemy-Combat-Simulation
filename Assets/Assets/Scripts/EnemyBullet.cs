using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] ParticleSystem bulletImpactVFX; // Optional: Visual effect when the bullet hits something
    [SerializeField] float speed = 40f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Pushes the bullet forward instantly when it spawns
        rb.linearVelocity = transform.forward * speed;
        
        // I Destroyed the bullet after 4 seconds so it doesn't fly forever and cause lag
        Destroy(gameObject, 4f); 
    }

    void OnTriggerEnter(Collider other)
    {
        // Ignores the enemy itself so the soldier doesn't shoot himself
        if (other.CompareTag("Enemy")) return;

        if (other.CompareTag("Player"))
        {
            Debug.Log("Drone was hit by the enemy!");
            // You can add logic to reduce the drone's health here later
        }

        // Destroy the bullet when it hits anything else (player, walls, ground)
        if (other.CompareTag("Player") && bulletImpactVFX != null)
        {
            Instantiate(bulletImpactVFX, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}