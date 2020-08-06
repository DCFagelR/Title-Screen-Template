using UnityEngine;

public class HideButtons : MonoBehaviour
{

    private GameObject MenuButtons => transform.GetChild(0).gameObject;

    private int _currChild = 0;
    private GameObject _currentButton;

    public void FadeMenuText()
    {
        while(_currChild < MenuButtons.transform.childCount)
        {
            _currentButton = MenuButtons.transform.GetChild(_currChild).gameObject;
            _currentButton.GetComponentInChildren<TextFader>().TextFadeContoller(true);
            _currChild++;
        }
    }
}
