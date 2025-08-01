using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    [SerializeField] private List<Mole> moles;
    [SerializeField] private ComboUI prefab;

    private ComboUI instance;

    private float comboCounter = 0;

    private IEnumerator ResetCounter()
    {
        yield return new WaitForSeconds(1);
        comboCounter = 0;
    }

    private void OnEnable()
    {
        foreach (var mole in moles)
        {
            mole.OnHit.AddListener(CheckCombo);
        }
    }
    
    private void OnDisable()
    {
        foreach (var mole in moles)
        {
            mole.OnHit.RemoveListener(CheckCombo);
        }
    }

    private void CheckCombo(Mole mole)
    {
        StopAllCoroutines();
        StartCoroutine(ResetCounter());
        comboCounter++;
        if (comboCounter >= 2)
        {
            SpawnText(mole);
        }
    }

    private void SpawnText(Mole mole)
    {
        
        instance = Instantiate(prefab);
        instance.transform.position = mole.transform.position + Vector3.up * 15;
        switch (comboCounter)
        {
            case 2:
                instance.SetText("Combo!");
                break;
            case 3:
                instance.SetText("Awesome!");
                break;
            case 4:
                instance.SetText("Maniac!");
                break;
            case 5:
                instance.SetText("Legendary!");
                break;
            case 6:
                instance.SetText("Godlike!");
                break;
            case 7:
                instance.SetText("Insane!");
                break;
            default:
                instance.SetText("Brutal!");
                break;
        }
        Destroy(instance.gameObject, 1f);
    }
}
