using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllBuildingStatusDayNightController : MonoBehaviour {

    public Sprite Normal;
    public Sprite Hightlight;
    public Skybox theSky;
    public Material Day;
    public Material Night;
    public Light theLight;
    float bright = 1f;
    float dark = 0.5f;

    private bool isNormal = true;

    public void UIOnclick()
    {
        isNormal = !isNormal;
        Sprite spr = isNormal ? Normal : Hightlight;
        GetComponentInChildren<Image>().sprite = spr;
        if (isNormal)
        {
            theLight.intensity = bright;
            theSky.material = Day;
        }
        else
        {
            theLight.intensity = dark;
            theSky.material = Night;
        }
    }
}
