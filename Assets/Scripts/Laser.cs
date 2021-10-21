using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Laser : MonoBehaviour
{
    [SerializeField] 
    private float distance;

    private void Start()
    {
        StartCoroutine(Strecth());
    }

    private IEnumerator Strecth()
    {
        while (Time.deltaTime != 1)
        {
            Mathf.Lerp(transform.localScale.z, distance, Time.deltaTime * 1);
            yield return null;
        }
    }
    
}
