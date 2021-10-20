using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Fraction : MonoBehaviour
{
    [SerializeField]
    private int countFraction;

    [SerializeField]
    private GameObject fract;
    
    public void SplitOnFraction(Vector3 position)
    {
        for (var i = 0; i < countFraction; i++)
        {
           var obj = ObjectPooler.Instance.GetObjectFromPool(fract.name);
           obj.transform.position = position;
        }
    }
}
