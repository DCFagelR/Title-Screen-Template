using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideButtons : MonoBehaviour
{

    private GameObject MenuButtons => transform.GetChild(0).gameObject;

    private int _currChild = 0;
    private GameObject _currentButton;

    public void FadeMenuText()
    {
        while(_currChild < MenuButtons.transform.childCount)
        {
            _currentButton = MenuButtons.transform.GetChild(_currChild).gameObject;
            _currentButton.GetComponentInChildren<TextFader>().TextFadeContoller(true);
            _currChild++;
        }

        StopCoroutine(WaitForFade());
        StartCoroutine(WaitForFade());
    }

    private IEnumerator WaitForFade()
    {
        while(_currentButton.GetComponentInChildren<TextFader>().getTextAlpha() > 0)
        {
            Debug.Log("Not done fading.");
            yield return new WaitForEndOfFrame();
        }

        
    }
}
