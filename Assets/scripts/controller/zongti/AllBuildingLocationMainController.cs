using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBuildingLocationMainController : MonoBehaviour
{
    public List<GameObject> Normals;
    public List<GameObject> Hides;
    public List<GameObject> Targets;
    public List<GameObject> Panles;
    public List<GameObject> FloorPanles;
    public Transform Target;

    private Vector3 originPosition = new Vector3(121f, 61f, -280f);
    private int buildingCount = 6;
    public void SetActiveBuilding(string name)
    {
        int index = buildingNames.IndexOf(name);
        if (index == -1)
        {
            return;
        }
        for (int i = 0; i < buildingCount; i++)
        {
            Normals[i].SetActive(i == index);
            Hides[i].SetActive(i != index);
        }
        for (int i = 0; i < Panles.Count; i++)
        {
            Panles[i].SetActive(i == index);
        }
        for (int i = 0; i < FloorPanles.Count; i++)
        {
            FloorPanles[i].SetActive(i == index);
        }

        iTween.MoveTo(Target.gameObject, Targets[index].transform.position, 1f);
    }

    public void ResetPosition()
    {
        iTween.MoveTo(Target.gameObject, originPosition, 1f);
        for (int i = 0; i < buildingCount; i++)
        {
            Normals[i].SetActive(true);
            Hides[i].SetActive(false);
        }
    }

    private List<string> buildingNames = new List<string>() { "儿科综合楼", "急诊楼", "保健楼", "内科楼", "科研楼", "门诊楼" };
}
