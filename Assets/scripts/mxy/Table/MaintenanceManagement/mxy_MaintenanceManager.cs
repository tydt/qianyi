using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class mxy_MaintenanceManager : MonoBehaviour
{

    public GameObject goBtnList;
    public GameObject goBtnPlan;

    public GameObject goDropDown_1;
    public GameObject goDropDown_2;

    public GameObject goTable_1;
    public GameObject goTable_2;


    // Use this for initialization
    void Start ()
    {
        Init();
    }

    void Init()
    {
        EventTriggerListener.GetListener(goBtnList).onPointerClick += delegate (GameObject go, PointerEventData data)
        {
            goBtnList.GetComponentInChildren<Image>().color = new Color32(16, 142, 154, 255);
            goBtnPlan.GetComponentInChildren<Image>().color = new Color32(12, 104, 113, 255);

            goDropDown_1.SetActive(true);
            goDropDown_2.SetActive(false);

            goTable_1.SetActive(true);
            goTable_2.SetActive(false);
        };

        EventTriggerListener.GetListener(goBtnPlan).onPointerClick += delegate (GameObject go, PointerEventData data)
        {
            goBtnList.GetComponentInChildren<Image>().color = new Color32(12, 104, 113, 255);
            goBtnPlan.GetComponentInChildren<Image>().color = new Color32(16, 142, 154, 255);

            goDropDown_1.SetActive(false);
            goDropDown_2.SetActive(true);

            goTable_1.SetActive(false);
            goTable_2.SetActive(true);
        };

        goBtnList.GetComponentInChildren<Image>().color = new Color32(16, 142, 154, 255);
        goBtnPlan.GetComponentInChildren<Image>().color = new Color32(12, 104, 113, 255);

        goDropDown_1.SetActive(true);
        goDropDown_2.SetActive(false);

        goTable_1.SetActive(true);
        goTable_2.SetActive(false);

    }
}
