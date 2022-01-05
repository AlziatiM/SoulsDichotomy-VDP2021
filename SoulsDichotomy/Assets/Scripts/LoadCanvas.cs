using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCanvas : MonoBehaviour
{

    public GameObject panel;
    private bool amIOpen;
    private int amoutOpen;

    public static LoadCanvas instance;

    private void Awake()
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
        amIOpen = false;
        amoutOpen = 0;
        panel.SetActive(false);
    }
    // Start is called before the first frame update

    internal void Open()
    {
        ++amoutOpen;
        if (!amIOpen)
        {
            Time.timeScale = 0;
            amIOpen = true;
            panel.SetActive(true);
        }
    }

    internal void Close()
    {
        --amoutOpen;
        if (amoutOpen == 0)
        {
            amIOpen = false;
            MenuManager.instance.CloseAllMenus();
            Time.timeScale = 1;
            panel.SetActive(false);
        }
        
    }

}
