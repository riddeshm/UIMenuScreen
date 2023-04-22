using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuUIButton : MonoBehaviour, IPointerDownHandler
{
    public Action OnClicked;
    public bool isSelected;

    HorizontalLayoutGroup horizontalLayoutGroup;
    LayoutElement layoutElement;
    RectTransform rectTransform;
    float defaultWidth;
    float selectedWidth;
    float widthMultiplier = 2f;

    private void Start()
    {
        horizontalLayoutGroup = GetComponentInParent<HorizontalLayoutGroup>();
        layoutElement = GetComponent<LayoutElement>();
        rectTransform = GetComponent<RectTransform>();
        StartCoroutine(GetWidth());
    }

    private IEnumerator GetWidth()
    {
        yield return null;
        defaultWidth = rectTransform.sizeDelta.x;
        selectedWidth = rectTransform.sizeDelta.x * widthMultiplier;
        if (isSelected)
        {
            layoutElement.minWidth = selectedWidth;
        }
    }

    private IEnumerator SetSelectedWidth()
    {
        while (Mathf.Round(rectTransform.sizeDelta.x) < selectedWidth)
        {
            layoutElement.minWidth = Mathf.Lerp(layoutElement.minWidth, selectedWidth, 0.5f);
            yield return null;
        }
    }

    public IEnumerator SetDefaultWidth()
    {
        Debug.Log("SetDefaultWidth");
        while (Mathf.Round(rectTransform.sizeDelta.x) > defaultWidth)
        {
            layoutElement.minWidth = Mathf.Lerp(layoutElement.minWidth, 0, 0.5f);
            yield return null;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnClicked?.Invoke();
        isSelected = true;
        StartCoroutine(SetSelectedWidth());
    }
}
