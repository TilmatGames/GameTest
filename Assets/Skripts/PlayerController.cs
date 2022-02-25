using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _moveSpeed ;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Camera _cam;
    Vector2 movement;
    Vector2 mousePos;
    void Start() 
    {
        _moveSpeed = SettingLVL.SpeedPlayer;
    }
    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");     
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + movement * _moveSpeed * Time.fixedDeltaTime);
    }
}