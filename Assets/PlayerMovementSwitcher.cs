using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSwitcher : MonoBehaviour
{
    [SerializeField] private Player playerPast;
    [SerializeField] private Player playerFuture;

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
    }
}
