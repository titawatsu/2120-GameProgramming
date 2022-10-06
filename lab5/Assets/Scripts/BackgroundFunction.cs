
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundFunction : MonoBehaviour
{
    public static BackgroundFunction instance;

    void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        var backgroundAudio = instance.GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().name == "MainMenu") backgroundAudio.Pause();
        if (SceneManager.GetActiveScene().name == "Level 1") backgroundAudio.UnPause();

    }
}
