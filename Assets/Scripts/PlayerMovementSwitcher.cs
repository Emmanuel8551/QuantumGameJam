using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSwitcher : MonoBehaviour
{
    [SerializeField] private Player playerPast;
    [SerializeField] private Player playerFuture;
    public AudioSource future, past;

    private void Start()
    {
        future.Play();
        past.Play();
        PlayFuture();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleMovementFocus();
        }
    }

    private void ToggleMovementFocus ()
    {
        playerFuture.IsControlling = playerPast.IsControlling;
        playerPast.IsControlling = !playerPast.IsControlling;
        if (playerFuture.IsControlling)
        {
            PlayFuture();
        }
        else
        {
            PlayPast();
        }
    }

    private void PlayFuture()
    {
        future.volume = Beta.getMusica();
        past.volume = 0f;
    }

    private void PlayPast()
    {
        past.volume = Beta.getMusica();
        future.volume = 0f;
    }

}
