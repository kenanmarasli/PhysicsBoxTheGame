using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class ClickablePhysicsObject : ClickableObject
{
    protected Collider collisionComp;
    protected Rigidbody rigidbodyComp;

    protected virtual void Awake()
    {
        collisionComp = GetComponent<Collider>();
        rigidbodyComp = GetComponent<Rigidbody>();
        Debug.Assert(collisionComp != null && rigidbodyComp != null);
    }

    public override void Click(ClickEvent cEvent)
    {
        base.Click(cEvent);
    }
}
