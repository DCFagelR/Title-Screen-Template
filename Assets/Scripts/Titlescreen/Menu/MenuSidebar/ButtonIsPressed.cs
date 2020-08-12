using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonIsPressed : MonoBehaviour
{

// ++Variables+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    private GameObject[] _menuButtons; // Array of which child is currently not interactable
    private GameObject _deactivateMe;
    private GameObject _pressedButton;
    private string _pressedButtonName;
    private int _pressedChildNumber;

// ++Methods+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    void Start() {
        _menuButtons = new GameObject[transform.childCount];

        for(int i = 0; i < transform.childCount; i++) {
            _menuButtons[i] = transform.GetChild(i).gameObject;
        }
    }

// ----------------------------------------------------------------------------

    public string GetPressedName() {return _pressedButtonName;}

// ----------------------------------------------------------------------------

    // Get child # of the current pressed button
    public int GetPressedNumber()
    {
        for(int i = 0; i < transform.childCount; i++) {
            if(_menuButtons[i].GetComponent<Button>().interactable == false) {
                return i;
            }
        }

        Debug.LogError("Somehow, no button is currently active.");
        return -1;
    }

// ----------------------------------------------------------------------------

    public void SwitchActiveButton(GameObject button)
    {
        _pressedButton = button;
        _pressedButtonName = _pressedButton.GetComponentInChildren<Text>().text;

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