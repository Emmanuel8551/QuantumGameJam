using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance { get; private set; }
    [SerializeField] private GameObject panelPast, panelFuture, playerPast, playerFuture;
    public static bool runningDialog=false;

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
            Dialog past = panelPast.GetComponent<Dialog>();
            Dialog future = panelFuture.GetComponent<Dialog>();
            if (!past.isActiveAndEnabled && !future.isActiveAndEnabled) //algún diálogo se activa
            {
                bool aux1 = playerPast.GetComponent<PlayerInteraction>().UseInteractable();
                bool aux2 = playerFuture.GetComponent<PlayerInteraction>().UseInteractable();
                if(aux1==true || aux2 == true)
                {
                    runningDialog = true;
                    playerPast.GetComponent<PlayerMovement>().setSpeed(0);
                    playerFuture.GetComponent<PlayerMovement>().setSpeed(0);
                }
            }
            else if (isWriting(panelPast) || isWriting(panelFuture)) //algún diálogo está printeando
            {
                panelPast.GetComponent<Dialog>().SkipText();
                panelFuture.GetComponent<Dialog>().SkipText();
            }
            else //ambos díálogos ya terminaron de printear
            {
                panelPast.GetComponent<Dialog>().NextDialog();
                panelFuture.GetComponent<Dialog>().NextDialog();
                if (!past.isActiveAndEnabled && !future.isActiveAndEnabled)
                {
                    playerPast.GetComponent<PlayerMovement>().setSpeed(5);
                    playerFuture.GetComponent<PlayerMovement>().setSpeed(5);
                    runningDialog = false;
                }
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

    public void SetDialogos(bool izq, string[] dialogos, int paso)
    {
        if(izq == true)
        {
            panelPast.GetComponent<Dialog>().SetDialogos(dialogos, paso);
        }
        else
        {
            panelFuture.GetComponent<Dialog>().SetDialogos(dialogos, paso);
        }
    }

}