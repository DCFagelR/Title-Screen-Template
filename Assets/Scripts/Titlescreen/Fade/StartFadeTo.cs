using UnityEngine;

public class StartFadeTo : MonoBehaviour
{
    [SerializeField]
    private Fade _fader = null;

    public void Awake()
    {
        _fader.FadeController(false);
    }
}
