
using UnityEngine;
using UnityEngine.UI;

public class MenuCreator : MonoBehaviour
{
// ++Variables+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    [Header("Menu Prefabs")]
    [SerializeField]
    [Tooltip("Make sure size and order match the menu buttons!")]
    private GameObject[] menuPrefabs;

    [Header("GameObjects")]
    public GameObject title;

    private int _currPressed;   // child # of active button
    private string _titleText;  // name of active button

// ++Methods+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    public void CreateMenu()
    {
        _currPressed = GetComponent<ActiveButtonInfo>().GetPressedNumber();
        _titleText = GetComponent<ActiveButtonInfo>().GetPressedName();

        if(!title.activeInHierarchy)
        {
            title.SetActive(true);
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

    // creates the menu. Array of prefabs SHOULD match up with the child number as long as they were
    // placed in the correct order. Check the editor window
    private void CreatePrefab()
    {
        Instantiate(menuPrefabs[_currPressed], transform);

        transform.GetChild(transform.childCount - 1).transform.SetAsFirstSibling();
    }
}
