using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Beta : MonoBehaviour
{
    private static float Musica = 100, Efectos = 100;
    public Slider musicVolume, effectsVolume;

    public void setMusica()
    {
        Musica = musicVolume.value;
    }

    public static float getMusica()
    {
        return Musica;
    }

    public void setEfectos()
    {
        Efectos = effectsVolume.value;
    }

    public void ChangeSceneGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }

}