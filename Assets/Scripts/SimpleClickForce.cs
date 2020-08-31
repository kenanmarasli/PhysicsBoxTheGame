using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleClickForce : ClickablePhysicsObject
{
    [SerializeField]
    private float forceMagnitude = 2000.0f;

    public override void Click(ClickEvent cEvent)
    {
        base.Click(cEvent);
        rigidbodyComp.AddForceAtPosition(cEvent.direction * forceMagnitude, cEvent.position);
    }
}
