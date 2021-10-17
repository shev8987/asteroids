using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 5f;

    private Vector3 lastPosition;


    private void Update()
    {
        transform.Translate(transform.localPosition * _speed * Time.deltaTime);
        
        lastPosition = transform.position;


    }

    /*private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Asteroid") || other.collider.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }*/
}
