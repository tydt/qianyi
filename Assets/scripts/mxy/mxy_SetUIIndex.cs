using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class mxy_SetUIIndex : MonoBehaviour
{

    public Transform tr;
	// Use this for initialization
	void Start ()
	{
	    tr = transform.parent.parent;

        EventTriggerListener.GetListener(gameObject).onPointerClick += delegate(GameObject go, PointerEventData data)
		{
		    tr.SetAsLastSibling();
		};
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
