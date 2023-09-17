using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSwitcher : MonoBehaviour
{
    //[SerializeField] private Player playerPast;
    //[SerializeField] private Player playerFuture;
    public AudioSource future; //, past;
    //private float musicCrossfade;
    //private float targetCrossfade;

    //private const float FUTURE_CROSSFADE = 1;
    //private const float PAST_CROSSFADE = 0;

    private void Start()
    {
        //musicCrossfade = FUTURE_CROSSFADE;
        //future.Play();
        //past.Play();
        future.Play();
    }

    /*void Update()
    {
        musicCrossfade = Mathf.Lerp(musicCrossfade, targetCrossfade, 0.015f);

        float difference = Mathf.Abs(musicCrossfade - FUTURE_CROSSFADE);
        future.volume = Beta.getMusicVolume() * (1 - difference);

        difference = Mathf.Abs(musicCrossfade - PAST_CROSSFADE);
        past.volume = Beta.getMusicVolume() * (1 - difference);

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
        targetCrossfade = FUTURE_CROSSFADE;
    }

    private void PlayPast()
    {
        targetCrossfade = PAST_CROSSFADE;
    }*/

}
