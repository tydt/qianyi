using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mxy_PatrolInfomation : MonoBehaviour
{

    public Text textName;
    public Text textNum;
    public Text textDepartment;
    public Text textDuty;
    public Text textTelephone;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetInfomation(mxy_PatrolSystemManager.Infomation myInfomation)
    {
        textName.text = myInfomation.strName;
        textNum.text = myInfomation.strNum;
        textDepartment.text = myInfomation.strDepartment;
        textDuty.text = myInfomation.strDuty;
        textTelephone.text = myInfomation.strTelephone;
    }
}
