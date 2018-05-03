using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mxy_Editor : MonoBehaviour {

    [MenuItem("mxy/SetChildName")]
    static void SetChildName()
    {
        Transform tr = Selection.activeTransform;
        for (int i = 0; i < tr.childCount; i++)
        {
            tr.GetChild(i).name = (i + 1).ToString();
            tr.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
        }
    }

    [MenuItem("mxy/ChangeMat")]
    static void ChangeMat()
    {
        Transform tr = Selection.activeTransform;
        Change(tr);
    }

    static void Change(Transform tr)
    {
        for (int i = 0; i < tr.childCount; i++)
        {
            if (tr.GetChild(i).GetComponent<MeshRenderer>() != null)
            {
                tr.GetChild(i).GetComponent<MeshRenderer>().material = Resources.Load<Material>("mat1");
                Change(tr.GetChild(i));
            }
        }
    }

    [MenuItem("mxy/CreateLogo")]
    static void CreateLogo()
    {
        Transform tr = Selection.activeTransform;
        RectTransform rt = new GameObject("Logo").AddComponent<RectTransform>();
        rt.SetParent(tr);
        Image myImage = rt.gameObject.AddComponent<Image>();
        myImage.sprite = Resources.Load<Sprite>("img/logo-1");
        myImage.SetNativeSize();
        myImage.raycastTarget = false;

        rt.localScale = Vector3.one;
        rt.anchoredPosition = new Vector2(845, -500);
        rt.SetAsLastSibling();

        EditorUtility.SetDirty(tr);
        EditorSceneManager.SaveOpenScenes();
    }
}
