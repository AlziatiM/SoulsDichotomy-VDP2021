using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverMenu : Menu
{
    public static GameOverMenu instance;
    [SerializeField] private TextMeshProUGUI titleMenu;


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

    internal void EndGame()
    {
        titleMenu.text = "You reach the end!\nTy 4 playing!";
    }

    internal void LevelFailed()
    {
        titleMenu.text = "You failed the level!";
    }

    public void TryAgain()
    {
        MenuManager.instance.Back();
        UIManager.instance.SetUpSlider();
        GameManager.instance.TryAgainSetup();

        LevelManager.instance.TryAgainLevel();
    }

    public void MainMenu()
    {
        MenuManager.instance.Back();
        LevelManager.instance.BackToMainMenu();
        
    }
}
