using UnityEngine;
using UnityEngine.SceneManagement;

public interface ISceneManager
{
    public void LoadScene(string sceneName);
}
public class SceneManager : MonoBehaviour, ISceneManager
{
    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName,LoadSceneMode.Single);
    }
}
