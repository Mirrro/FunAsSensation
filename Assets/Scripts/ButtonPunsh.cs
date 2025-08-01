using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPunsh : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private float scale = 1;
    [SerializeField] private float duration = 1;
    [SerializeField] private int vibration = 1;
    [SerializeField] private float elasticity = 1;

    private Tween punsh;
    private void OnEnable()
    {
        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        punsh.Kill(true);
        punsh = transform.DOPunchScale(Vector3.one * scale, duration, vibration, elasticity).OnComplete(() => transform.localScale = Vector3.one);
    }
}
