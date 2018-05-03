using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ToolbarMainController : MonoBehaviour
{
    void Start()
    {
        foreach (ToolbarMainButtonController mainButton in mainButtons)
        {
            EventTriggerListener.GetListener(mainButton.gameObject).onSelect += FirstSelectHandler;
            EventTriggerListener.GetListener(mainButton.gameObject).onDeselect += FirstDisSelectHandler;
        }

        //foreach (Button btn in secondButtons)
        //{
        //    btn.onClick.AddListener(delegate () { SecondClickHandler(btn.GetComponentInChildren<Text>().text); });
        //}
    }

    

    void FirstSelectHandler(GameObject go, BaseEventData data)
    {
        go.GetComponent<ToolbarMainButtonController>().SetHighlight(true);
    }

    void FirstDisSelectHandler(GameObject go, BaseEventData data)
    {
        go.GetComponent<ToolbarMainButtonController>().SetHighlight(false);
    }

    public void SecondClickHandler(string name)
    {
        if (name == "院区总览")
        {
            GetComponent<SceneLoadHelper>().LoadScene("AllBuilding");
        }
        else if (name == "单体建筑")
        {
            GetComponent<SceneLoadHelper>().LoadScene("OneBuilding");
        }
        else if (name == "设备台账")
        {
            GetComponent<SceneLoadHelper>().LoadScene("Equipment");
        }
        else if (name == "统计分析")
        {
            GetComponent<SceneLoadHelper>().LoadScene("Forms");
        }
        else if (name == "单层巡视")
        {
            GetComponent<SceneLoadHelper>().LoadScene("EnergyAllBuilding");
        }
        else if (name == "整体查看")
        {
            GetComponent<SceneLoadHelper>().LoadScene("EnergyAllBuilding");
        }
        else if (name == mxy_ProjectConst.Login)
        {
            GetComponent<SceneLoadHelper>().LoadScene("AllBuilding");
        }
        else if (name == mxy_ProjectConst.Record)
        {
            GetComponent<SceneLoadHelper>().LoadScene(mxy_ProjectConst.RecordScene);
        }
        else if (name == mxy_ProjectConst.MaintenanceManagement)
        {
            GetComponent<SceneLoadHelper>().LoadScene(mxy_ProjectConst.MaintenanceManagementScene);
        }
        else if (name == mxy_ProjectConst.PatrolSystem)
        {
            GetComponent<SceneLoadHelper>().LoadScene(mxy_ProjectConst.PatrolSystemScene);
        }
    }


    ToolbarMainButtonController[] mainButtons
    {
        get
        {
            return GetComponentsInChildren<ToolbarMainButtonController>();
        }
    }

    ToolbarSecondButtonController[] secondButtonControllers
    {
        get
        {
            return GetComponentsInChildren<ToolbarSecondButtonController>();
        }
    }

    List<Button> secondButtons
    {
        get
        {
            List<Button> btns = new List<Button>();
            foreach (ToolbarSecondButtonController sbc in secondButtonControllers)
            {
                Button[] btnss = sbc.GetComponentsInChildren<Button>();
                foreach (Button btn in btnss)
                {
                    btns.Add(btn);
                }
            }
            //Debug.Log(btns.Count);
            return btns;
        }
    }

}
