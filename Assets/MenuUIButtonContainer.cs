using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIButtonContainer : MonoBehaviour
{
    [SerializeField] MenuUIButton[] menuButtons;

    private void Start()
    {
        foreach(MenuUIButton menuButton in menuButtons)
        {
            menuButton.OnClicked += OnMenuButtonClicked;
        }
    }

    private void OnMenuButtonClicked()
    {
        Debug.Log("OnMenuButtonClicked");
        ResetButtonsToDefault();
    }

    private void ResetButtonsToDefault()
    {
        foreach (MenuUIButton menuButton in menuButtons)
        {
            StartCoroutine(menuButton.SetDefaultWidth());
        }
    }
}
