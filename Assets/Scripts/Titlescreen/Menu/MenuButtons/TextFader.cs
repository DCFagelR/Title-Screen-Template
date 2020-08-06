
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextFader : MonoBehaviour
{

    private Text MyText => GetComponent<Text>();

    [Range(0.01f,1)]
    [SerializeField]
    private float _fadeSpeed = 0.1f;
    private bool _isDoneFading;

    public void TextFadeContoller(bool isFadeText = true)
    {
        _isDoneFading = false;
        StartCoroutine(FadeText(isFadeText));
    }

    public bool getIsDoneFading()
    {
        return _isDoneFading;
    }

    private IEnumerator FadeText(bool isFadeText)
    {
        if(isFadeText) { // fade
            while(MyText.color.a > 0) {
                MyText.color -= new Color(0,0,0, _fadeSpeed);
                yield return new WaitForEndOfFrame();
            }
            transform.parent.gameObject.SetActive(false);
        } else { // reveal
            while(MyText.color.a < 1) {
                MyText.color += new Color(0,0,0, _fadeSpeed);
                yield return new WaitForEndOfFrame();
            }
            transform.parent.gameObject.SetActive(true);      
        }

        _isDoneFading = true;
    }
}
