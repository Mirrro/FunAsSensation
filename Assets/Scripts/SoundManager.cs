using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource hitSource;
    [SerializeField] private AudioSource digSource;
    [SerializeField] private AudioSource disappearSource;
    [SerializeField] private Mole mole;

    private void OnEnable()
    {
        mole.OnHit.AddListener(PlayHit);
        mole.OnAppear.AddListener(PlayDigSound);
        mole.OnHide.AddListener(PlayDisappearSound);
    }

    private void OnDisable()
    {
        mole.OnHit.RemoveListener(PlayHit);
        mole.OnAppear.RemoveListener(PlayDigSound);
        mole.OnHide.RemoveListener(PlayDisappearSound);
    }

    private IEnumerator PlayHitDelayed()
    {
        yield return new WaitForSeconds(.3f);
        hitSource.Play();
    }

    private void PlayHit(Mole _)
    {
        StartCoroutine(PlayHitDelayed());
    }

    private void PlayDigSound(Mole _)
    {
        digSource.Play();
    }

    private void PlayDisappearSound(Mole _)
    {
        disappearSource.Play();
    }
}
