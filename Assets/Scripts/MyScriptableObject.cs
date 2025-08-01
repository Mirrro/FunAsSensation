using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MyScriptableObject : ScriptableObject
{
    public int hitPoints;

    public void GetDamage(int amount)
    {
        hitPoints -= amount;
    }
}
