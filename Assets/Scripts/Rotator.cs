using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float rotationFrequency = 2.0f;
    private float rotationAngleSpeed = 720.0f;
    private float initialRotationFrequency;

    public float RotationFrequency
    {
        get
        {
            return rotationFrequency;
        }
        set
        {
            rotationFrequency = value;
            rotationAngleSpeed = rotationFrequency * 360.0f;
        }
    }

    private void Awake()
    {
        initialRotationFrequency = rotationFrequency;
    }

    public void Activate(bool active)
    {
        RotationFrequency = active ? initialRotationFrequency : 0.0f;
    }

    private void Update()
    {
        transform.Rotate(0.0f, rotationAngleSpeed * Time.deltaTime, 0.0f);
    }

    private void OnValidate()
    {
        RotationFrequency = rotationFrequency;
    }
}
