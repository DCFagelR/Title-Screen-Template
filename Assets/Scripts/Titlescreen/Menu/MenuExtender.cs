using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuExtender : MonoBehaviour
{
// ++Variables+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    
    private GameObject MyChild => transform.GetChild(0).gameObject;
    private Vector2 OriginalSize => GetComponent<RectTransform>().sizeDelta;
    
    private GameObject _childButtons;

    [Range(1,10)]
    [SerializeField]
    private float screenSpeed = 5;

// ++Methods+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    public void ExtendMenu(bool isExtending = true)
    {
        StartCoroutine(StartMenuExtend(isExtending));
    }

// ----------------------------------------------------------------------------

    IEnumerator StartMenuExtend(bool isExtending)
    {
        Vector2 currentSize;
        Vector2 targetSize;
        float fullscreenWidth = -Screen.width * GetComponent<RectTransform>().anchorMin.x;
        float currentPercent = 0f;

        if(isExtending) {
            currentSize = OriginalSize;
            targetSize = new Vector2(fullscreenWidth, 0);
        } else {
            currentSize = new Vector2(fullscreenWidth, 0);
            targetSize = OriginalSize;
        }

        while(GetComponent<RectTransform>().offsetMin != targetSize) {
            GetComponent<RectTransform>().offsetMin = Vector2.Lerp(currentSize, targetSize, currentPercent);
            currentPercent += screenSpeed * Time.deltaTime;
            // yield return new WaitForEndOfFrame();
            yield return null;
        }

        StopCoroutine(StartMenuExtend(isExtending));
    }
}
