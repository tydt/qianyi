using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentController : MonoBehaviour
{
    public CanvasGroup Table;
    public CanvasGroup Button;
    public CanvasGroup DetailPanel;
    public List<GameObject> EquipmentGameObject;
    public Transform Target;
    public bl_CameraOrbit TheCamera;


    private bool isModelShowing = false;
    private string focusName = "";

    public void SetTableActive(bool isOn)
    {
        Table.alpha = isOn ? 1 : 0;
        Button.alpha = isOn ? 0 : 1;
        Table.gameObject.SetActive(isOn);
        isModelShowing = !isOn;
    }

    private void Update()
    {
        //if (!isModelShowing) return;
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit = new RaycastHit();
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        if (hit.transform.gameObject.name == focusName)
        //        {
        //            DetailPanel.gameObject.SetActive(true);
        //            Button.gameObject.SetActive(false);
        //        }
        //    }
        //}
    }

    //public void FocusGameObjectName(string name)
    //{
    //    focusName = name;
    //    GetComponentInChildren<EnergyFloatMainController>().IsolateOne(name);
    //    //GetComponentInChildren<EquipmentDropdownController>().FocusOneEquipment(name);
    //}

    public void PropertyPanelClose()
    {
        DetailPanel.gameObject.SetActive(false);
        Button.gameObject.SetActive(true);
    }

    //public void IsolateOne(string name)
    //{
        //print(312);
        //EquipmentDropdownController ed = GetComponentInChildren<EquipmentDropdownController>();
        //if (ed == null)
        //{
        //    Debug.LogWarning("error : EquipmentDropdownController ed is null");
        //    return;
        //}
        //focusName = name;
        //ed.FocusOneEquipment(name);
    //}

    public void ModelSelectedOnClickAsButton(string modelName)
    {
        if (!isModelShowing) return;
        if (modelName == focusName)
        {
            DetailPanel.gameObject.SetActive(true);
            Button.gameObject.SetActive(false);
        }
    }

    public void FocusGameObjectName(string name)
    {
        focusName = name;
        GetComponentInChildren<EquipmentFloatMainController>().IsolateOne(name);

        List<string> EquipmentNames = new List<string>();
        foreach(GameObject ego in EquipmentGameObject)
        {
            EquipmentNames.Add(ego.name);
        }
        int index = EquipmentNames.IndexOf(name);
        if (index == -1)
        {
            return;
        }
        Vector3 pos = EquipmentGameObject[index].transform.position;
        for (int i = 0; i < EquipmentGameObject.Count; i++)
        {
            if (i == index)
            {
                EquipmentGameObject[i].GetComponent<MaterialHelper>().SetTargetActive(true);
            }
            else
            {
                EquipmentGameObject[i].GetComponent<MaterialHelper>().SetTargetActive(false);
            }
        }
        iTween.MoveTo(Target.gameObject, pos, 1f);
        TheCamera.SetZoom(1f);

        
        //SendMessageUpwards("FocusGameObjectName", name);
    }

    private void RegistGameObjectClickEvent()
    {
        foreach (GameObject ego in EquipmentGameObject)
        {
            EventTriggerListenerCZ.GetListener(ego).onMouseUpAsButton += delegate
            {
                SendMessageUpwards("ModelSelectedOnClickAsButton", ego.name);
            };
        }
    }
}
