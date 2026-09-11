using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] float turnSpeed = 90f; // Speed for rotating left/right
    
    // Store input values
    Vector2 movement;
    float altitude;
    float turnInput; // New input for yaw rotation
    
    float currentYaw; // Tracks the drone's current facing direction

    void Start()
    {
        // Set the initial yaw to match the drone's starting rotation in the scene
        currentYaw = transform.eulerAngles.y;
    }

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    // Triggered by the "Move" action (WASD)
    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    // Triggered by the "Altitude" action (Q/E)
    public void OnAltitude(InputValue value)
    {
        altitude = value.Get<float>();
    }

    // Triggered by the new "Turn" action
    public void OnTurn(InputValue value)
    {
        turnInput = value.Get<float>();
    }

    // Triggered by the "Fire" action (Spacebar)
    public void OnFire(InputValue value)
    {
        Debug.Log("Missile Fired! Add instantiation logic here.");
    }

    private void ProcessTranslation()
    {
        Vector3 moveDirection = new Vector3(movement.x, altitude, movement.y);
        
        // The movement direction automatically respects the new yaw rotation
        Vector3 flatWorldMovement = Quaternion.Euler(0, transform.eulerAngles.y, 0) * moveDirection;
        
        transform.Translate(flatWorldMovement * controlSpeed * Time.deltaTime, Space.World);
    }

    private void ProcessRotation()
    {
        // 1. Calculate the new yaw based on the turn input
        currentYaw += turnInput * turnSpeed * Time.deltaTime;

        // 2. Calculate the tilt (pitch and roll)
        float pitch = movement.y * 10f; 
        float roll = -movement.x * 10f; 
        
        // 3. Apply pitch, the updated yaw, and roll
        Quaternion targetRotation = Quaternion.Euler(pitch, currentYaw, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}