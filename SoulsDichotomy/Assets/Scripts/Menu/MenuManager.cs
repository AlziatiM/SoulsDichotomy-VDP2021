using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private Stack<Menu> stackMenus;

    public static MenuManager instance;

    public delegate void OnGameOver();
    public static OnGameOver gameOver;

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
        stackMenus = new Stack<Menu>(); 
    }

    void Start()
    {
        Open(MainMenu.instance);
    }

    public void LoadMainScene()
    {
        gameOver();
        stackMenus.Clear();
        print("dai worka");
        Open(MainMenu.instance);
    }

    public void GameOver()
    {
        Open(GameOverMenu.instance);
    }

    public void Open(Menu menu)
    {
        if (stackMenus.Count != 0) 
        {
            stackMenus.Peek().Close();
        }
        menu.Open();
        stackMenus.Push(menu);
    }

    public void Back()
    {
        stackMenus.Peek().Close();
        stackMenus.Pop();
        if(stackMenus.Count!=0)
            stackMenus.Peek().Open();
    }
}
