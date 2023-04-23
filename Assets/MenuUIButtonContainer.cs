using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIButtonContainer : MonoBehaviour
{
    [SerializeField] MenuUIButton[] menuButtons;
    [SerializeField] MenuUIButtonOverlay menuButtonOverlay;

    private void Start()
    {
        foreach(MenuUIButton menuButton in menuButtons)
        {
            if(menuButton.isSelected)
            {
                StartCoroutine(menuButtonOverlay.SetWidthAndPosition(menuButton));
            }
            menuButton.OnClicked += OnMenuButtonClicked;
        }
    }

    private void OnMenuButtonClicked(MenuUIButton menuUIButton)
    {
        Debug.Log("OnMenuButtonClicked");
        ResetButtonsToDefault();
        if(menuButtonOverlay.positionLerpCoroutine != null)
        {
            StopCoroutine(menuButtonOverlay.positionLerpCoroutine);
        }
        menuButtonOverlay.positionLerpCoroutine = StartCoroutine(menuButtonOverlay.LerpToSelectedButtonPosition(menuUIButton));
    }

    private void ResetButtonsToDefault()
    {
        foreach (MenuUIButton menuButton in menuButtons)
        {
            StartCoroutine(menuButton.SetDefaultWidth());
        }
    }
}
