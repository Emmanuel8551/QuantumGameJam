using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, Interactable
{
    [SerializeField] private SpriteRenderer _sr;
    public string[] Dialogos;
    
    public void Interact ()
    {
        DialogManager.Instance.SetDialogos(Dialogos);
    }

    public void Highlight ()
    {
        _sr.color = Color.red;
    }

    public void UnHighlight ()
    {
        _sr.color = Color.white;
    }
}

public interface Interactable
{
    public void Interact();

    public void Highlight();

    public void UnHighlight();
}