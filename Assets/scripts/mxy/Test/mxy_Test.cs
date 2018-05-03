using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using PinYin;
using SLS.Widgets.Table;
using UnityEngine;

public class mxy_Test : MonoBehaviour {

    System.Random random = new System.Random(1000);
	// Use this for initialization
	void Start () {
	    List<mxy_RecordDataTableData.RecordDataParameter> plist = new List<mxy_RecordDataTableData.RecordDataParameter>();

	    plist = mxy_RecordDataTableData.Generate(random);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void SortList(List<string> list)
    {
        list.Sort((a, b) => mxy_PinYin.GetFirst(a).GetHashCode().CompareTo(mxy_PinYin.GetFirst(b).GetHashCode()));
    }

    void ForDebug(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Debug.Log(list[i]);
            //Debug.Log(mxy_PinYin.GetFirst(list[i]).GetHashCode());
        }
    }
}
