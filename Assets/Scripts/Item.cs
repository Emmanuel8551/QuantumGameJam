using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, Interactable
{
    private static int Progreso;
    
    public string[] Antes;
    private int paso;
    public string[] Despues;

    private SpriteRenderer _sr;


    static void Start()
    {
        Progreso = 0;
    }
    
    void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    public void Interact ()
    {
        ref string[] diag = ref Antes;
        if (Progreso >= paso)
        {
            diag = ref Despues;
        }
        DialogManager.Instance.SetDialogos((transform.position.x <= 0)?true:false, diag, paso);
        if (paso == Progreso)
        {
            Progreso += 1;
        }
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