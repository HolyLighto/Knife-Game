using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonMethods : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
        ScoreAndStage.Reset();
    }
}
