using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, Interactable
{
    private static int Progreso;

    public int[] niveles;
    public string[] Antes;
    public int paso;
    public string[] Despues;

    private SpriteRenderer _sr;


    void Start()
    {
        if (niveles.Length==0 || Includes(niveles, LevelLoader.Nivel))
        {
            Progreso = 0; //mover
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private bool Includes(int[] niveles, int Nivel)
    {
        for (int i = 0; i < niveles.Length; i++)
        {
            if (niveles[i] == Nivel)
            {
                return true;
            }
        }
        return false;
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
        DialogManager.Instance.SetDialogos((transform.position.x <= 0) ? true : false, diag, paso);
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
        if (_sr != null)
        _sr.color = Color.white;
    }

}

public interface Interactable
{
    public void Interact();

    public void Highlight();

    public void UnHighlight();

}