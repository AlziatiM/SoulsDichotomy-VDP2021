using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : Menu
{

    [SerializeField] private GameObject levelManager;

    public static MainMenu instance;
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

    public void Play()
    {
        Instantiate(levelManager, Vector3.zero, Quaternion.identity);
    }

    public void OpenSettings()
    {
        MenuManager.instance.Open(SettingsMenu.instance);
    }

    public void OpenCredit()
    {
        MenuManager.instance.Open(CreditsMenu.instance);
    }

    public override void Exit()
    {
        Application.Quit();
    }
}
