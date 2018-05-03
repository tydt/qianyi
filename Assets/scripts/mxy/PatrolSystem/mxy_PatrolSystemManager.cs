using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class mxy_PatrolSystemManager : MonoBehaviour
{
    [System.Serializable]
    public class Infomation
    {
        public string strName;
        public string strNum;
        public string strDepartment;
        public string strDuty;
        public string strTelephone;

        public Infomation(string strName, string strNum, string strDepartment, string strDuty, string strstrTelephone)
        {
            this.strName = strName;
            this.strNum = strNum;
            this.strDepartment = strDepartment;
            this.strDuty = strDuty;
            this.strTelephone = strstrTelephone;
        }
    }

	// Use this for initialization
	void Start () {
	    

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
