using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : Menu
{
    public static InGameMenu instance;
    private bool pause;
    public bool isPaused { get { return pause; } }
    public void Awake()
    {
        pause = false;
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

    public void TogglePause()
    {
        if (pause)
        {
            pause = false;
            Time.timeScale = 1;
            Exit();
        }
        else
        {
            pause = true;
            Time.timeScale = 0;
            MenuManager.instance.Open(this);
        }
    }

    public void ChooseLevel()
    {

    }

    public void Setting()
    {
        MenuManager.instance.Open(SettingsMenu.instance);
    }

    public void BackToMainMenu()
    {
        
        TogglePause();
        LevelManager.instance.BackToMainMenu();
    }

}
