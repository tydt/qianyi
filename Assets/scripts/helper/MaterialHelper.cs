using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialHelper : MonoBehaviour {

    public Material m1; 
    public Material m2;

    [ContextMenu("m1")]
    private void ChangeMaterialToM1()
    {
        MeshRenderer[] meshs = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mesh in meshs)
        {
            mesh.material = m1;
            List<Material> ms = new List<Material>();
            foreach(Material m in mesh.materials)
            {
                ms.Add(m1);
            }
            mesh.materials = ms.ToArray();
        }
    }

    [ContextMenu("m2")]
    private void ChangeMaterialToM2()
    {
        MeshRenderer[] meshs = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mesh in meshs)
        {
            mesh.material = m2;
        }
    }

    public void SetTargetActive(bool isOn)
    {       
        if (isOn)
        {
            ChangeMaterialToM1();
        }
        else
        {
            ChangeMaterialToM2();
        }
    }	
}
