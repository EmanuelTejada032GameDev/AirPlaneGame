using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{

    private Rigidbody2D _rigidbody;
    [SerializeField]
    private float _movementSpeed = 2;

    [SerializeField]
    private float _rotationSpeed = 2;

    public Transform target;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
        _rigidbody.velocity = (target.position - transform.position).normalized * _movementSpeed;
        //transform.LookAt(target, Vector3.up);

    }

}
