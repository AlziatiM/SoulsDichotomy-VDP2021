using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    [Header("Inputs")]
    public KeyCode switchCharacterInput;

    public delegate void OnChangeCharacter();
    public static OnChangeCharacter changeCharacter;
    
    //caching
    private CinemachineVirtualCamera _vc;
    private Transform playerTransf;
    private Transform soulTransf;
    public static GameManager instance;
    
    // Start is called before the first frame update
    void Awake()
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
    }

    private void Start()
    {
        playerTransf = GameObject.FindWithTag("Player").GetComponent<Transform>();
        soulTransf = GameObject.FindWithTag("Soul").GetComponent<Transform>();
        _vc =CinemachineCore.Instance.GetActiveBrain(0).ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();;
        _vc.Follow = playerTransf;
        changeCharacter += SwitchCamera;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(switchCharacterInput))
        {
            changeCharacter();
            
        }   
    }

    void SwitchCamera()
    {
        if (_vc.Follow == playerTransf)
        {
            _vc.Follow = soulTransf;
        }
        else
        {
            _vc.Follow = playerTransf;
        }
    }

    public KeyCode GetSwitchCharacterInput()
    {
        return switchCharacterInput;
    }
}
