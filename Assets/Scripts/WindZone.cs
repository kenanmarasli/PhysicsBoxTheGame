using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZone : MonoBehaviour
{
    [SerializeField]
    private float Force = 30.0f;
    private float InitialForce;
    [SerializeField]
    private Vector3 ForceDirection = new Vector3(0.0f, 1.0f, 0.0f);

    private void Awake()
    {
        InitialForce = Force;
    }

    public void Activate(bool active)
    {
        Force = active ? InitialForce : 0.0f;
    }

    private void OnTriggerStay(Collider other)
    {
        other.attachedRigidbody.AddForce(ForceDirection * Force);
    }

    private void OnValidate()
    {
        ForceDirection.Normalize();
    }
}
