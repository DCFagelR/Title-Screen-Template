using UnityEngine;

public class TestFadeout : MonoBehaviour
{
    BlackFade fader => GameObject.Find("FadingCanvas").GetComponent<BlackFade>();

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            fader.FadeController(false);
        }
    }
}
