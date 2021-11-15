using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    [SerializeField]private string[] levels;
    [SerializeField]private string mainMenu;
    private int currLevel;

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
        SceneManager.LoadScene(levels[currLevel]);
    }

    public void LoadLevel(int index)
    {
        currLevel = index;
        SceneManager.LoadScene(levels[index]);
    }
   
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
