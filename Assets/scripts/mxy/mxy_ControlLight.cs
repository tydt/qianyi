using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class mxy_ControlLight : MonoBehaviour
{
    public MeshRenderer MeshRenderer;
    public static MeshRenderer MyMeshRenderer;

    private Toggle myToggle;

    public Text textLightCount;

    // Use this for initialization
	void Start ()
	{
	    MeshRenderer = GameObject.Find(GetComponentInChildren<Text>().text).GetComponentInChildren<MeshRenderer>();
	    myToggle = GetComponent<Toggle>();

        myToggle.onValueChanged.AddListener(OnValueChange);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnValueChange(bool bIsOn)
    {
        MeshRenderer.enabled = bIsOn;
    }
}
