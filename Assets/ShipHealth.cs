using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Enemy") || other.collider.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
            GameManager.Instance.GaveOver();
        }
    }
}
