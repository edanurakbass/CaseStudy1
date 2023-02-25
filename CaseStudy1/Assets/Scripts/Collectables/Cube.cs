using System;
using UnityEngine;

public class Cube : Collectable, IScoreAdder
{
    [SerializeField]
    private int _scoreToAdd;

    int IScoreAdder.Score { get => _scoreToAdd; set => _scoreToAdd = value; }

    public override void Collect()
    {
        base.Collect();
        IScoreAdder adder = this;
        adder.AddScore();
    }
}
