using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player PlayerPast;
    public static Player PlayerFuture;

    private void OnEnable()
    {
        if (transform.position.x < 0) PlayerPast = this;
        else PlayerFuture = this;
    }

    public bool IsWalking { get; set; }
    public Vector2 MoveDir { get; set; }
}
