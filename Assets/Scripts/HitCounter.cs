using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class HitCounter : MonoBehaviour
{
    [SerializeField] private List<Mole> moles;
    [SerializeField] private TMP_Text textfield;
    public UnityEvent Increased;
    private int counter;
    private void OnEnable()
    {
        foreach (var mole in moles)
        {
            mole.OnHit.AddListener(IncreaseCounter);
        }
    }

    private void OnDisable()
    {
        foreach (var mole in moles)
        {
            mole.OnHit.RemoveListener(IncreaseCounter);
        }
    }

    private void Start()
    {
        textfield.text = "Hits: " + counter;
    }

    private void IncreaseCounter(Mole _)
    {
        counter++;
        Increased?.Invoke();
        textfield.text = "Hits: " + counter;
    }
}
