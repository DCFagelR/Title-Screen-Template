using System.Collections;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
// ++Variables+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    private float closedSize => transform.parent.GetComponent<MenuInitializer>().getClosedSize().x;    

    public GameObject fadeScreen;
    public GameObject title;

    private bool _isOpen;
    private int _pressedButton;
    private string _pressedName;

// ++Methods+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    public void MenuManager()
    {
        _pressedButton = GetComponent<ActiveButtonInfo>().GetPressedNumber();
        _pressedName = GetComponent<ActiveButtonInfo>().GetPressedName();
        if(_isOpen){
            StopCoroutine(SwitchMenu());
            StartCoroutine(SwitchMenu());
        } else {
            StopCoroutine(ShowMenu());
            StartCoroutine(ShowMenu());
        }
    }

// ----------------------------------------------------------------------------

    public void CollapseButton(){
        StartCoroutine(HideMenu());
    }

// ----------------------------------------------------------------------------

    private IEnumerator SwitchMenu()
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

        GetComponent<MenuCreator>().CreateMenu(_pressedButton, _pressedName);
        fadeScreen.GetComponent<Fade>().FadeController(true);

        StopCoroutine(ShowMenu());
    }

// ----------------------------------------------------------------------------

    private IEnumerator HideMenu()
    {
        title.GetComponent<TextFader>().TextFadeContoller(true);

        while(GetComponent<RectTransform>().offsetMin.x < -closedSize && _isOpen) {
            yield return new WaitForEndOfFrame();
        }

        fadeScreen.GetComponent<Fade>().FadeController(false);

        title.SetActive(false);
        Destroy(transform.GetChild(0).gameObject);

        _isOpen = false;
    }
}
