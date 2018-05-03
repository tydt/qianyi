using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class mxy_SelectArea : MonoBehaviour
{
    public GameObject goBtnShowAll;

    public GameObject goFloat;
    public GameObject goInfo;
    public GameObject[] goBtnArea;
    public BoxCollider[] bcRoom;

    // Use this for initialization
    void Start () {

        EventTriggerListener.GetListener(goBtnShowAll).onPointerClick += delegate(GameObject go, PointerEventData data)
        {
            for (int j = 0; j < bcRoom.Length; j++)
            {
                bcRoom[j].enabled = false;
            }
            goFloat.SetActive(true);
            goInfo.SetActive(false);
        };

        for (int i = 0; i < goBtnArea.Length; i++)
	    {
	        EventTriggerListener.GetListener(goBtnArea[i]).onPointerClick += delegate(GameObject go, PointerEventData data)
	        {
	            for (int j = 0; j < bcRoom.Length; j++)
	            {
	                bcRoom[j].enabled = true;
	            }
	            goFloat.SetActive(false);
	            goInfo.SetActive(false);
            };
	    }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
