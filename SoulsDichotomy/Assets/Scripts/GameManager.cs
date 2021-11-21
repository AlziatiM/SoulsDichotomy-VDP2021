using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour, IReact
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
        GameObject player = GameObject.FindWithTag("Player");
        GameObject soul = GameObject.FindWithTag("Soul");
        SkillManager.instance.SetUpCharacters(player.GetComponent<PlayerInput>(), soul.GetComponent<SoulController>());
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(soul);
        playerTransf = player.GetComponent<Transform>();
        soulTransf = soul.GetComponent<Transform>();
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.instance.Open(SkillMenu.instance);
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

    public void React()
    {
        throw new NotImplementedException();
    }

    public void SetTransforOfCharacter(Vector3 newPos)
    {
        playerTransf.position = newPos;
        soulTransf.position = newPos;
    }
}
