using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToButton : MonoBehaviour
{
    BlackFade fader => GameObject.Find("FadingCanvas").GetComponent<BlackFade>();

    public void OnButtonPress()
    {
        fader.FadeController(false);
    }
}
