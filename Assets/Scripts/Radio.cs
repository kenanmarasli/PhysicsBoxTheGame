using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Radio : ClickableObject
{
    protected AudioSource audioSourceComp;
    protected bool isOn = false;

    Animator animatorComp;

    const string danceParam = "dance";

    private void Awake()
    {
        audioSourceComp = GetComponent<AudioSource>();
        animatorComp = GetComponent<Animator>();
    }

    public override void Click(ClickEvent cEvent)
    {
        base.Click(cEvent);
        Toggle();
    }

    private bool Toggle()
    {
        isOn = !isOn;
        if (isOn)
        {
            audioSourceComp.Play();
            if (animatorComp != null)
            {
                animatorComp.SetBool(danceParam, true);
            }
        }
        else
        {
            audioSourceComp.Pause();
            animatorComp.SetBool(danceParam, false);
        }
        return isOn;
    }
}
