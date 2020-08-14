using UnityEngine;

public class StartFadeFrom : MonoBehaviour
{
    [SerializeField]
    private Fade _fader = null;

    // Start is called before the first frame update
    void Start()
    {
        _fader.FadeController(true, true);
    }
}
