using UnityEngine;

public class FadeToButton : MonoBehaviour
{
    [SerializeField]
    private BlackFade fader;// => GameObject.Find("FadingCanvas").GetComponent<BlackFade>();

    public void OnButtonPress()
    {
        // Fade to black
        fader.FadeController(false);
    }
}
