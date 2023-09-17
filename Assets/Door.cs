using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sr;
    [SerializeField] private int nextRoomIndex;
    [SerializeField] private float _detectRadius;
    [SerializeField] private LayerMask _targetMask;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, _detectRadius, Vector2.zero, 0, _targetMask);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.TryGetComponent(out Player player))
            {
                LevelLoader.Instance.ChangeRoomPair(nextRoomIndex);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _detectRadius);
    }
}
