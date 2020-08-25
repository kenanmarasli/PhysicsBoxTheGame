using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turbine : ClickableObject
{
    public Color activeColor = Color.green;
    public Color inactiveColor = Color.white;

    [SerializeField]
    private bool isOn = true;
    private Rotator[] rotators;
    private WindZone[] windZones;
    private ParticleSystem[] particleSystems;
    [SerializeField]
    private GameObject button = null;

    private Renderer buttonRenderer;

    void Awake()
    {
        rotators = GetComponentsInChildren<Rotator>();
        windZones = GetComponentsInChildren<WindZone>();
        particleSystems = GetComponentsInChildren<ParticleSystem>();
        if (button != null)
        {
            buttonRenderer = button.GetComponent<Renderer>();
        }
    }

    public override void Click(ClickEvent cEvent)
    {
        base.Click(cEvent);
        ToggleStatus();
    }

    private bool ToggleStatus()
    {
        isOn = !isOn;
        int rotatorCount = rotators.Length;
        for (int i = 0; i < rotatorCount; ++i)
        {
            rotators[i].Activate(isOn);
        }
        int windZoneCount = windZones.Length;
        for (int i = 0; i < windZoneCount; ++i)
        {
            windZones[i].Activate(isOn);
        }

        UpdateVFX();

        return isOn;
    }

    private void UpdateVFX()
    {
        if (buttonRenderer != null)
        {
            Color color = isOn ? activeColor : inactiveColor;
            buttonRenderer.material.SetColor("_Color", color);
        }
        int particleSystemCount = particleSystems.Length;
        for (int i = 0; i < particleSystemCount; ++i)
        {
            if (isOn)
            {
                particleSystems[i].Play();
            }
            else
            {
                particleSystems[i].Stop();
            }
        }
    }
}
