using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static List<Door> Doors = new List<Door>();
    [SerializeField] private int nextRoomIndex;
    [SerializeField] private float _detectRadius;
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private int _doorIndex;
    [SerializeField] private int _targetIndex;

    private void OnEnable()
    {
        Doors.Add(this);
    }

    private void OnDisable()
    {
        Doors.Remove(this);
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, _detectRadius, Vector2.zero, 0, _targetMask);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.TryGetComponent(out Player player))
            {
                LevelLoader.Instance.ChangeRoomPair(nextRoomIndex);
                Door targetDoor = Doors.Find(d => d._doorIndex == _targetIndex);
                if (targetDoor != null)
                {
                    Vector3 diff = targetDoor.transform.position - player.transform.position;
                    Player.PlayerPast.transform.position += diff;
                    Player.PlayerFuture.transform.position += diff;
                }

            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _detectRadius);
    }
}
