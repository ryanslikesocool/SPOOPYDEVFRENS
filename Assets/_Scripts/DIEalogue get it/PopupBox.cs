using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ifelse.Easings;

public class PopupBox : MonoBehaviour
{
    [SerializeField]
    private Transform canvasTransform = null;

    private Interpolator scaleInterpolator = new Interpolator(EasingType.BackOut);

    IEnumerator TransitionBox(float duration, EasingType easing)
    {
        scaleInterpolator.SetFunction(easing);
        scaleInterpolator.Begin(0, 1, duration);
        while (!scaleInterpolator.Done)
        {
            scaleInterpolator.Update();



            yield return null;
        }
    }
}