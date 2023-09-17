using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance { get; private set; }
    [SerializeField] private GameObject panelPast, panelFuture;

    void Awake()
    {
        Instance = this;
        panelPast.GetComponent<Dialog>().SetTextMessage();
        panelFuture.GetComponent<Dialog>().SetTextMessage();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isWriting(panelPast) || isWriting(panelFuture))
            {
                panelPast.GetComponent<Dialog>().SkipText();
                panelFuture.GetComponent<Dialog>().SkipText();
            }
            else
            {
                panelPast.GetComponent<Dialog>().NextDialog();
                panelFuture.GetComponent<Dialog>().NextDialog();
            }
        }
    }

    private bool isWriting(GameObject panel)
    {
        if(panel.GetComponent<Dialog>().isWriting())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetDialogos(bool izq, string[] dialogos)
    {
        if(izq == true)
        {
            panelPast.GetComponent<Dialog>().SetDialogos(dialogos);
        }
        else
        {
            panelFuture.GetComponent<Dialog>().SetDialogos(dialogos);
        }
    }

}