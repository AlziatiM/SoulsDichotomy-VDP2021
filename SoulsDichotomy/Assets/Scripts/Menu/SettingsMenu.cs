using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : Menu
{
    public static SettingsMenu instance;
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

}
