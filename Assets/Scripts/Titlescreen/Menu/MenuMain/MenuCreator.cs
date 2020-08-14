
using UnityEngine;
using UnityEngine.UI;

public class MenuCreator : MonoBehaviour
{
// ++Variables+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    [SerializeField]
    [Tooltip("Make sure size and order match the menu buttons!")]
    private GameObject[] menuPrefabs = null;

    [Header("GameObjects")]
    public GameObject title;

    private int _currPressed;
    private string _titleText;

// ++Methods+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    public void CreateMenu(int buttonNumber, string name)
    {
        _currPressed = buttonNumber;
        _titleText = name;

        if(!title.activeInHierarchy)
        {
            title.SetActive(true);
            title.GetComponent<TextFader>().TextFadeContoller(false);
        }

        ChangeTitle();
        CreatePrefab();
    }

// ----------------------------------------------------------------------------

    private void ChangeTitle()
    {
        title.GetComponent<Text>().text = _titleText;
    }

// ----------------------------------------------------------------------------

    private void CreatePrefab()
    {
        Debug.Log(_currPressed);

        Instantiate(menuPrefabs[_currPressed], transform);

        transform.GetChild(transform.childCount - 1).transform.SetAsFirstSibling();
    }
}
