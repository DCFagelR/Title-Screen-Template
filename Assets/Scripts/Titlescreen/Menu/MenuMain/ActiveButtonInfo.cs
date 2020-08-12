using UnityEngine;

public class ActiveButtonInfo : MonoBehaviour
{
    [Tooltip("Should be in the side menu. Immediate parent to buttons.")]
    public GameObject buttonHolder;

// ----------------------------------------------------------------------------

    public string GetPressedName()
    {
        return buttonHolder.GetComponent<ButtonIsPressed>().GetPressedName();
    }

// ----------------------------------------------------------------------------

    public int GetPressedNumber()
    {
        // -1 because of New Game button being 0th child
        return buttonHolder.GetComponent<ButtonIsPressed>().GetPressedNumber() - 1;
    }

}
