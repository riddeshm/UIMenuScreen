using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuUIButton : MonoBehaviour, IPointerDownHandler
{
    public Action<MenuUIButton> OnClicked;
    public bool isSelected;
    public Sprite iconSprite;
    public string title;

    private LayoutElement layoutElement;
    private RectTransform rectTransform;
    private GameObject icon;
    private float defaultWidth;
    private float selectedWidth;
    private float widthMultiplier = 2f;


    public float SelectedWidth
    {
        get
        {
            return selectedWidth;
        }
    }

    private void Start()
    {
        layoutElement = GetComponent<LayoutElement>();
        rectTransform = GetComponent<RectTransform>();
        iconSprite = GetComponentsInChildren<Image>()[1].sprite;
        icon = transform.GetChild(0).gameObject;
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
        icon.SetActive(true);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnClicked?.Invoke(this);
        isSelected = true;
        StartCoroutine(SetSelectedWidth());
        icon.SetActive(false);
    }
}
