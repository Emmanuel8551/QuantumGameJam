using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    private TextMeshProUGUI txtMessage;
    private string _targetText;
    private float _charCount;
    private List<string> Dialogos = new();
    private int paso;

    public void SetTextMessage()
    {
        txtMessage = GetComponentInChildren<TextMeshProUGUI>();
    }
    
    void Update()
    {
        if (txtMessage.text != _targetText)
        {
            _charCount = Mathf.Min(_charCount + Time.deltaTime * 60, _targetText.Length);
            txtMessage.text = _targetText.Substring(0, (int)_charCount);
        }
    }

    public bool isWriting()
    {
        if(gameObject.activeSelf && txtMessage.text != _targetText)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void NextDialog()
    {
        if(Dialogos.Count > 0)
        {
            ShowText();
        }
        else
        {
            Hide();
        }
    }

    public void SkipText()
    {
        txtMessage.text = _targetText;
    }

    public void SetDialogos(string[] dialogos, int paso)
    {
        if (!gameObject.activeSelf || (gameObject.activeSelf && this.paso != paso)) {
            this.paso = paso;
            if (dialogos != null)
            {
                Dialogos.Clear();
                for (int i = 0; i < dialogos.Length; i++)
                {
                    Dialogos.Add(dialogos[i]);
                }
            }
            ShowText();
        }
    }
    
    public void ShowText()
    {
        txtMessage.text = "";
        string text;
        if (Dialogos.Count > 0)
        {
            text = Dialogos[0];
            Dialogos.RemoveAt(0);
        }
        else
        {
            text = "ERROR. NO HAY TEXTO ASIGNADO";
        }
        _charCount = 0;
        Show();
        _targetText = text + "      ";
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}