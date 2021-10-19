using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 5f;
    
    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        
        RaycastHit hit;
        var fwd = transform.TransformDirection ( Vector3.forward );
        if (Physics.Raycast(transform.position, fwd, out hit, 0.1f))
        {
            if (hit.collider.CompareTag("Asteroid") || hit.collider.CompareTag("Enemy"))
            {
                Destroy(gameObject);
                Destroy(hit.collider.gameObject);
                GameManager.Instance.UpdateToScore(1);
            }
        }

        if (transform.position.x > 11 || transform.position.x < -11 || transform.position.z > 7 ||
            transform.position.z < -7)
        {
            Destroy(gameObject);
        }

    }
    
}
