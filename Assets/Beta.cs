using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Beta : MonoBehaviour
{
    private static float MusicVolume = 1f, Efectos = 1f;
    public Slider musicVolume, effectsVolume;
    public AudioSource audioSource;

    public void setMusica()
    {
        MusicVolume = musicVolume.value;
        audioSource.volume = MusicVolume;
    }

    public static float getMusicVolume()
    {
        return MusicVolume;
    }

    public void setEfectos()
    {
        Efectos = effectsVolume.value;
    }

    public void ChangeSceneGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    void Start()
    {
        audioSource.Play();
        audioSource.volume = MusicVolume;
    }

}