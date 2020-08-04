using UnityEngine;

public class StartFadeTo : MonoBehaviour
{
    [SerializeField]
    private BlackFade _fader;

    public void Awake()
    {
        _fader.FadeController(false);
    }
}
