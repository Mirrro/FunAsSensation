using DG.Tweening;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Counter))]
public class OnTenEffect : MonoBehaviour
{
    [SerializeField] private Color color;
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
        counter.OnTen.AddListener(OnCounterTen);
    }

    private void OnDisable()
    {
        counter.OnTen.RemoveListener(OnCounterTen);
    }

    private void OnCounterTen()
    {
        ColorFlash();
        ScaleShake();
    }

    private void ColorFlash()
    {
        colorTween.Kill(true);
        colorTween = textfield.DOColor(color, duration / 2).SetLoops(1, LoopType.Yoyo)
            .OnComplete(() => textfield.color = initialColor);
    }

    private void ScaleShake()
    {
        scaleTween.Kill(true);
        scaleTween = transform.DOShakeScale(duration, 1).OnComplete(() => transform.localScale = Vector3.one);
    }
}
