using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatCalculator : MonoBehaviour
{
    [SerializeField]
    private Text StatText = null;
    
    private int frameCount = 0;
    private float timeElapsed = 0;
    private int fpsToDisplay = 0;

    private void Awake()
    {
        // If not assigned, try to get the text component attached.
        if (StatText == null)
        {
            StatText = GetComponent<Text>();
        }
        Debug.Assert(StatText != null);
    }

    private void Update()
    {
        ++frameCount;
        timeElapsed += Time.deltaTime;
        // One second passed.
        if (timeElapsed >= 1.0f)
        {
            timeElapsed = 0.0f;
            fpsToDisplay = frameCount;
            frameCount = 0;
            UpdateStatText();
        }
    }

    private void UpdateStatText()
    {
        StatText.text = "FPS: " + fpsToDisplay;
    }

}
