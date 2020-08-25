using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ClickEvent
{
    public Vector3 position;
    public Vector3 direction;

    public ClickEvent(Vector3 inPosition, Vector3 inDirection)
    {
        position = inPosition;
        direction = inDirection;
    }
}

public class ClickableObject : MonoBehaviour
{
    // Currently pass the value. If ClickEvent becomes too big, pass by ref.
    public virtual void Click(ClickEvent cEvent)
    {

    }
}