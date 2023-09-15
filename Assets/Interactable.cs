using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sr;
    public void Interact ()
    {
        DialogManager.Instance.ShowText("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Consectetur a erat nam at lectus urna.");
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
