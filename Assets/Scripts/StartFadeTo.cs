using UnityEngine;

public class StartFadeTo : MonoBehaviour
{
    [SerializeField]
    private BlackFade _fader = null;

    public void Awake()
    {
        _fader.FadeController(false);
    }
}
