using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float _interactRadius;
    private Interactable _lastInteractable;
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (!_player.IsControlling)
        {
            _lastInteractable?.UnHighlight();
            return;
        }

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, _interactRadius, Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.TryGetComponent(out Interactable interactable))
            {
                _lastInteractable = interactable;
                interactable.Highlight();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
        }
        else
        {
            _lastInteractable?.UnHighlight();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _interactRadius);
    }
}
