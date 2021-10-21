using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Laser : MonoBehaviour
{
    
    
    private void Update()
    {
        StartCoroutine(Strecth());
    }

    private IEnumerator Strecth()
    {
        while (Time.deltaTime != 1)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1,1,1 ), Time.deltaTime * 1);
            yield return null;
        }
    }
    
}
