using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Patrol : MonoBehaviour {

    


    public mxy_PatrolSystemManager.Infomation MyInfomation;

    public mxy_PatrolInfomation MyPatrolInfomation;

    public Transform trPathParent;

    public Color32 MyColor32;

    static Transform trMove;
    static Transform trShow;
    // Use this for initialization
    void Start () {
        Toggle _Toggle = GetComponent<Toggle>();
        _Toggle.onValueChanged.AddListener(delegate
        {
            OnSelect();
        });

        if (MyInfomation.strName == "王德福")
        {
            Invoke("OnStart", 3);
        }
    }


    void OnStart()
    {
        GetComponent<Toggle>().isOn = true;
    }
    void OnEnable()
    {
        
        
    }

	// Update is called once per frame
	void Update () {
		
	}


    void OnSelect()
    {
        MyPatrolInfomation.SetInfomation(MyInfomation);

        if (trMove != null)
        {
            Destroy(trMove.gameObject);
            Destroy(trShow.gameObject);
            DOTween.KillAll();
        }

        trShow = new GameObject("trShow").transform;
        trMove = GameObject.Instantiate(Resources.Load<GameObject>("prefab/trMove")).transform;

        trMove.position = trPathParent.GetChild(0).position;
        trShow.position = trPathParent.GetChild(0).position;

        trShow.gameObject.AddComponent<TrailRenderer>();
        trShow.GetComponent<TrailRenderer>().material = Resources.Load<Material>("material/trMove");
        trShow.GetComponent<TrailRenderer>().material.color = MyColor32;
        trShow.GetComponent<TrailRenderer>().material.SetColor("_EmissionColor", MyColor32);
        trShow.GetComponent<TrailRenderer>().time = Mathf.Infinity;
        trShow.GetComponent<TrailRenderer>().startWidth = 0.2f;
        trShow.GetComponent<TrailRenderer>().endWidth = 0.2f;

        trMove.gameObject.AddComponent<TrailRenderer>();
        trMove.GetComponent<TrailRenderer>().material = Resources.Load<Material>("material/trMove");
        trMove.GetComponent<TrailRenderer>().material.color = MyColor32;
        trMove.GetComponent<TrailRenderer>().material.SetColor("_EmissionColor", MyColor32);
        trMove.GetComponent<TrailRenderer>().time = Mathf.Infinity;
        trMove.GetComponent<TrailRenderer>().startWidth = 1f;
        trMove.GetComponent<TrailRenderer>().endWidth = 1f;

        Show(1);
        Move(1);
    }

    void Move(int iIndex)
    {
        trMove.DOMove(trPathParent.GetChild(iIndex).position, 1).OnComplete(delegate
        {
            if (iIndex <= trPathParent.childCount - 2)
            {
                iIndex++;
                Move(iIndex);
            }
            else
            {
                Destroy(trMove.GetComponent<TrailRenderer>());
                trMove.position = trPathParent.GetChild(0).position;
                trMove.DOScale(Vector3.one, 0.5f).OnComplete(delegate
                {

                    trMove.gameObject.AddComponent<TrailRenderer>();
                    trMove.GetComponent<TrailRenderer>().material = Resources.Load<Material>("material/trMove");
                    trMove.GetComponent<TrailRenderer>().material.color = MyColor32;
                    trMove.GetComponent<TrailRenderer>().material.SetColor("_EmissionColor", MyColor32);
                    trMove.GetComponent<TrailRenderer>().time = Mathf.Infinity;
                    trMove.GetComponent<TrailRenderer>().startWidth = 1f;
                    trMove.GetComponent<TrailRenderer>().endWidth = 1f;
                    Move(1);
                });
            }
        });
    }

    void Show(int iIndex)
    {
        trShow.DOMove(trPathParent.GetChild(iIndex).position, 0.01f).OnComplete(delegate
        {
            if (iIndex <= trPathParent.childCount - 2)
            {
                iIndex++;
                Show(iIndex);
            }
        });
    }
}
