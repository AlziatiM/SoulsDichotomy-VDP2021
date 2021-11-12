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
    private CinemachineVirtualCamera camera_vc;
    
    private void Awake()
    {
        Instantiate(gameManager, Vector3.zero, Quaternion.identity);
        Instantiate(skillManager, Vector3.zero, Quaternion.identity);
        GameObject go1 = Instantiate(player, startPoint.transform.position, Quaternion.identity);
        GameObject go2 = Instantiate(soul, startPoint.transform.position, Quaternion.identity);
        camera_vc = Instantiate(cameraFollow, Vector3.zero, Quaternion.identity).GetComponent<CinemachineVirtualCamera>();
        SkillManager.instance.SetUpCharacters(go1.GetComponent<PlayerInput>(), go2.GetComponent<SoulController>());
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
