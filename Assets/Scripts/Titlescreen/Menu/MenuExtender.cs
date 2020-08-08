using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuExtender : MonoBehaviour
{
// ++Variables+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    
    private Vector2 OriginalSize => GetComponent<RectTransform>().sizeDelta;

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
        float currentPercent = 0f;

        // -OriginalSize because its offsetMin. Corrects math issues
        if(isExtending) {
            currentSize = -OriginalSize;
            targetSize = Vector2.zero;
        } else {
            currentSize = Vector2.zero;
            targetSize = -OriginalSize;
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
