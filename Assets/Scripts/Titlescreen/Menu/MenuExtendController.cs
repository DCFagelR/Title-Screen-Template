using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuExtendController : MonoBehaviour
{
    public GameObject MenuText; // Start button text

    public void StartMenuExtend()
    {
        StopCoroutine(MenuExtendAnimation());
        StartCoroutine(MenuExtendAnimation());
    }

    private IEnumerator MenuExtendAnimation()
    {
        GetComponent<HideButtons>().FadeMenuText();

        while(!MenuText.GetComponent<TextFader>().getIsDoneFading()) {
            yield return new WaitForSeconds(0.2f);
        }

        GetComponent<MenuExtender>().ExtendMenu();

        yield return null;
    }
}
