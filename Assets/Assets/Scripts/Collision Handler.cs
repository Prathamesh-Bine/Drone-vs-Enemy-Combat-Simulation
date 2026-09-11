using UnityEngine;

public class ColisionHandler : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    [SerializeField] int hitPoints = 3;

    GameSceneManager gameSceneManager;

    private void Start()
    {
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }

    // Handles enemy bullets if their colliders are set to "Is Trigger"
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            processHit();
            Destroy(other.gameObject); 
        }
    }

    // Handles enemy bullets if they are solid, AND handles crashing into solid walls
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            processHit();
            Destroy(other.gameObject); 
        }
        else 
        {
            // If the drone hits anything else solid (like a wall), it explodes instantly
            CrashInstantly();
        }
    }

    void processHit()
    {
        hitPoints--;
        
        if(hitPoints <= 0)
        {
            CrashInstantly();
        }
    }

    void CrashInstantly()
    {
        // Reset the score here if you used the static variable method earlier
        // EnemyHealth.totalScore = 0; 
        
        gameSceneManager.ReloadLevel();
        
        if (destroyedVFX != null)
        {
            Instantiate(destroyedVFX, transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }
}