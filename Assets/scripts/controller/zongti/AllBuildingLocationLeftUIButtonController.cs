using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllBuildingLocationLeftUIButtonController : MonoBehaviour {

    public Sprite Normal;
    public Sprite Highlight;

    public void SetHighlight(bool isH)
    {
        Sprite sp = isH ? Highlight : Normal;
        GetComponentInChildren<Image>().sprite = sp;
    }
}
