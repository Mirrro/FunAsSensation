using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] private List<Mole> moles;

    private void OnEnable()
    {
        foreach (var mole in moles)
        {
            mole.OnHit.AddListener(StartShake);
        }
    }
    
    private void OnDisable()
    {
        foreach (var mole in moles)
        {
            mole.OnHit.RemoveListener(StartShake);
        }
    }

    private void StartShake(Mole _)
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        yield return new WaitForSeconds(.3f);
        transform.DOShakePosition(duration: .5f);
    }
}
