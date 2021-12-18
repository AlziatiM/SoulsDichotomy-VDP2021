using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour, IReact
{
    [SerializeField] private float timeBetweenBullets;
    [SerializeField] private bool amIActive;
    [SerializeField] private bool whenActiveAlwaysShot;
    [SerializeField] private int numOfBullet;
    public GameObject bullet;
    public GameObject firePoint;

    private void OnValidate()
    {
        if (whenActiveAlwaysShot)
        {
            numOfBullet = 0;
        }
    }

    private void Start()
    {
        if (amIActive)
        {
            StartCoroutine("StartShot");
        }
    }

    public void React()
    {
        amIActive = !amIActive;
        if (amIActive)
        {
            StartCoroutine("StartShot");
        }
        else
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator StartShot()
    {
        if (whenActiveAlwaysShot)
        {
            while (true)
            {
                Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                yield return new WaitForSeconds(timeBetweenBullets);
            }
        }
        else
        {
            int cont = 0;
            while (cont < numOfBullet)
            {
                Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                yield return new WaitForSeconds(timeBetweenBullets);
                cont++;
            }
            amIActive = false;
        }
        
    }

}
