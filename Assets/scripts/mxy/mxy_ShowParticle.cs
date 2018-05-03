using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mxy_ShowParticle : MonoBehaviour
{

    public GameObject goParticle;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Show()
    {
        goParticle.SetActive(!goParticle.activeSelf);
    }
}
