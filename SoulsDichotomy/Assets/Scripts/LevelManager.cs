using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    [SerializeField]private string[] levels;
    [SerializeField]private string mainMenu;
    private int currLevel;
    public int CurrentLevel { get { return currLevel; } }
    public static LevelManager instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        currLevel = 0;
        
        LoadLevel(currLevel);
    }

    public void NextLevel()
    {
        currLevel++;
        if (levels.Length==currLevel)
        {
            GameOverMenu.instance.EndGame();
            GameOver();
            currLevel = 0;
        }
        else 
        {
            LoadNewLevel(currLevel);
            SkillManager.instance.NextLevelToLoad(currLevel + 1);
        }
    }

    public void LoadLevel(int index)
    {
        currLevel = index;
        LoadNewLevel(index);
        StartCoroutine("WaitSkillManager");
        
    }

    private IEnumerator WaitSkillManager()
    {
        yield return new WaitUntil(() => GameManager.instance != null);
        yield return new WaitUntil(()=> SkillManager.instance.AmIReady());
        SkillManager.instance.LoadLevelFromScratch(currLevel);
    }

    /// <summary>
    /// only load the scene from the scenemanager
    /// </summary>
    /// <param name="index">index of level to load</param>
    private void LoadNewLevel(int index)
    {
        SceneManager.LoadScene(levels[index]);
    }


    public void BackToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        MenuManager.instance.LoadMainScene();
    }

    internal void GameOver()
    {
        MenuManager.instance.GameOver();
    }

    public void TryAgainLevel()
    {
        LoadNewLevel(currLevel);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
