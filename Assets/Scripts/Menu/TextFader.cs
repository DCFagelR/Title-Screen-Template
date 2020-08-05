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

    public void TextFadeContoller(bool isFadeText = true)
    {
        StartCoroutine(FadeText(isFadeText));
    }

    IEnumerator FadeText(bool isFadeText)
    {
        if(isFadeText) {
            while(MyText.color.a != 0) {
                MyText.color -= new Color(0,0,0, _fadeSpeed);
                yield return null;
            }          
        } else {
            while(MyText.color.a != 0) {
                MyText.color -= new Color(0,0,0, _fadeSpeed);
                yield return null;
            }         
        }
    }
}
