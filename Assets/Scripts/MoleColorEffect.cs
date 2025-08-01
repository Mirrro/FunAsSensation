using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoleColorEffect : MonoBehaviour
{
    [SerializeField] private Mole mole;
    [SerializeField] private Renderer renderer;

    private void OnEnable()
    {
        mole.OnHit.AddListener(StartColorEffect);
    }

    private void OnDisable()
    {
        mole.OnHit.RemoveListener(StartColorEffect);
    }

    private void StartColorEffect(Mole _)
    {
        StopAllCoroutines();
        StartCoroutine(ColorEffectDelayed());
    }

    private IEnumerator ColorEffectDelayed()
    {
        yield return new WaitForSeconds(.3f);
        ColorFlash();
    }

    private void ColorFlash()
    {
        renderer.material.DOColor(Color.red, .3f).OnComplete(() => renderer.material.DOColor(Color.white, .3f));
    }
}
