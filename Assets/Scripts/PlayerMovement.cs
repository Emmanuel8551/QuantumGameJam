using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rb;
    private Player _player;

    //public bool IsMoving => _player.IsControlling;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    void Update()
    {
        
        Vector2 moveDir = Vector2.zero;
        /*if (!IsMoving)
        {
            _rb.velocity = Vector3.zero;
        }
        else
        {
            
        }*/

        int dir = 0;
        if (Input.GetKey(KeyCode.UpArrow)) dir += 3;
        if (Input.GetKey(KeyCode.DownArrow)) dir += 4;
        if (Input.GetKey(KeyCode.RightArrow)) dir += 5;
        if (Input.GetKey(KeyCode.LeftArrow)) dir += 6;

        switch (dir)
        {
            case 3:
                moveDir.y = 1;
                break;
            case 4:
                moveDir.y = -1;
                break;
            case 5:
                moveDir.x = 1;
                break;
            case 6:
                moveDir.x = -1;
                break;
        }
        moveDir.Normalize();
        _rb.velocity = moveDir * _speed;
        _player.IsWalking = moveDir != Vector2.zero;
        _player.MoveDir = moveDir;
    }

    public void setSpeed(float n)
    {
        _speed = n;
    }

}
