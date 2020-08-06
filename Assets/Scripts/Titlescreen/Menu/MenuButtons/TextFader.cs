using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextFader : MonoBehaviour
{
    [Range(0.01f,1)]
    [SerializeField]
    private float _fadeSpeed = 0.1f;

    private Text MyText => GetComponent<Text>();

    private IEnumerator _isDoneFading;

    public void TextFadeContoller(bool isFadeText = true)
    {
        StartCoroutine(FadeText(isFadeText));
    }

    public float getTextAlpha()
    {
        return MyText.color.a;
    }

    IEnumerator FadeText(bool isFadeText)
    {
        if(isFadeText) { // fade
            while(MyText.color.a != 0) {
                MyText.color -= new Color(0,0,0, _fadeSpeed);
                yield return new WaitForEndOfFrame();
            }
        } else { // reveal
            while(MyText.color.a != 1) {
                MyText.color += new Color(0,0,0, _fadeSpeed);
                yield return new WaitForEndOfFrame();
            }         
        }
        yield return true;
    }
}
