using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentFloatMainController : MonoBehaviour {

    private void Start()
    {
        //RegistButtonIsolate();
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0 || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            IsIsolateMode = false;
        }
       
    }

    void RegistButtonIsolate()
    {
        //foreach (EnergyFloatStatusSwitchController flo in Floats)
        //{
        //    EventTriggerListener.GetListener(flo.NormalPanel.gameObject).onPointerClick += new EventTriggerListener.PointerEventDelegate((ego, data) =>
        //    {
        //        IsolateOne(ego.name);
        //        SendMessageUpwards("IsolateOne", ego.name);
        //        print("RegistButtonIsolate");
        //    });
        //}
    }

    public void IsolateOne(string floatName)
    {
        foreach(EnergyFloatStatusSwitchController f in Floats)
        {
            f.SetFloatHighlightActive(floatName == f.gameObject.name, true);
            //f.gameObject.SetActive(floatName == f.gameObject.name);
            f.GetComponent<CanvasGroup>().alpha = floatName == f.gameObject.name ? 1 : 0;
        }
        isIsolateMode = true;
    }

    public void ExitIsolateMade()
    {
        foreach (EnergyFloatStatusSwitchController f in Floats)
        {
            f.GetComponent<CanvasGroup>().alpha = 1;
        }
    }

	private EnergyFloatStatusSwitchController[] Floats
    {
        get
        {
            return GetComponentsInChildren<EnergyFloatStatusSwitchController>();
        }
    }

    public bool IsIsolateMode
    {
        get
        {
            return isIsolateMode;
        }

        set
        {   
            if(isIsolateMode == value)
            {
                return;
            }
            isIsolateMode = value;
            if (!isIsolateMode)
            {
                ExitIsolateMade();
            }
        }
    }    

    private bool isIsolateMode = false;


}
