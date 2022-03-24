using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 _movementVector;

    [SerializeField]
    private float _movementSpeed = 2;
    [SerializeField] 
    private float _rotationSpeed = 2;
    [SerializeField] 
    private float _maxSpeed = 4;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();   
    }

    private void Update()
    {
        
    }
    private void OnMove(InputValue inputSystemValueOnMove)
    {
        _movementVector = inputSystemValueOnMove.Get<Vector2>();
    }
    private void FixedUpdate()
    {
        _rigidbody.rotation -= _movementVector.x * _rotationSpeed;
        _movementSpeed = Mathf.Clamp(_movementSpeed + _movementVector.y , 1.5f, _maxSpeed);
        _rigidbody.velocity = transform.up * _movementSpeed;
    }

    

}
