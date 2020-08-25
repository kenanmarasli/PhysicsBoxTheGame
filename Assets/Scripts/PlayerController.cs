using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera activeCamera;

    [SerializeField]
    private float rayLength = 100.0f;
    private void Awake()
    {
        // Camera is not assigned. Get main camera.
        if (activeCamera == null)
        {
            activeCamera = Camera.main;
            Debug.Assert(activeCamera != null);
        }
    }
    void Update()
    {
        // Primary mouse button clicked
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = activeCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, rayLength))
            {
                ClickableObject hitClickableObjComp = hit.collider.gameObject.GetComponent<ClickableObject>();
                if (hitClickableObjComp != null)
                {
                    ClickEvent cEvent = new ClickEvent(hit.point, ray.direction);
                    hitClickableObjComp.Click(cEvent);
                }
            }
        }
    }
}
