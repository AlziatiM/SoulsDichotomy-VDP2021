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
            if (MenuManager.instance.AmIOnTop(this))
            {
                AudioManager.instance.PlayMusic("Main");
                pause = false;
                Time.timeScale = 1;
                Exit();
            }
            else
            {
                MenuManager.instance.Back();
            } 
        }
        else
        {
            AudioManager.instance.PlayMusic("Menu");
            pause = true;
            Time.timeScale = 0;
            MenuManager.instance.Open(this);
        }
    }

    public void Resume()
    {
        pause = false;
        Time.timeScale = 1;
    }

    public void ChooseLevel()
    {
        MenuManager.instance.Open(LevelSelectorMenu.instance);
    }

    public void Setting()
    {
        MenuManager.instance.Open(SettingsMenu.instance);
    }

    public void BackToMainMenu()
    {   
        TogglePause();
        AudioManager.instance.PlayMusic("Menu");
        LevelManager.instance.BackToMainMenu();
    }

    public void PowerUp()
    {
        MenuManager.instance.Open(SkillMenu.instance);
    }

}
