using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject menu;

    public void Close()
    {
        menu.SetActive(false);
    }
    public void Open()
    {
        menu.SetActive(true);
    }

    public virtual void Exit()
    {
        MenuManager.instance.Back();
    }
}
