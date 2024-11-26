using UnityEngine;

public class Moon : MonoBehaviour
{
    public float gravityRadius = 35f;
    public float gravityStrength = 9.81f;
    public Transform gorillaPlayer;

    private Quaternion originalRotation;

    private void Start()
    {
        originalRotation = gorillaPlayer.rotation;
    }

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(gorillaPlayer.position, transform.position);

        if (distance < gravityRadius)
        {
            Vector3 gravityUp = (gorillaPlayer.position - transform.position).normalized;
            Vector3 localUp = gorillaPlayer.up;

            gorillaPlayer.rotation = Quaternion.FromToRotation(localUp, gravityUp) * gorillaPlayer.rotation;

            Rigidbody gorillaRigidbody = gorillaPlayer.GetComponent<Rigidbody>();
            float distanceRatio = 1 - (distance / gravityRadius);
            float currentGravityStrength = gravityStrength * distanceRatio;
            gorillaRigidbody.AddForce(-gravityUp * currentGravityStrength, ForceMode.Acceleration);
        }
        else
        {
            gorillaPlayer.rotation = Quaternion.Lerp(gorillaPlayer.rotation, originalRotation, Time.deltaTime);
        }
    }
}