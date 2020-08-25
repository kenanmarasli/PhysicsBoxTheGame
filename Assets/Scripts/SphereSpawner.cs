using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    GameObject[] spheres;

    [SerializeField]
    private int sphereCount = 1000;
    private Vector3[] initialLocations;
    [SerializeField]
    private float spawnRadius = 1.0f;

    private int activeSphereCount;

    public GameObject prefab;

    public int ActiveSphereCount
    {
        get
        {
            return activeSphereCount;
        }
        set
        {
            SetActiveSphereCount(value);
        }
    }

    public int SphereCount
    {
        get
        {
            return sphereCount;
        }
    }

    public void SetActiveCountFromSlider(float value)
    {
        ActiveSphereCount = (int)(value * sphereCount);
    }

    private void Awake()
    {
        if (prefab != null)
        {
            spheres = new GameObject[sphereCount];
            initialLocations = new Vector3[sphereCount];
            for (int i = 0; i < sphereCount; ++i)
            {
                GameObject currentSphere = Instantiate(prefab, transform.position + Random.insideUnitSphere * spawnRadius, transform.rotation);
                spheres[i] = currentSphere;
                currentSphere.transform.SetParent(this.transform);
                initialLocations[i] = currentSphere.transform.position;
                currentSphere.SetActive(false);
            }
            activeSphereCount = 0;
        }
    }

    private int SetActiveSphereCount(int desiredActiveSphereCount)
    {
        if (desiredActiveSphereCount < 0)
        {
            desiredActiveSphereCount = 0;
        }
        else if (desiredActiveSphereCount > sphereCount)
        {
            desiredActiveSphereCount = sphereCount;
        }

        // Activate some
        if (activeSphereCount < desiredActiveSphereCount)
        {
            for (int i = activeSphereCount; i < desiredActiveSphereCount; ++i)
            {
                GameObject currentSphere = spheres[i];
                currentSphere.SetActive(true);
                currentSphere.transform.position = initialLocations[i];
                Rigidbody rb = currentSphere.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = Vector3.zero;
                }
            }
            activeSphereCount = desiredActiveSphereCount;
        }
        // Deactivate
        else
        {
            for (int i = desiredActiveSphereCount; i < activeSphereCount; ++i)
            {
                spheres[i].SetActive(false);
            }
            activeSphereCount = desiredActiveSphereCount;
        }

        return activeSphereCount;
    }
}
