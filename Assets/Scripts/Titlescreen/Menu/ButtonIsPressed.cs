using UnityEngine;
using UnityEngine.UI;

public class ButtonIsPressed : MonoBehaviour
{

    private GameObject[] _menuButtons; // Array of which child is currently not interactable

    private GameObject _deactivateMe;

    void Start() {
        _menuButtons = new GameObject[transform.childCount];

        for(int i = 0; i < transform.childCount; i++) {
            _menuButtons[i] = transform.GetChild(i).gameObject;
        }
    }

    public void ReactivateButton(GameObject pressedButton)
    {
        for(int i = 0; i < transform.childCount; i++) {
            if(_menuButtons[i].GetComponent<Button>().interactable == false) {
                transform.GetChild(i).GetComponent<Button>().interactable = true;
            }
        }

        DeactivateButton(pressedButton);
    }

    private void DeactivateButton(GameObject button)
    {
        button.GetComponent<Button>().interactable = false;
    }
}