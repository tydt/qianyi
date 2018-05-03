using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class mxy_ShowLabal : MonoBehaviour
{
    public Transform trFollowUI;
    private Text textRoomName;              //显示房间的名称

    public GameObject goRoomInfo;

    private Text textRoomInfo;

    public static GameObject s_goCurrent;
    // Use this for initialization
    void Start ()
    {
        //默认获取第一个找到的Text
        textRoomName = trFollowUI.GetComponentInChildren<Text>();
        textRoomInfo = goRoomInfo.transform.Find("Panel/title/Text").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseExit()
    {
        //if (EventSystem.current.IsPointerOverGameObject()) return;
        trFollowUI.gameObject.SetActive(false);
        textRoomName.text = "";
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        trFollowUI.gameObject.SetActive(true);
        textRoomName.text = transform.parent.name;
    }

    private void OnMouseUpAsButton()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        goRoomInfo.SetActive(true);
        //todo:通过改变显示状态来高亮显示当前选中的房间
        
        textRoomInfo.text =
            transform.parent.parent.name + "-" + transform.parent.name;
    }

    private void OnMouseOver()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        trFollowUI.position = Input.mousePosition;
    }

}
