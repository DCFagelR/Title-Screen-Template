using UnityEngine;

public class NewGame : MonoBehaviour
{
    public GameObject fadeCanvas;

    public void StartNewGame()
    {
        fadeCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true;
        fadeCanvas.GetComponent<Fade>().FadeController(false);
    }
}
