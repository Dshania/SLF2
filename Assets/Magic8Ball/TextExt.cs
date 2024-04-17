using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class TextExt
{
    public static void SetText(this TMP_Text text, float value)
    {
        Color original = text.color;
        original.a = value;
        text.color = original;
    }

    public static void SetScale(this TMP_Text text, float scale)
    {
        var size = new Vector3(scale, scale, scale);
        text.gameObject.transform.localScale = size;
    }
}
