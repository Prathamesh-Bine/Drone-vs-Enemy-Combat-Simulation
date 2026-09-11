using UnityEngine;

public class DroneRotors : MonoBehaviour
{
    [SerializeField] private Transform[] blades;
    [SerializeField] private float spinSpeed = 2000f;

    void Update()
    {
        
        foreach (Transform blade in blades)
        {
            if (blade != null)
            {
                blade.Rotate(Vector3.up * spinSpeed * Time.deltaTime, Space.Self);
            }
        }
    }
}