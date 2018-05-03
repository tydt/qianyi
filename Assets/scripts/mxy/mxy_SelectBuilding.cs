using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mxy_SelectBuilding : MonoBehaviour
{
    public bl_CameraOrbit trCameraOrbit;
    public Transform trTarget;
    public Transform trMoveTarget;
    public GameObject goNormal;
    public GameObject goHide;
    public GameObject goLeftInfo;
    public GameObject goFloorPanel;
    public Image imgCover;
    public Vector2 vecRotate;
    public Vector3 vecFade = new Vector3(0,0,-20);
    public float fDistance = 113.908f;
    private AllBuildingLocationLeftUIButtonController btnItem;

    public Text textShowName;

    public static mxy_SelectBuilding goCurrentNormalBuilding;


    private void OnEnable()
    {

    }

    // Use this for initialization
    void Start()
    {
        Init();
    }

    void Init()
    {
        btnItem = GetComponent<AllBuildingLocationLeftUIButtonController>();
        EventTriggerListener.GetListener(gameObject).onPointerClick += delegate (GameObject go, PointerEventData data)
        {
            StartCoroutine(SetCamera());
        };
        if (name != "儿科综合楼")
        {
            OnDisSelect();
        }
        else
        {
            goCurrentNormalBuilding = this;
            OnSelect();
        }
    }

    IEnumerator SetCamera()
    {
        if (goCurrentNormalBuilding != null)
        {
            goCurrentNormalBuilding.OnDisSelect();
        }
        goCurrentNormalBuilding = this;
        goCurrentNormalBuilding.OnSelect();

        if (imgCover != null)
        {
            imgCover.gameObject.SetActive(true);
            imgCover.color = Color.black;
            float fAlpha = 1;

            trMoveTarget.position = trTarget.position + vecFade;
            trCameraOrbit.ResetRotation(vecRotate.x,vecRotate.y);
            trCameraOrbit.SetDistance(fDistance);
            while (imgCover.color.a > 0)
            {
                fAlpha -= Time.deltaTime;
                imgCover.color = new Color(0, 0, 0, fAlpha);
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }
        iTween.MoveTo(trMoveTarget.gameObject, trTarget.position, 0.5f);
        yield return new WaitForSeconds(0.5f);
        imgCover.gameObject.SetActive(false);
    }

    public void OnDisSelect()
    {
        if (goNormal != null) goNormal.SetActive(false);
        if (btnItem != null) btnItem.SetHighlight(false);
        if (SceneManager.GetActiveScene().name  == "AllBuilding")
        {
            if (goHide != null) goHide.SetActive(true);
        }
        else
        {
            if (goHide != null) goHide.SetActive(false);
        }
        if (goLeftInfo != null) goLeftInfo.SetActive(false);
        if (goFloorPanel != null) goFloorPanel.SetActive(false);
        
    }

    public void OnSelect()
    {
        if (goNormal != null) goNormal.SetActive(true);
        if (btnItem != null) btnItem.SetHighlight(true);
        if (goHide != null) goHide.SetActive(false);
        if (goLeftInfo != null) goLeftInfo.SetActive(true);
        if (goFloorPanel != null) goFloorPanel.SetActive(true);
        if (textShowName != null) textShowName.text = name;
    }


}
