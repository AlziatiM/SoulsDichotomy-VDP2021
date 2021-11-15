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
    public GameObject startPoint;
    public GameObject cameraFollow;
    
    private void Awake()
    {
        if (GameManager.instance == null)
        {
            GameObject go1 = Instantiate(player, startPoint.transform.position, Quaternion.identity);
            GameObject go2 = Instantiate(soul, startPoint.transform.position, Quaternion.identity);
        }
        else
        {
            GameManager.instance.SetTransforOfCharacter(startPoint.transform.position);
        }
        Instantiate(gameManager, Vector3.zero, Quaternion.identity);
        Instantiate(skillManager, Vector3.zero, Quaternion.identity);
        Instantiate(cameraFollow, Vector3.zero, Quaternion.identity);
        
    }

}
