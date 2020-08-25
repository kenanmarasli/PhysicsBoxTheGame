using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : ClickablePhysicsObject
{
    [SerializeField]
    private float forceMagnitude = 1000.0f;

    [SerializeField]
    Color[] colors = null;

    protected override void Awake()
    {
        base.Awake();
        MeshRenderer rendererComp = GetComponent<MeshRenderer>();
        int colorCount = colors.Length;
        for (int i = 0; i < colorCount; ++i)
        {
            int colorId = Mathf.FloorToInt(Random.value * colorCount);
            // Slim chance to get 1.0f but it is possible. Handle that case.
            if (colorId >= colorCount)
            {
                colorId = colorCount - 1;
            }
            rendererComp.material.color = colors[colorId];
        }
    }

    public override void Click(ClickEvent cEvent)
    {
        base.Click(cEvent);
        Vector3 force = cEvent.direction * forceMagnitude;
        rigidbodyComp.AddForceAtPosition(force, cEvent.position);
    }
}
