using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatFrameItemController : MonoBehaviour
{

    public Transform target;

    private void Update()
    {
        UILocate();
    }

    private Vector2 UILocate()
    {
        if (target == null) return new Vector2();
        //Vector2 uiPos = RectTransformUtility.WorldToScreenPoint(TargetCamera, target.position);        
        Vector3 pos = TargetCamera.WorldToScreenPoint(target.position);
        if (pos.z < 0)
        {
            return new Vector2();
        }
        Vector2 uiPos = new Vector2(pos.x, pos.y);
        InforUI.position = uiPos;
        return uiPos;
    }

    public Camera TargetCamera
    {
        get
        {
            return Camera.main;
        }
    }

    private RectTransform InforUI
    {
        get
        {
            return gameObject.GetComponent<RectTransform>();
        }
    }
}
