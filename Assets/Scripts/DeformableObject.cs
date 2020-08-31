using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider), typeof(MeshFilter))]
public class DeformableObject : ClickableObject
{
    [SerializeField]
    private float softness = 0.05f;
    [SerializeField]
    private float impactRadius = 0.1f;
    [SerializeField]
    private float springness = 0.5f;
    [SerializeField]
    private float touchImpactMagnitude = 25.0f;
    [SerializeField]
    private float maxVertexDispositionRadius = 0.2f;

    private MeshCollider meshColliderComp = null;
    private Mesh meshComp = null;
    private Vector3[] initialVertices = null;
    private Vector3[] vertices = null;

    private void Awake()
    {
        meshColliderComp = GetComponent<MeshCollider>();
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter != null)
        {
            meshComp = meshFilter.mesh;
        }
        Debug.Assert(meshColliderComp != null || meshComp != null);
        initialVertices = meshComp.vertices;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Use single contact point for now.
        Vector3 impactPoint = transform.InverseTransformPoint(collision.GetContact(0).point);
        Vector3 impactNormal = transform.InverseTransformDirection(collision.GetContact(0).normal);

        float impulseMagnitude = collision.impulse.magnitude;

        DeformMesh(impactPoint, impactNormal, impulseMagnitude);
    }

    private void FixedUpdate()
    {
        vertices = meshComp.vertices;
        int vertexCount = vertices.Length;
        for (int i = 0; i < vertexCount; ++i)
        {
            float alpha = Mathf.Clamp(springness * Time.fixedDeltaTime, 0.0f, 1.0f);
            vertices[i] = Vector3.Lerp(vertices[i], initialVertices[i], alpha);
        }

        meshComp.vertices = vertices;
        meshColliderComp.sharedMesh = meshComp;

        meshComp.RecalculateNormals();
        meshComp.RecalculateBounds();
    }

    public override void Click(ClickEvent cEvent)
    {
        base.Click(cEvent);
        Vector3 impactPoint = transform.InverseTransformPoint(cEvent.position);
        Vector3 impactNormal = transform.InverseTransformDirection(cEvent.direction);
        DeformMesh(impactPoint, impactNormal, touchImpactMagnitude);
    }

    private void DeformMesh(Vector3 impactPoint, Vector3 impactNormal, float impulseMagnitude)
    {
        vertices = meshComp.vertices;
        float scale = 1.0f;
        int vertexCount = vertices.Length;
        for (int i = 0; i < vertexCount; ++i)
        {
            scale = Mathf.Clamp(impactRadius - (impactPoint - vertices[i]).magnitude, 0.0f, impactRadius);
            scale = Mathf.Clamp(impulseMagnitude * scale * softness, 0.0f, maxVertexDispositionRadius);
            vertices[i] += impactNormal * scale;
        }

        meshComp.vertices = vertices;
        meshColliderComp.sharedMesh = meshComp;

        meshComp.RecalculateNormals();
        meshComp.RecalculateBounds();
    }

    private void OnApplicationQuit()
    {
        meshComp.vertices = initialVertices;
    }
}
