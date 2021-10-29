using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    [Header("Inputs")]
    public KeyCode switchCharacterInput;

    public delegate void OnChangeCharacter();
    public static OnChangeCharacter changeCharacter;

    public static GameManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(switchCharacterInput))
        {
            changeCharacter();
        }   
    }

    public KeyCode GetSwitchCharacterInput()
    {
        return switchCharacterInput;
    }
}
