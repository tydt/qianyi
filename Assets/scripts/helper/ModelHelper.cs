using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ModelHelper : MonoBehaviour {

	[ContextMenu("DisSelectShadow")]
    private void disSelectShadow()
    {
        MeshRenderer[] meshs = GetComponentsInChildren<MeshRenderer>();
        foreach(MeshRenderer mesh in meshs)
        {
            mesh.receiveShadows = false;
        }
    }
    [ContextMenu("SelectShadow")]
    private void SelectShadow()
    {
        MeshRenderer[] meshs = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mesh in meshs)
        {
            mesh.receiveShadows = true;
        }
    }
}
