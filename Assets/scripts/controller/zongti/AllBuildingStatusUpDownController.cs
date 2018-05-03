using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllBuildingStatusUpDownController : MonoBehaviour {

    public Sprite Normal;
    public Sprite Hightlight;

    public GameObject UpBuilding;
    public GameObject UpBuildingFade;

    private Vector3 upPosition = new Vector3(122f, 62f, -280f);
    private Vector3 downPosition = new Vector3(73f, 0f, -373f);

    public Transform Target;
    //public GameObject DownBuilding;

    private bool isNormal = true;

    public void UIOnclick()
    {
        isNormal = !isNormal;
        Sprite spr = isNormal ? Normal : Hightlight;
        GetComponentInChildren<Image>().sprite = spr;

        UpBuilding.SetActive(isNormal);
        UpBuildingFade.SetActive(!isNormal);

        Vector3 rs = isNormal ? upPosition : downPosition;
        iTween.MoveTo(Target.gameObject, rs, 1f);
    }
}