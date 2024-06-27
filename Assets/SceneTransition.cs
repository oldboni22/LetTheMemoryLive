using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SceneTransition : MonoBehaviour
{
    private ISceneManager _sceneManager;
    [SerializeField] private string _sceneName;

    [Inject]
    public void Init(ISceneManager sceneManager)
    {
        _sceneManager = sceneManager;
    }
    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => _sceneManager.LoadScene(_sceneName));
    }
}
