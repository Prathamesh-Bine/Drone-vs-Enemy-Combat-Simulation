using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("Patrol Settings")]
    [SerializeField] Transform[] waypoints;
    private NavMeshAgent agent;
    private int currentWaypointIndex = 0;

    [Header("Combat Settings")]
    [SerializeField] Transform player; 
    [SerializeField] float detectionRange = 25f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float fireRate = 1.5f;
    
    private float nextFireTime = 0f;

    [Header("Animation Settings")]
    [SerializeField] Animator animator; // Link to the soldier's animator

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            AttackPlayer();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        agent.isStopped = false; 

        // Tell the animator to play the walking animation
        if (animator != null) animator.SetBool("isWalking", true);

        if (waypoints.Length == 0) return;

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    void AttackPlayer()
    {
        agent.isStopped = true; 

        // Tell the animator to stop walking and return to idle
        if (animator != null) animator.SetBool("isWalking", false);

        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.y = 0; 
        
        if (directionToPlayer != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(directionToPlayer);
        }

        Vector3 fireDirection = player.position - firePoint.position;

        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot(fireDirection);
        }
    }

    void Shoot(Vector3 aimDirection)
    {
        // Trigger the shooting recoil animation
        if (animator != null) animator.SetTrigger("Shoot");

        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(aimDirection));
        }
    }
}