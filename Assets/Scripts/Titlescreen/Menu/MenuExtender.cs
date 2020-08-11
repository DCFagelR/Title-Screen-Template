using System.Collections;
using UnityEngine;

public class MenuExtender : MonoBehaviour
{
// ++Variables+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    
    private Vector2 OriginalSize => GetComponent<InitialMenuSize>().getClosedSize();

    [SerializeField]
    private GameObject _mainMenu = null;

    [Range(1,10)]
    [SerializeField]
    private float _extendSpeed = 5;

// ++Methods+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    public void ExtendMenu(bool isExtending = true)
    {
        StartCoroutine(StartMenuExtend(isExtending));
    }

// ----------------------------------------------------------------------------

    IEnumerator StartMenuExtend(bool isExtending)
    {
        Vector2 currentSize;
        Vector2 targetSize;
        float currentPercent = 0f;

        // -OriginalSize because its offsetMin. Corrects math issues
        if(isExtending) {
            currentSize = -OriginalSize;
            targetSize = Vector2.zero;
        } else {
            currentSize = Vector2.zero;
            targetSize = -OriginalSize;
            Debug.Log(targetSize);
        }

        while(_mainMenu.GetComponent<RectTransform>().offsetMin != targetSize) {
            _mainMenu.GetComponent<RectTransform>().offsetMin = Vector2.Lerp(currentSize, targetSize, currentPercent);
            currentPercent += _extendSpeed * Time.deltaTime;
            // yield return new WaitForEndOfFrame();
            yield return null;
        }

        StopCoroutine(StartMenuExtend(isExtending));
    }
}
