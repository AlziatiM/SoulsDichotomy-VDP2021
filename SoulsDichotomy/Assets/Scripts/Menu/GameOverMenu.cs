using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : Menu
{
    public static GameOverMenu instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        Close();
    }

    public void TryAgain()
    {
        MenuManager.instance.Back();
        LevelManager.instance.TryAgainLevel();
    }

    public void MainMenu()
    {
        MenuManager.instance.Back();
        LevelManager.instance.BackToMainMenu();
        
    }
}
