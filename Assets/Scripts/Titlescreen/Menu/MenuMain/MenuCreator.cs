
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
    private string _title;

// ++Methods+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    public void CreateMenu()
    {
        _currPressed = GetComponent<ActiveButtonInfo>().GetPressedNumber();
        _title = GetComponent<ActiveButtonInfo>().GetPressedName();

        ChangeTitle();
        CreatePrefab();
    }

// ----------------------------------------------------------------------------

    private void ChangeTitle()
    {
        title.GetComponent<Text>().text = _title;
    }

// ----------------------------------------------------------------------------

    private void CreatePrefab()
    {
        Debug.Log(_currPressed);

        Instantiate(menuPrefabs[_currPressed], transform);

        transform.GetChild(transform.childCount - 1).transform.SetAsFirstSibling();
    }
}
