using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage :MonoBehaviour
{
    public int damage;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("trigger enter with dmg");
        IHittable hit = collision.GetComponent<IHittable>();
        if (hit != null)
        {
            //Debug.Log(hit);
            hit.Hit(damage);
        }
    }
}
