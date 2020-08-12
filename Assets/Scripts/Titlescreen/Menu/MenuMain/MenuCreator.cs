
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

    private int _currPressed;
    private string _titleText;

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

    private void CreatePrefab()
    {
        Debug.Log(_currPressed);

        Instantiate(menuPrefabs[_currPressed], transform);

        transform.GetChild(transform.childCount - 1).transform.SetAsFirstSibling();
    }
}
