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

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        if (panel.activeSelf)
        {
            _charCount = Mathf.Min(_charCount + Time.deltaTime * 60, _targetText.Length);
            txtMessage.text = _targetText.Substring(0, (int)_charCount);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Hide();
        }
    }

    public void ShowText (string text)
    {
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
}
