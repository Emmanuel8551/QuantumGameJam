using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI txtMessage;
    [SerializeField] private GameObject panel;
    private string _targetText;
    private float _charCount;
    private List<string> Dialogos = new();
    private bool isWriting;

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        if (panel.activeSelf)
        {
            if (txtMessage.text == _targetText)
            {
                isWriting = false;
            }
            _charCount = Mathf.Min(_charCount + Time.deltaTime * 60, _targetText.Length);
            txtMessage.text = _targetText.Substring(0, (int)_charCount);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Dialogos.Count <= 0 && !isWriting)
            {
                Hide();
            }
            else if(Dialogos.Count > 0)
            {
                ShowText();
            }
            else
            {
                txtMessage.text = _targetText;
            }
        }
    }

    public void ShowText ()
    {
        isWriting = true;
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
        _targetText = text;
    }

    public void Show ()
    {
        panel.SetActive (true);
    }

    public void Hide ()
    {
        panel.SetActive(false);
    }

    public void SetDialogos(string[] dialogos)
    {
        if (dialogos != null)
        {
            Dialogos.Clear();
            for(int i = 0; i < dialogos.Length; i++)
            {
                Dialogos.Add(dialogos[i]);
            }
        }
        ShowText();
    }
}
