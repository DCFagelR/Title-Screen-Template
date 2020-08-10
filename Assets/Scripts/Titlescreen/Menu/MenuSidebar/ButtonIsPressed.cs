using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonIsPressed : MonoBehaviour
{

// ++Variables+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    private GameObject[] _menuButtons; // Array of which child is currently not interactable
    private GameObject _deactivateMe;
    private GameObject _pressedButton;

// ++Methods+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    void Start() {
        _menuButtons = new GameObject[transform.childCount];

        for(int i = 0; i < transform.childCount; i++) {
            _menuButtons[i] = transform.GetChild(i).gameObject;
        }
    }

// ----------------------------------------------------------------------------

    public void SwitchActiveButton(GameObject button)
    {
        _pressedButton = button;

        ReactivateButton();
        DeactivateButton();
    }

// ----------------------------------------------------------------------------

    public void ReactivateButton()
    {
        for(int i = 0; i < transform.childCount; i++) {
            if(_menuButtons[i].GetComponent<Button>().interactable == false) {
                transform.GetChild(i).GetComponent<EventTrigger>().enabled = true;
                transform.GetChild(i).GetComponent<Button>().interactable = true;
            }
        }
    }

// ----------------------------------------------------------------------------

    private void DeactivateButton()
    {
        _pressedButton.GetComponent<EventTrigger>().enabled = false;
        _pressedButton.GetComponent<Button>().interactable = false;
    }
}