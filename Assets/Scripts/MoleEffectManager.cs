using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleEffectManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem prefabDigOut;
    [SerializeField] private GameObject prefabHammer;
    [SerializeField] private List<Mole> moles;

    private void OnEnable()
    {
        foreach (var mole in moles)
        {
            mole.OnAppear.AddListener(SpawnDirt);
            mole.OnHit.AddListener(SpawnHammer);
        }
    }
    
    private void OnDisable()
    {
        foreach (var mole in moles)
        {
            mole.OnAppear.RemoveListener(SpawnDirt);
            mole.OnHit.RemoveListener(SpawnHammer);
        }
    }

    private void SpawnDirt(Mole mole)
    {
        var instance = Instantiate(prefabDigOut);
        instance.transform.position = mole.transform.position;
        Destroy(instance.gameObject, 2f);
    }

    private void SpawnHammer(Mole mole)
    {
        var instance = Instantiate(prefabHammer);
        instance.transform.position = mole.transform.position + new Vector3(0, 3, 0);
        Destroy(instance.gameObject, 2f);
    }
}