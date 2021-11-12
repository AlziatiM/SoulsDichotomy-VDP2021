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

    private void Awake()
    {
        Instantiate(gameManager, Vector3.zero, Quaternion.identity);
        Instantiate(skillManager, Vector3.zero, Quaternion.identity);
        GameObject go1 = Instantiate(player, startPoint.transform.position, Quaternion.identity);
        GameObject go2 = Instantiate(soul, startPoint.transform.position, Quaternion.identity);
        FindObjectOfType<Camera>().gameObject.transform.SetParent(go1.transform);
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
