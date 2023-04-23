using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuUIButtonOverlay : MonoBehaviour
{
    private RectTransform rectransform;
    public Coroutine positionLerpCoroutine;
    [SerializeField] Image iconImage;
    [SerializeField] TextMeshProUGUI titleText;

    private void Start()
    {
        rectransform = GetComponent<RectTransform>();
    }

    private void SetSpriteAndText(Sprite _sprite, string _title)
    {
        iconImage.sprite = _sprite;
        titleText.text = _title;
    }

    public IEnumerator SetWidthAndPosition(MenuUIButton menuUIButton)
    {
        yield return null;
        SetSpriteAndText(menuUIButton.iconSprite, menuUIButton.title);
        yield return null;
        rectransform.sizeDelta = new Vector2(menuUIButton.SelectedWidth, rectransform.sizeDelta.y);
        transform.position = menuUIButton.transform.position;
    }

    public IEnumerator LerpToSelectedButtonPosition(MenuUIButton menuUIButton)
    {
        SetSpriteAndText(menuUIButton.iconSprite, menuUIButton.title);
        while (Vector3.Distance(transform.localPosition, menuUIButton.transform.localPosition) > 0.1)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, menuUIButton.transform.localPosition, 0.3f);
            yield return null;
        }
        positionLerpCoroutine = null;
    }
}
