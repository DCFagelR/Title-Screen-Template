using System.Collections;
using UnityEngine;

public class BlackFade : MonoBehaviour
{
    public const float FADE_SPEED = 0.05f;

    public CanvasGroup canvasGroup => GetComponent<CanvasGroup>();

    public void FadeController(bool fadeFrom = true) 
    {
        if(fadeFrom) {
            StartCoroutine(FadeFromBlack());
        } else {
            StartCoroutine(FadeToBlack());
        }
    }

    IEnumerator FadeFromBlack()
    {
        while(canvasGroup.alpha > 0) {
            canvasGroup.alpha -= FADE_SPEED;
            yield return null;
        }
    }

    IEnumerator FadeToBlack()
    {
        while(canvasGroup.alpha < 1) {
            canvasGroup.alpha += FADE_SPEED;
            yield return null;
        }
    }
}
