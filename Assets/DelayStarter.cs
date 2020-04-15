using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayStarter : MonoBehaviour
{
    [SerializeField] int SceneIndexToLoad;
    [SerializeField] float Delay;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Invoke(nameof(LoadFirstScene), Delay);
    }

    private void LoadFirstScene()
    {     
        SceneManager.LoadScene(SceneIndexToLoad);
    }
}
