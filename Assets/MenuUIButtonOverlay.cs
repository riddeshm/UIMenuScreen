using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIButtonOverlay : MonoBehaviour
{
    private RectTransform rectransform;
    public Coroutine positionLerpCoroutine;

    private void Start()
    {
        rectransform = GetComponent<RectTransform>();
    }

    public IEnumerator SetWidthAndPosition(MenuUIButton menuUIButton)
    {
        yield return null;
        yield return null;
        rectransform.sizeDelta = new Vector2(menuUIButton.SelectedWidth, rectransform.sizeDelta.y);
        transform.position = menuUIButton.transform.position;
    }

    public IEnumerator LerpToSelectedButtonPosition(MenuUIButton menuUIButton)
    {
        while (Vector3.Distance(transform.localPosition, menuUIButton.transform.localPosition) > 0.1)
        {
            Debug.Log(Vector3.Distance(transform.localPosition, menuUIButton.transform.localPosition));
            transform.localPosition = Vector3.Lerp(transform.localPosition, menuUIButton.transform.localPosition, 0.3f);
            yield return null;
        }
        positionLerpCoroutine = null;
    }
}
