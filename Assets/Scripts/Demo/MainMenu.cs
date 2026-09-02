using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string playScene;

    public void PressedPlay()
    { GameManager.Instance.LoadScene(playScene); }

    public void PressedQuit()
    { Application.Quit(); }
}
