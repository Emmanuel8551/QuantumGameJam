using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float _interactRadius;
    [SerializeField] private GameObject _interactKeyIcon;
    [SerializeField] private LayerMask _layerMask;
    private Interactable _lastInteractable;
    private Player _player;
    private bool _isInteracting;
    private Interactable interactable;
    [SerializeField] private GameObject future, past;


    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {

        Interactable aux = GetInteractedObject();
        if (aux != interactable)
        {
            interactable = aux;

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

            _interactKeyIcon.SetActive(_isInteracting);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            interactable?.Interact();
        }
    }
    
    private Interactable GetInteractedObject ()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, _interactRadius, Vector2.zero, 0, _layerMask);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.TryGetComponent(out Interactable interactable))
            {
                return interactable;       
            }
        }
        return null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _interactRadius);
    }
}
