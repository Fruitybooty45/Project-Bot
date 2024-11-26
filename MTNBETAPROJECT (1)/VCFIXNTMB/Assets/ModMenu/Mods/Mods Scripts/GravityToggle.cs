using UnityEngine;

public class GravityToggle : MonoBehaviour
{
    public Rigidbody targetRigidbody; // Add this line

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetRigidbody.useGravity = false;
            Debug.Log("Player entered the trigger, gravity turned off");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetRigidbody.useGravity = false;
            Debug.Log("Player is still in the trigger, gravity is still off");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetRigidbody.useGravity = true;
            Debug.Log("Player left the trigger, gravity turned back on");
        }
    }
}
