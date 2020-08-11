using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject title;
    public GameObject fadeScreen;
    public GameObject buttonHolder;

    [SerializeField]
    private GameObject _continuePrefab = null;

    private bool _isOpen;

    public void MenuManager()
    {
        if(_isOpen){
            StopCoroutine(HideMenu());
            StartCoroutine(HideMenu());
        } else {
            StopCoroutine(ShowMenu());
            StartCoroutine(ShowMenu());
        }
    }

    private void CreateMenu()
    {
        title.GetComponent<Text>().text = buttonHolder.GetComponent<ButtonIsPressed>().pressedButtonName;

        // Makes the prefab a child of the MainMenu, the current gameobject
        Instantiate(_continuePrefab, transform);
    }

    private IEnumerator ShowMenu()
    {
        // Wait to finish opening menu
        while(GetComponent<RectTransform>().offsetMin.x > 0 && !_isOpen) {
            yield return new WaitForEndOfFrame();
        }

        _isOpen = true;
        CreateMenu();

        fadeScreen.GetComponent<Fade>().FadeController(true);
        StopCoroutine(ShowMenu());
    }

    private IEnumerator HideMenu()
    {
        fadeScreen.GetComponent<Fade>().FadeController(false);

        while(!fadeScreen.GetComponent<Fade>().GetIsDoneFade()) {
            yield return new WaitForEndOfFrame();
        }

        Destroy(transform.GetChild(transform.childCount - 1).gameObject);

        yield return null;

        StartCoroutine(ShowMenu());
    }
}
