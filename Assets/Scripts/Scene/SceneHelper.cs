using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHelper : MonoBehaviour
{
    public string sceneOpen;

    public void OpenGame()
    {
        SceneManager.LoadScene(sceneOpen);
    }
}
