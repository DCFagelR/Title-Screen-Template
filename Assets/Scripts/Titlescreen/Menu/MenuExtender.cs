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

// ++Methods+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    public void ExtendMenu()
    {
        GetComponent<HideButtons>().FadeMenuText();
        Debug.Log("Done Fading.");
        
        // StartCoroutine(StartMenuExtend());
    }

// ----------------------------------------------------------------------------

    IEnumerator StartMenuExtend()
    {
        Vector2 targetSize;
        float targetWidth = -Screen.width * GetComponent<RectTransform>().anchorMin.x;
        float currSize;
        float totalSizeNeeded = Vector2.Distance(OriginalSize, new Vector2(targetWidth, 0));
        float fractionOfTotalSize = 0f;
        float startTime;

        float speed = 1000f;

        // Wait for buttons to disappear before setting them inactive
        // while(MyChild.transform.GetChild(0).gameObject.GetComponentInChildren<TextFader>().getTextAlpha )
        MyChild.SetActive(false);
        
        targetSize = new Vector2(targetWidth, 0);

        startTime = Time.time;
        while(GetComponent<RectTransform>().offsetMin != targetSize) {
            currSize = (Time.time - startTime) * speed;
            fractionOfTotalSize = currSize/totalSizeNeeded;

            GetComponent<RectTransform>().offsetMin = Vector2.Lerp(OriginalSize, targetSize, fractionOfTotalSize);

            // yield return new WaitForEndOfFrame();
            yield return null;
        }

        StopCoroutine(StartMenuExtend());
    }
}
