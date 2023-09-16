using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float _interactRadius;
    [SerializeField] private GameObject _interactKeyIcon;
    private Interactable _lastInteractable;
    private Player _player;
    private bool _isInteracting;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (!_player.IsControlling)
        {
            _isInteracting = false;
            _lastInteractable?.UnHighlight();
        }
        else
        {
            Interactable interactable = GetInteractedObject();
            if (interactable != null)
            {
                _lastInteractable = interactable;
                interactable.Highlight();
                _isInteracting = true;
            }
            else
            {
                _isInteracting = false;
                _lastInteractable?.UnHighlight();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                interactable.Interact();
            }
        }

        _interactKeyIcon.SetActive(_isInteracting);
    }

    private Interactable GetInteractedObject ()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, _interactRadius, Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.TryGetComponent(out Interactable interactable))
            {
                return interactable;       
            }
        }
        return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _interactRadius);
    }
}
