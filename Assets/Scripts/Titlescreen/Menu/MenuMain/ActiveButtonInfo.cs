using UnityEngine;

public class ActiveButtonInfo : MonoBehaviour
{
    [Tooltip("Should be in the side menu. Immediate parent to buttons.")]
    public GameObject buttonHolder;

// ----------------------------------------------------------------------------

    // Get the name of the currently pressed button
    public string GetPressedName()
    {
        return buttonHolder.GetComponent<ButtonIsPressed>().GetPressedName();
    }

// ----------------------------------------------------------------------------

    // Get the child number of the currently pressed button
    public int GetPressedNumber()
    {
        // -1 because of New Game button being 0th child
        return buttonHolder.GetComponent<ButtonIsPressed>().GetPressedNumber() - 1;
    }

}
