using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public static Fader Instance;
    [SerializeField] private Image panel;
    private float fadeValue = 0;
    private float targetFade = 0;
    bool fading = false;

    private void OnEnable()
    {
        Instance = this;
    }

    private void OnDisable()
    {
        Instance = null;
    }

    private void Update()
    {
        fadeValue = Mathf.Lerp(fadeValue, targetFade, 0.015f);
        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, fadeValue);
        if (targetFade - fadeValue < 0.001f && fading) SceneManager.LoadScene(2);
    }

    public void FadeIn ()
    {
        fading = true;
        targetFade = 1;
    }

    public void FadeOut ()
    {
        targetFade = 0;
    }
}
