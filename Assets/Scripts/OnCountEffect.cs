using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class OnCountEffect : MonoBehaviour
{
    [SerializeField] private Color OnCountColor;
    [SerializeField] private float duration = .5f;
    [SerializeField] private Counter counter;
    [SerializeField] private TMP_Text textfield;
    private Color initialColor;
    private Tween colorTween;
    private Tween scaleTween;
    
    private void Start()
    {
        initialColor = textfield.color;
    }

    private void OnEnable()
    {
        counter.OnCount.AddListener(OnCounterCount);
    }

    private void OnDisable()
    {
        counter.OnCount.RemoveListener(OnCounterCount);
    }

    private void OnCounterCount()
    {
        ColorFlash(OnCountColor, .1f);
        ScaleShake(.1f);
    }

    private void ColorFlash(Color color, float duration)
    {
        colorTween.Kill(true);
        colorTween = textfield.DOColor(color, duration / 2).SetLoops(1, LoopType.Yoyo)
            .OnComplete(() => textfield.color = initialColor);
    }

    private void ScaleShake(float power)
    {
        scaleTween.Kill(true);
        scaleTween = transform.DOShakeScale(duration, power).OnComplete(() => transform.localScale = Vector3.one);
    }
}
