using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentModelDataGetterHelper : MonoBehaviour {


    public GameObject TargetPrefab;
    public Transform TargetParent;

    public class ModelData
    {
        public string name;
        public Transform ts;

        public ModelData(string name, Transform ts)
        {
            this.name = name;
            this.ts = ts;
        }
    }

	public List<ModelData> ModelDatas
    {
        get
        {
            List<ModelData> rs = new List<ModelData>();
            foreach (Transform ts in GetComponentsInChildren<Transform>())
            {
                if (ts.parent.name == gameObject.name)
                {
                    if(ts.name == "other")
                    {
                        continue;
                    }
                    foreach(Transform tsf in ts.GetComponentsInChildren<Transform>())
                    {                        
                        if(tsf.parent.name == ts.name)
                        {
                            rs.Add(new ModelData(ts.name, tsf));
                            break;
                        }
                    }
                }
            }
            return rs;
        }
    }

    public List<Transform> Targets
    {
        get
        {
            List<Transform> rs = new List<Transform>();
            foreach (Transform ts in TargetParent)
            {
                if (ts.parent.name == TargetParent.name)
                {
                    rs.Add(ts);
                }
            }
            return rs;
        }
    }

    //[ContextMenu("Build Targets")]
    public void BuildTargets()
    {
        foreach(ModelData d in ModelDatas)
        {
            GameObject go = Instantiate(TargetPrefab);
            go.name = d.name;
            go.transform.position = d.ts.position;
            go.transform.SetParent(TargetParent);
        }
    }

    public GameObject FloatPrefab;
    public Transform FloatParent;

    [ContextMenu("Build Floats")]
    public void BuildFloats()
    {
        foreach(ModelData d in ModelDatas)
        {
            GameObject go = Instantiate(FloatPrefab);
            go.name = d.name;
            go.transform.SetParent(FloatParent);
            foreach(Transform t in Targets)
            {
                if(t.name == go.name)
                {
                    go.GetComponent<FloatFrameItemController>().target = t;
                    
                }
            }
        }
    }


}
