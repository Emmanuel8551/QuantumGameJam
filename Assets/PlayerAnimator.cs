using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private const string isWalkingKey = "IsWalking";
    private Animator _animator;
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _txtState;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _txtState.text = GetStateAsText();
        _animator.SetBool(isWalkingKey, _player.IsWalking);
        _animator.SetFloat("Vertical", (int)_player.MoveDir.y);
        _animator.SetFloat("Horizontal", (int)_player.MoveDir.x);
    }

    private string GetStateAsText ()
    {
        string state = "";

        if (_player.IsWalking) state += "Walking";
        else state += "Idle";

        if (_player.MoveDir.x > 0) state += " - Right";
        else if (_player.MoveDir.x < 0) state += " - Left";
        else if (_player.MoveDir.y > 0) state += " - Up";
        else if (_player.MoveDir.y < 0) state += " - Down";

        return state;
    }
}
