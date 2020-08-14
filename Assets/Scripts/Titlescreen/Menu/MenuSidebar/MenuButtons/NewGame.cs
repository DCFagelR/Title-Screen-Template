using UnityEngine;
using UnityEngine.UI;

public class NewGame : MonoBehaviour
{
    public GameObject fadeCanvas;

    public void StartNewGame()
    {
        fadeCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true;
        fadeCanvas.GetComponent<Fade>().FadeController(false);
    }
}
