using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CurveFactory
{
 public static AnimationCurve Create(float startVal, float endVal)
    {
        var curve = new AnimationCurve();
        curve.AddKey(0f, startVal);
        curve.AddKey(1f, endVal);

        return curve;
    }
}
