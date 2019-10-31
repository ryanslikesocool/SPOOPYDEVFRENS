using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ifelse.Easings;

public class PopupBox : MonoBehaviour
{
    [SerializeField]
    private GhostData information;

    [SerializeField]
    private Transform canvasTransform;
    [SerializeField]
    private TextMeshProUGUI textAreaTwitter;
    private TextMeshProUGUI textAreaName;

    private Vector3 initialCanvasScale;
    private Interpolator scaleInterpolator = new Interpolator(EasingType.BackOut);

    private Coroutine scaleCoroutine = null;

    void Start()
    {
        initialCanvasScale = canvasTransform.localScale;
        canvasTransform.localScale = Vector3.zero;
        textAreaName = canvasTransform.Find("Name").GetComponent<TextMeshProUGUI>();
        textAreaTwitter = canvasTransform.Find("Link").GetComponent<TextMeshProUGUI>();
        textAreaTwitter.text = string.IsNullOrEmpty(information.twitter) ? "" : information.twitter;
        textAreaName.text = information.discord;
    }

    void CancelScale()
    {
        if (scaleCoroutine != null)
        {
            StopCoroutine(scaleCoroutine);
        }
    }

    public void OpenBox()
    {
        CancelScale();
        scaleCoroutine = StartCoroutine(TransitionBox(1, initialCanvasScale, EasingType.BackOut));
    }

    public void CloseBox()
    {
        CancelScale();
        scaleCoroutine = StartCoroutine(TransitionBox(1, Vector3.zero, EasingType.BackIn));
    }

    IEnumerator TransitionBox(float duration, Vector3 targetScale, EasingType easing)
    {
        Vector3 initialScale = canvasTransform.localScale;
        scaleInterpolator.SetFunction(easing);
        scaleInterpolator.Begin(0, 1, duration);
        while (!scaleInterpolator.Done)
        {
            scaleInterpolator.Update();
            canvasTransform.localScale = Vector3.LerpUnclamped(initialScale, targetScale, scaleInterpolator.Value);
            yield return null;
        }
        canvasTransform.localScale = targetScale;

        scaleCoroutine = null;
    }
}