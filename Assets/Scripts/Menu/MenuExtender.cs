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
        FadeMenuButtons();
        StartCoroutine(StartMenuExtend());
    }

// ----------------------------------------------------------------------------

    private void FadeMenuButtons()
    {
        int currChild = 0;

        // fades all child buttons
        while(currChild < MyChild.transform.childCount) {
            _childButtons = MyChild.transform.GetChild(currChild).gameObject;
            _childButtons.GetComponentInChildren<TextFader>().TextFadeContoller(true);
            currChild++;
        }
    }

// ----------------------------------------------------------------------------

    IEnumerator StartMenuExtend()
    {
        Vector2 targetSize;
        float targetWidth = -Screen.width * GetComponent<RectTransform>().anchorMin.x;
        float currSize;
        float totalSizeNeeded = Vector2.Distance(OriginalSize, new Vector2(targetWidth, 0));
        float fractionOfTotalSize = 0f;
        float startTime = Time.time;

        float speed = 800f;

        // Wait for buttons to disappear before setting them inactive
        yield return new WaitForSeconds(0.5f);
        MyChild.SetActive(false);
        
        targetSize = new Vector2(targetWidth, 0);

        currSize = (Time.time - startTime) * speed;
        Debug.Log(totalSizeNeeded);
        Debug.Log(currSize);

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
