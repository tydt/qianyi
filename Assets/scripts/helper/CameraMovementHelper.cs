using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovementHelper : MonoBehaviour {

    public Transform target;
    public float speed = 10f;
    Vector3 lastPoint = new Vector3();

	void Update () {
	   
	    //if (EventSystem.current.IsPointerOverGameObject()) return;
	    
        Test();
    }
    
    void Test()
    {
        if(Input.GetMouseButtonDown(1))
        {
            lastPoint = Input.mousePosition;
            return;
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 now = Input.mousePosition;
            Vector3 pos = TargetCamera.WorldToScreenPoint(target.position);
            Vector3 delta = new Vector3((lastPoint.x - now.x) * speed * 0.1f, (lastPoint.y - now.y) * speed * 0.1f, (lastPoint.z - now.z) * speed * 0.1f);
            Vector3 spos = new Vector3(pos.x + delta.x, pos.y + delta.y, pos.z + delta.z);
            Vector3 posNow = TargetCamera.ScreenToWorldPoint(spos);
            target.position = posNow;
            lastPoint = now;
        }
    }

    public Camera TargetCamera
    {
        get
        {
            return Camera.main;
        }
    }
}
