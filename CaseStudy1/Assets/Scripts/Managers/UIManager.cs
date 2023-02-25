using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _bluePlayerScoreTMP;
    [SerializeField]
    private TextMeshProUGUI _greenPlayerScoreTMP;

    private TextMeshProUGUI _selectedPlayerScoreTMP;

    private void Start()
    {
        _selectedPlayerScoreTMP = _bluePlayerScoreTMP;
    }

    private void OnEnable()
    {
        Player.OnChangeCharacter += HandleChangeCharacter;
        Player.OnScoreAdded = HandleUpdateScore;
    }
    private void OnDisable()
    {
        Player.OnChangeCharacter += HandleChangeCharacter;
        Player.OnScoreAdded = HandleUpdateScore;
    }

    private void HandleChangeCharacter()
    {
        if (_selectedPlayerScoreTMP = _bluePlayerScoreTMP)
            _selectedPlayerScoreTMP = _greenPlayerScoreTMP;
        else
            _selectedPlayerScoreTMP = _bluePlayerScoreTMP;
    }

    private void HandleUpdateScore(int score)
    {
        _selectedPlayerScoreTMP.text = $"{score}";
    }
}
