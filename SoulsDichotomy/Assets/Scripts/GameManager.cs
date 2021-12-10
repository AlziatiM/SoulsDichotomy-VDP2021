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
    private bool gameOver;
    
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
        gameOver = false;
        StartCoroutine("StartWithDelay");   
    }

    private IEnumerator StartWithDelay()
    {
        yield return new WaitUntil(() => GameObject.FindWithTag("Player") != null);
        yield return new WaitUntil(() => GameObject.FindWithTag("Soul") != null);
        GameObject player = GameObject.FindWithTag("Player");
        GameObject soul = GameObject.FindWithTag("Soul");
        SkillManager.instance.SetUpCharacters(player.GetComponent<PlayerInput>(), soul.GetComponent<SoulController>());
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(soul);
        playerTransf = player.GetComponent<Transform>();
        soulTransf = soul.GetComponent<Transform>();
        _vc = CinemachineCore.Instance.GetActiveBrain(0).ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
        _vc.Follow = playerTransf;
        changeCharacter += SwitchCamera;
        MenuManager.gameOver += DestroyAllBeforLoadMainScene;
        CustomizeInput.ChangeInput += ChangeCustomizeInput;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            InGameMenu.instance.TogglePause();
        }
        if (gameOver || InGameMenu.instance.isPaused)
            return;
        if (Input.GetKeyDown(switchCharacterInput))
        {
            changeCharacter();
        }
        /*
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.instance.Open(SkillMenu.instance);
        }
        */
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


    public void SetTransforOfCharacter(Vector3 newPos)
    {
        playerTransf.position = newPos;
        soulTransf.position = newPos;
    }

    private void DestroyAllBeforLoadMainScene()
    {
        Destroy(playerTransf.gameObject);
        Destroy(soulTransf.gameObject);
        Destroy(SkillManager.instance.gameObject);
        Destroy(SkillMenu.instance.gameObject);
        Destroy(UIManager.instance.gameObject);
        Destroy(InGameMenu.instance.gameObject);
        //da problemi
        //Destroy(CinemachineCore.Instance.GetActiveBrain(0).ActiveVirtualCamera.VirtualCameraGameObject);
        Destroy(LevelManager.instance.gameObject);
        Destroy(this.gameObject);
    }

    
    private void OnDestroy()
    {
        MenuManager.gameOver -= DestroyAllBeforLoadMainScene;
        CustomizeInput.changeInput -= ChangeCustomizeInput;

    }

    public void SomeoneDie()
    {
        playerTransf.gameObject.GetComponent<PlayerVelocity>().enabled = false;
        playerTransf.gameObject.GetComponent<PlayerInput>().GameOver = true;
        soulTransf.gameObject.GetComponent<SoulController>().GameOver = true;
        gameOver = true;
        GameOverMenu.instance.LevelFailed();
        MenuManager.instance.GameOver();
    }
    public void TryAgainSetup()
    {
        gameOver = false;
        playerTransf.gameObject.GetComponent<PlayerInput>().ResetPlayer();
        soulTransf.gameObject.GetComponent<SoulController>().ResetSoul();
        _vc.Follow = playerTransf;
    }

    private void ChangeCustomizeInput(KeyCode up, KeyCode down, KeyCode right, KeyCode left, KeyCode interact, KeyCode switchChar)
    {
        switchCharacterInput = switchChar;
    }

}
