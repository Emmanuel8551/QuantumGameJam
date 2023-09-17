using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField] private bool _isControlling;

    //public bool IsControlling { get => _isControlling; set => _isControlling = value; }
    public bool IsWalking { get; set; }
    public Vector2 MoveDir { get; set; }
}
