using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleManager : MonoBehaviour
{
    [SerializeField] private ScreenShake screenShake;
    [SerializeField] private List<Transform> moleHoles;
    [SerializeField] private Mole molePrefab;

    private void Start()
    {
        throw new NotImplementedException();
    }

    private IEnumerator SpawnMoles()
    {
        while (true)
        {
            
        }
    }
}
