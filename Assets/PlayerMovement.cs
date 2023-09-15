using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rb;
    private Player _player;

    public bool IsMoving => _player.IsControlling;


    private void Start()
    {
        _player = GetComponent<Player>();
    }

    void Update()
    {
        
        Vector2 moveDir = Vector2.zero;
        if (!IsMoving)
        {
            _rb.velocity = Vector3.zero;
        }
        else
        {      
            if (Input.GetKey(KeyCode.UpArrow)) moveDir.y = 1;
            else if (Input.GetKey(KeyCode.DownArrow)) moveDir.y = -1;
        
            else if (Input.GetKey(KeyCode.RightArrow)) moveDir.x = 1;
            else if (Input.GetKey(KeyCode.LeftArrow)) moveDir.x = -1;

            moveDir.Normalize();
            _rb.velocity = moveDir * _speed;
        }

        _player.IsWalking = moveDir != Vector2.zero;
        _player.MoveDir = moveDir;
    }
}
