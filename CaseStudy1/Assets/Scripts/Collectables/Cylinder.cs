using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : Collectable, IScaleUp, IScoreAdder
{
    [SerializeField]
    private int _scoreToAdd;
    [SerializeField]
    private float _scaleToAdd;

    float IScaleUp.ScaleValue { get => _scaleToAdd; set => _scaleToAdd = value; }
    int IScoreAdder.Score { get => _scoreToAdd; set => _scoreToAdd = value; }

    public override void Collect()
    {
        base.Collect();

        IScaleUp scaleUp = this;
        scaleUp.ScaleUp();

        IScoreAdder scoreAdder = this;
        scoreAdder.AddScore();
    }
}
