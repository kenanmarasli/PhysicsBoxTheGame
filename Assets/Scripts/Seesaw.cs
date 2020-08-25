using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seesaw : ClickablePhysicsObject
{

    [SerializeField]
    private float forceMagnitude = 1000.0f;

    public override void Click(ClickEvent cEvent)
    {
        base.Click(cEvent);
        rigidbodyComp.AddForceAtPosition(new Vector3(0.0f, -forceMagnitude, 0.0f), cEvent.position);
    }
}
