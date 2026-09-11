using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    [SerializeField] int hitPoints = 3;

    // We add a timer to prevent multiple hits in the same frame
    private float lastHitTime = 0f;
    private float hitCooldown = 0.1f; // 0.1 seconds of invincibility

    private void OnParticleCollision(GameObject other) 
    {
        processHit();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("PlayerMissile"))
        {
            processHit();
            Destroy(other.gameObject); 
        }
    }

    void processHit()
    {
        if (Time.time > lastHitTime + hitCooldown)
        {
            hitPoints--;
            lastHitTime = Time.time; 
            
            if (hitPoints <= 0)
            {
                if (destroyedVFX != null)
                {
                    Instantiate(destroyedVFX, transform.position, Quaternion.identity);
                }
                
                // Add 10 points right before the enemy is destroyed
                ScoreManager.instance.AddPoints(10);
                
                Destroy(gameObject);
            }
        }
    }
}