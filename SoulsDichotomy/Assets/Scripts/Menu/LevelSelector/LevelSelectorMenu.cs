using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectorMenu : Menu
{
    public static LevelSelectorMenu instance;

    public GameObject[] panelsLevel;
    private int currPanelOpen;

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

    public override void Open()
    {
        base.Open();

        currPanelOpen = 0;
        ActivatePanelLevel(currPanelOpen);
    }



    private void ActivatePanelLevel(int index)
    {
        for(int i=0; i< panelsLevel.Length; i++)
        {
            panelsLevel[i].SetActive(i==index);
        }
    }

    public void NextPanel()
    {
        currPanelOpen = Mathf.Min(currPanelOpen + 1, panelsLevel.Length-1);
        ActivatePanelLevel(currPanelOpen);
    }

    public void PrevPanel()
    {
        currPanelOpen = Mathf.Max(currPanelOpen - 1, 0);
        ActivatePanelLevel(currPanelOpen);
    }

    public void LoadLevel(int level)
    {
        Exit();
        LevelManager.instance.LoadLevel(level);
    }
}
