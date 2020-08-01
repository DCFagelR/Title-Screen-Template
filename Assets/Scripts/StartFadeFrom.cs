using UnityEngine;

public class StartFadeFrom : MonoBehaviour
{
    // BlackFade fader => GameObject.Find("FadingCanvas").GetComponent<BlackFade>();

    [SerializeField]
    private GameObject fader;

    // Start is called before the first frame update
    void Start()
    {
        // fader.FadeController();
        fader.GetComponent<BlackFade>().FadeController();
    }
}
