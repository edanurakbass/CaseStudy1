using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera _cmVcam;
    [SerializeField]
    private Player[] _players;

    private void OnEnable()
    {
        Player.OnChangeCharacter += HandleChangeCharacter;
    }

    private void OnDisable()
    {
        Player.OnChangeCharacter -= HandleChangeCharacter;

    }

    private void HandleChangeCharacter()
    {
        foreach (var player in _players)
        {
            if (player.IsSelected)
            {
                _cmVcam.Follow = player.transform;
                _cmVcam.LookAt = player.transform;
                return;
            }
        }
    }
}
