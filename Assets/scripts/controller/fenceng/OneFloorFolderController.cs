using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OneFloorFolderController : MonoBehaviour {

    public float ItemTitleHeight = 35f;
    private float titleSpace = 5f;

    private void Start()
    {
        BuildElement();
    }

    void BuildElement()
    {
        for(int i = 0; i < items.Length; i++)
        {
            OneFloorFolderItemController item = items[i];
            RectTransform rect = item.GetComponent<RectTransform>();
            rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, (ItemTitleHeight+titleSpace) * i, ItemTitleHeight);
            item.Index = i;
            EventTriggerListener.GetListener(item.TitleButton.gameObject).onPointerClick += ItemButtonClick;
        }
    }

    void ItemButtonClick(GameObject go, BaseEventData data)
    {
        OneFloorFolderItemController itemSelected = go.GetComponentInParent<OneFloorFolderItemController>();
        int index = itemSelected.Index;
        for(int i = 0; i < items.Length; i++)
        {
            OneFloorFolderItemController item = items[i];
            RectTransform rect = item.GetComponent<RectTransform>();
            float top = i > index ? (ItemTitleHeight + titleSpace) * i + itemSelected.contentHeight : (ItemTitleHeight + titleSpace) * i;
            float hight = i == index ? ItemTitleHeight + itemSelected.contentHeight : ItemTitleHeight;
            
            rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, top, hight);
            item.content.GetComponent<CanvasGroup>().alpha = i == index ? 1 : 0;
            if (SceneManager.GetActiveScene().name != "LightOneFloor")
            {
                item.SetThisSystemEnableWithFloat(i == index);
            }
        }
    }
    
    public void ShowAllModel(bool isOn)
    {
        foreach(OneFloorFolderItemController item in items)
        {
            item.SetThisSystemEnable(isOn);
        }
        for (int i = 0; i < items.Length; i++)
        {
            OneFloorFolderItemController item = items[i];
            RectTransform rect = item.GetComponent<RectTransform>();
            rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 40*i, 35);
            item.content.GetComponent<CanvasGroup>().alpha = 0;
        }

    }

    private OneFloorFolderItemController[] items
    {
        get
        {
            return GetComponentsInChildren<OneFloorFolderItemController>();
        }
    }
}
