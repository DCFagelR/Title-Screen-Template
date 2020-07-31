using System.Collections;
using UnityEngine;

public class BlackFade : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (FadeMe());        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeMe()
    {
        float fadeSpeed = 0.05F;

        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while(canvasGroup.alpha > 0) {
            canvasGroup.alpha -= fadeSpeed;
            yield return null;
        }
        
    }
}
