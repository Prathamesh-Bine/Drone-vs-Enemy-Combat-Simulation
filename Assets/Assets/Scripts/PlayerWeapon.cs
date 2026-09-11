using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWepon : MonoBehaviour
{
    [Header("Missile Settings")]
    [SerializeField] GameObject missilePrefab;
    [SerializeField] Transform firePoint; 
    [SerializeField] float fireRate = 1.5f; // Seconds between shots

    [Header("Aiming Settings")]
    [SerializeField] RectTransform Crosshair;
    [SerializeField] float TargetDistance = 100f;
    
    private Vector3 currentAimPosition; 
    private float nextFireTime = 0f; // Tracks when the next shot is allowed

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        MoveCrosshair();
        MoveTargetPoint();
        AimFirePoint();
    }

    public void OnFire(InputValue value)
    {
        // Check if button is pressed AND enough time has passed
        if (value.isPressed && Time.time >= nextFireTime)
        {
            // Calculate the exact time the player is allowed to shoot next
            nextFireTime = Time.time + fireRate;
            FireMissile();
        }
    } 

    private void FireMissile()
    {
        if (missilePrefab != null && firePoint != null)
        {
            Instantiate(missilePrefab, firePoint.position, firePoint.rotation);
        }
    }

    void MoveCrosshair()
    {
        if (Mouse.current != null)
        {
            Crosshair.position = Mouse.current.position.ReadValue();
        }
    }

    void MoveTargetPoint()
    {
        if (Mouse.current != null)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            
            if (Physics.Raycast(ray, out RaycastHit hit, TargetDistance))
            {
                currentAimPosition = hit.point;
            }
            else
            {
                currentAimPosition = ray.GetPoint(TargetDistance);
            }
        }
    }

    void AimFirePoint()
    {
        if (firePoint != null)
        {
            Vector3 fireDirection = currentAimPosition - firePoint.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            firePoint.rotation = rotationToTarget;
        }
    }
}