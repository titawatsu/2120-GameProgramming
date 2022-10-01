using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private DisplayHealth displayHealth;
    [SerializeField] private int playerLife = 3;
    // Simple singleton script. This is the easiest way to create and understand a singleton script.

    private void Start()
    {
        ResumeGame();
    }

    private void Awake()
    {

        var numGameManager = FindObjectsOfType<GameManager>().Length;
        //displayHealth = FindObjectOfType<DisplayHealth>();
        if (numGameManager > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            displayHealth.HealthUpdate(playerLife);
            DontDestroyOnLoad(gameObject);
        }
    }

    private void ResumeGame() => Time.timeScale = 1f;

    public void ProcessPlayerDeath()
    {

        playerLife--;
        displayHealth.HealthUpdate(playerLife);

        if (playerLife == 0)
        {
            
            LoadLevelMenu();
        }
        else
        {
            
            LoadSpecificLevel(GetCurrentBuildIndex());
        }
    }

    public void LoadLevelMenu()
    {
        Destroy(gameObject);
        LoadSpecificLevel(0);
        DOTween.KillAll();
    }

    public void LoadSpecificLevel(int LevelIndex)
    {
        SceneManager.LoadScene(LevelIndex);
        DOTween.KillAll();
    }

    public void LoadNextLevel()
    {
        var nextSceneIndex = GetCurrentBuildIndex() + 1;
        
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        
        SceneManager.LoadScene(nextSceneIndex);
        DOTween.KillAll();
    }

    private int GetCurrentBuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

}
