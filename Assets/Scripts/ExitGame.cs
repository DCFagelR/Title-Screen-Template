using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public static void QuitGame()
    {
        Debug.Log("The game has quit!");
        Application.Quit();
    }
}
