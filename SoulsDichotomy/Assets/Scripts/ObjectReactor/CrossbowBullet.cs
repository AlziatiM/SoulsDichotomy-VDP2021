using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowBullet : MonoBehaviour
{

    [SerializeField] private int moveSpeed;
    private Rigidbody2D _rigidbody;
    private Transform _transform;
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _transform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity = _transform.right * -moveSpeed;
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    
    public void AfterApplyDamage()
    {
        Destroy(this.gameObject);
    }

}
