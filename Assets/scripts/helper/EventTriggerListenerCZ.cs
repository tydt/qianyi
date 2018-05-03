using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerListenerCZ : MonoBehaviour {

    public static EventTriggerListenerCZ GetListener(GameObject go)
    {
        EventTriggerListenerCZ listener = go.GetComponent<EventTriggerListenerCZ>();
        if (listener == null) listener = go.AddComponent<EventTriggerListenerCZ>();
        return listener;
    }

    #region cz
    public delegate void VoidEventDelegate();
    public event VoidEventDelegate onMouseUpAsButton;

    public void OnMouseUpAsButton()
    {
        if (onMouseUpAsButton != null) onMouseUpAsButton();
    }
    #endregion
}
