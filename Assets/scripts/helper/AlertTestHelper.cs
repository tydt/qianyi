using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertTestHelper : MonoBehaviour {

    bool isAlertHappened = false;
    public GameObject LinkPanel;
    public Image AlertImg;
    public Sprite HighLight;

    private void Update()
    {
        AlertHappen();
    }

    void AlertHappen()
    {
        if (!Input.GetKeyDown(KeyCode.Space))
        {
            return;
        }
        if (isAlertHappened)
        {
            return;
        }

        isAlertHappened = true;        
        GetComponent<Animation>().Play("AlertAni");
        LinkPanel.SetActive(true);
        AlertImg.sprite = HighLight;
    }
}
