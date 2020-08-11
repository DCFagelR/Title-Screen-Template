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
    private GameObject _continuePrefab;

    private bool _isOpen;
    private string _folderRoute = "Prefabs/Title/MenuExtender/MenuMain/";

    public void MenuManager()
    {
        StopCoroutine(showMenu());
        StartCoroutine(showMenu());
    }

    IEnumerator showMenu()
    {
        while(GetComponent<RectTransform>().offsetMin.x > 0 && !_isOpen) {
            yield return new WaitForEndOfFrame();
        }

        _isOpen = true;
        StopCoroutine(showMenu());
        StartCoroutine(createMenu());

        fadeScreen.GetComponent<Fade>().FadeController(true);

        yield return null;
    }

    IEnumerator createMenu()
    {
        title.GetComponent<Text>().text = buttonHolder.GetComponent<ButtonIsPressed>().pressedButtonName;

        Instantiate(_continuePrefab);

        yield return null;
    }
}
