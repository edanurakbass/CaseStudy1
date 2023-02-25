using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScaleUp
{
    static Action<float> OnScaleUp { get; set; }

    float ScaleValue { get; protected set; }

    void ScaleUp()
    {
        OnScaleUp?.Invoke(ScaleValue);
    }
}
