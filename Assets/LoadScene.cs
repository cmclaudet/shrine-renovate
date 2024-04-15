using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private bool startedLoading;

    public void Load(string sceneName)
    {
        if (startedLoading == false)
        {
            SceneManager.LoadScene(sceneName);
            startedLoading = true;
        }
    }
}
