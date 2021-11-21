using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelStarter : MonoBehaviour
{

    [Header("ToTest")]
    public GameObject gameManager;
    public GameObject skillManager;
    public GameObject player;
    public GameObject soul;
    public GameObject cameraFollow;

    [Header("Menu only available in game")]
    public GameObject skillMenu;

    private void Awake()
    {
        Transform enterLevel = GameObject.FindGameObjectWithTag("EnterLevel").transform;
        if (GameManager.instance == null)
        {
            Instantiate(player, enterLevel.position, Quaternion.identity);
            Instantiate(soul, enterLevel.position, Quaternion.identity);
            DontDestroyOnLoad(Instantiate(cameraFollow, Vector3.zero, Quaternion.identity));
            Instantiate(skillMenu, Vector3.zero, Quaternion.identity);
        }
        else
        {
            GameManager.instance.SetTransforOfCharacter(enterLevel.position);
        }
        Instantiate(gameManager, Vector3.zero, Quaternion.identity);
        Instantiate(skillManager, Vector3.zero, Quaternion.identity);
        
    }

}
