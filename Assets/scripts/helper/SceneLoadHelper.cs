using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoadHelper : MonoBehaviour {

    public void LoadScene(string scencName)
    {
        GameObject coverPrefab = Resources.Load("prefab/ui/cover") as GameObject;
        GameObject cover = Instantiate(coverPrefab);
        cover.GetComponentInChildren<Animation>().Play("LoadSceneFadeIn");
        IEnumerator coroutine = LoacScencWithName(scencName);
        StartCoroutine(coroutine);
    }

    IEnumerator LoacScencWithName(string name)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(name);
    }

    private static volatile SceneLoadHelper instance;
    private static object syncRoot = new Object();
    public static SceneLoadHelper Instance
    {
        get
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        SceneLoadHelper[] instances = FindObjectsOfType<SceneLoadHelper>();
                        if (instances != null)
                        {
                            for (var i = 0; i < instances.Length; i++)
                            {
                                Destroy(instances[i].gameObject);
                            }
                        }
                        GameObject go = new GameObject("_SingletonBehaviour");
                        instance = go.AddComponent<SceneLoadHelper>();
                        DontDestroyOnLoad(go);
                    }
                }
            }
            return instance;
        }
    }
}
