using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : Collectable, IScaleUp
{
    [SerializeField] float _scale;

    float IScaleUp.ScaleValue { get => _scale ; set => _scale = value; }

    public override void Collect()
    {
        base.Collect();
        IScaleUp scaleUp = this;
        scaleUp.ScaleUp();
    }
}
