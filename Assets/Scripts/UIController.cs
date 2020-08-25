using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Text ballCountTextComp = null;
    [SerializeField]
    private SphereSpawner sphereSpawner = null;

    const string ballCountText = "Ball Count: ";

    public void SliderUpdated(float value)
    {
        if (ballCountTextComp != null && sphereSpawner != null)
        {
            sphereSpawner.SetActiveCountFromSlider(value);
            ballCountTextComp.text = ballCountText + sphereSpawner.ActiveSphereCount;
        }
    }
}
