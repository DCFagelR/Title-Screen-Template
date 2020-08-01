using System.Collections;
using UnityEngine;

public class BlackFade : MonoBehaviour
{

// ++Variables+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    // Speed of the black fade
    public const float FADE_SPEED = 0.5f;

    public CanvasGroup canvasGroup => GetComponent<CanvasGroup>();

    // fadeFrom: true = fadeFrom() is called
    public void FadeController(bool fadeFrom = true) 
    {
        if(fadeFrom) {
            StartCoroutine(FadeFromBlack());
        } else {
            StartCoroutine(FadeToBlack());
        }
    }

// ++Methods+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    // Black to screen
    IEnumerator FadeFromBlack()
    {
        while(canvasGroup.alpha > 0) {
            canvasGroup.alpha -= Time.deltaTime/FADE_SPEED;
            yield return null;
        }
    }

// ----------------------------------------------------------------------------

    // Screen to black
    IEnumerator FadeToBlack()
    {
        while(canvasGroup.alpha < 1) {
            canvasGroup.alpha += Time.deltaTime/FADE_SPEED;
            yield return null;
        }
    }
    
// ----------------------------------------------------------------------------

}
