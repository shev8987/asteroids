using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 5f;
    
    private void Update()
    {
        transform.Translate(transform.forward * _speed * Time.deltaTime);
        
        RaycastHit hit;
        var fwd = transform.TransformDirection ( Vector3.forward );
        if (Physics.Raycast(transform.position, fwd, out hit, 2))
        {
            if (hit.distance >= 20)
            {
                Destroy(gameObject);
            }
            
            if (hit.collider.CompareTag("Asteroid") || hit.collider.CompareTag("Enemy"))
            {
                var position = hit.collider.transform.position;
                Destroy(hit.collider.gameObject);
                Destroy(gameObject);
            }
        }

    }
}
