using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : ClickableObject
{
    Light[] directionalLights;
    Light[] spotLights;

    private bool isDefault = true;

    private void Awake()
    {
        Light[] allLights = GetComponentsInChildren<Light>();
        int lightCount = allLights.Length;
        int spotLightCount = 0;
        int directionalLightCount = 0;
        LightType[] lightType = new LightType[lightCount];
        for (int i = 0; i < lightCount; ++i)
        {
            switch (allLights[i].type)
            {
                case LightType.Directional:
                    ++directionalLightCount;
                    lightType[i] = LightType.Directional;
                    break;
                case LightType.Spot:
                    ++spotLightCount;
                    lightType[i] = LightType.Spot;
                    break;
                default:
                    lightType[i] = (LightType)(-1);
                    break;
            }
        }
        directionalLights = new Light[directionalLightCount];
        spotLights = new Light[spotLightCount];
        int directionalLightIndex = 0;
        int spotLightIndex = 0;
        for (int i = 0; i < lightCount; ++i)
        {
            switch (lightType[i])
            {
                case LightType.Spot:
                    spotLights[spotLightIndex] = allLights[i];
                    ++spotLightIndex;
                    break;
                case LightType.Directional:
                    directionalLights[directionalLightIndex] = allLights[i];
                    ++directionalLightIndex;
                    break;
                default:
                    break;
            }
        }
    }

    private bool ToggleStatus()
    {
        isDefault = !isDefault;
        UpdateLights();
        return isDefault;
    }

    private void UpdateLights()
    {
        int directionalLightCount = directionalLights.Length;
        int spotLightCount = spotLights.Length;
        if (isDefault)
        {
            for (int i = 0; i < directionalLightCount; ++i)
            {
                directionalLights[i].enabled = true;
            }
            for (int i = 0; i < spotLightCount; ++i)
            {
                spotLights[i].enabled = false;
            }
        }
        else
        {
            for (int i = 0; i < directionalLightCount; ++i)
            {
                directionalLights[i].enabled = false;
            }
            for (int i = 0; i < spotLightCount; ++i)
            {
                spotLights[i].enabled = true;
            }
        }
    }

    public override void Click(ClickEvent cEvent)
    {
        base.Click(cEvent);
        ToggleStatus();
    }
}
