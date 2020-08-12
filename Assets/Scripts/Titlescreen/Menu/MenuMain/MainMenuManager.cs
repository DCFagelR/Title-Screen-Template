using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
// ++Variables+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    public GameObject fadeScreen;

    private bool _isOpen; // for when the menu is opening for the first time

// ++Methods+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    public void MenuManager()
    {
        if(_isOpen){
            StartCoroutine(HideMenu());
        } else {
            StopCoroutine(ShowMenu());
            StartCoroutine(ShowMenu());
        }
    }

// ----------------------------------------------------------------------------

    private IEnumerator HideMenu()
    {
        fadeScreen.GetComponent<Fade>().FadeController(false);

        while(!fadeScreen.GetComponent<Fade>().GetIsDoneFade()) {
            yield return new WaitForEndOfFrame();
        }

        // Note change this to a find. Just for safety reasons
        // Maybe move this to another script
        // Made it so its always first sibling
        Destroy(transform.GetChild(0).gameObject);

        StartCoroutine(ShowMenu());
    }

// ----------------------------------------------------------------------------

    private IEnumerator ShowMenu()
    {
        // Wait to finish opening menu
        while(GetComponent<RectTransform>().offsetMin.x > 0 && !_isOpen) {
            yield return new WaitForEndOfFrame();
        }

        _isOpen = true;
        GetComponent<MenuCreator>().CreateMenu();

        fadeScreen.GetComponent<Fade>().FadeController(true);
        StopCoroutine(ShowMenu());
    }
}
