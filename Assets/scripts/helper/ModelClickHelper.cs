using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelClickHelper : MonoBehaviour
{

    public CanvasGroup DetailPanel;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.name == gameObject.name)
                {
                    DetailPanel.gameObject.SetActive(true);
                    print(2);
                }
                print(1);
                print(hit.transform.gameObject.name);
            }
            print(0);
        }
    }
}
