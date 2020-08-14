using System.Collections;
using UnityEngine;

public class Fade : MonoBehaviour
{

// ++Variables+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    public const float FADE_SPEED = 0.5f;

    public CanvasGroup canvasGroup => GetComponent<CanvasGroup>();

    private bool _isDoneFade = false;

    public void FadeController(bool fadeFrom = true, bool deactivate = false) 
    {
        _isDoneFade = false;
        gameObject.SetActive(true);

        if(fadeFrom) {
            StopAllCoroutines();
            StartCoroutine(FadeFromBlack(deactivate));
        } else {
            StopAllCoroutines();
            StartCoroutine(FadeToBlack());
        }
    }

// ++Methods+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    public bool GetIsDoneFade() {return _isDoneFade;}

// ----------------------------------------------------------------------------

    // Black to screen
    IEnumerator FadeFromBlack(bool deactivate = false)
    {
        while(canvasGroup.alpha > 0) {
            canvasGroup.alpha -= Time.deltaTime/FADE_SPEED;
            yield return null;
        }

        if(deactivate) {
            gameObject.SetActive(false);
        }

        _isDoneFade = true;
    }

// ----------------------------------------------------------------------------

    // Screen to black
    IEnumerator FadeToBlack()
    {
        while(canvasGroup.alpha < 1) {
            canvasGroup.alpha += Time.deltaTime/FADE_SPEED;
            yield return null;
        }

        _isDoneFade = true;
    }
    
// ----------------------------------------------------------------------------

}