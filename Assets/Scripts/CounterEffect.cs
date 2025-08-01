using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CounterEffect : MonoBehaviour
{
    [SerializeField] private HitCounter counter;

    private void OnEnable()
    {
        counter.Increased.AddListener(Effect);
    }

    private void OnDisable()
    {
        counter.Increased.RemoveListener(Effect);
    }

    private void Effect()
    {
        transform.DOPunchScale(Vector3.one * 1.1f, .2f);
    }
}
