using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCanvas : MonoBehaviour
{

    public GameObject panel;
    private bool amIOpen;
    private int amoutOpen;

    [SerializeField] private float secondsMinOpen;
    private bool canClose;
    private int numberOfIterationNeeded;
    private int number;
    private bool shoulICount;
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
        canClose = false;
        shoulICount = false;
        numberOfIterationNeeded = (int)Mathf.Ceil(secondsMinOpen * (1 / Time.fixedDeltaTime));
    }

    //50 call per secondo
    public void FixedUpdate()
    {
        if (shoulICount)
        {
            number++;
            if (number == numberOfIterationNeeded)
            {
                shoulICount = false;
                SetCanClose();
            }
        }
    }


    private void SetCanClose()
    {
        canClose = true;
        CloseAll();
    }

    internal void Open()
    {
        /* da riattivare
        ++amoutOpen;
        if (!amIOpen)
        {
            shoulICount = true;
            number = 0;

            //Time.timeScale = 0;
            amIOpen = true;
            panel.SetActive(true);
        }
        */
    }

    internal void Close()
    {
        /* da riattivare
        --amoutOpen;
        CloseAll();
        */
    }

    private void CloseAll()
    {
        if (amoutOpen == 0 && canClose)
        {
            amIOpen = false;
            MenuManager.instance.CloseAllMenus();
            //Time.timeScale = 1;
            panel.SetActive(false);

            canClose = false;
        }
    }

}
