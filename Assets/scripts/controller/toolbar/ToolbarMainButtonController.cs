using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolbarMainButtonController : MonoBehaviour {

    public GameObject Normal;
    public GameObject Highlight;
    public GameObject SecondButtons;
    public ToolbarSecondButtonController SecondButtonsController;

    public void SetHighlight(bool isH)
    {
        Normal.GetComponent<CanvasGroup>().alpha = isH ? 0 : 1;
        Highlight.GetComponent<CanvasGroup>().alpha = isH ? 1 : 0;
        SecondButtons.GetComponent<CanvasGroup>().alpha = isH ? 1 : 0;
        if (isH)
        {
            SecondButtons.GetComponent<ToolbarSecondButtonController>().RegistButton();
        }
        //SecondButtons.GetComponent<CanvasGroup>().interactable = isH;

        //SecondButtons.SetActive(isH);
    }


}
