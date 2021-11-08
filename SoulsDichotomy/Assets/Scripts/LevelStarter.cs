using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelStarter : MonoBehaviour
{

    [Header("ToTest")]
    public GameObject gameManager;
    public GameObject player;
    public GameObject soul;
    public GameObject startPoint;

    private void Awake()
    {
        Instantiate(gameManager, Vector3.zero, Quaternion.identity);
        GameObject go = Instantiate(player, startPoint.transform.position, Quaternion.identity);
        Instantiate(soul, startPoint.transform.position, Quaternion.identity);
        FindObjectOfType<Camera>().gameObject.transform.SetParent(go.transform);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
