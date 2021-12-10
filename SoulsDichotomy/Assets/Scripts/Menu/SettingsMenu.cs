using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : Menu
{
    public static SettingsMenu instance;
    CustomizeInput customizeinput;
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
        customizeinput = GetComponent<CustomizeInput>();
    }
    private void OnEnable()
    {
        customizeinput.SetText();
    }

    public CustomizeInput GetCustomInput()
    {
        return customizeinput;
    }
}
