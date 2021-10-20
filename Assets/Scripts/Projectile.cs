using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Object = System.Object;

public class Projectile : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 5f;
    
    private void Update()
    {
        transform.Translate(transform.forward * _speed * Time.deltaTime);
        
        RaycastHit hit;
        var fwd = transform.TransformDirection ( Vector3.forward );
        if (Physics.Raycast(transform.position, fwd, out hit, 0.1f))
        {
            if (hit.collider.CompareTag("Asteroid") || hit.collider.CompareTag("Enemy"))
            {
                ObjectPooler.Instance.ReturnToPool(gameObject);
                ObjectPooler.Instance.ReturnToPool(hit.collider.gameObject);
                GameManager.Instance.UpdateToScore(1);
            }
        }

        if (transform.position.x > 11 || transform.position.x < -11 || transform.position.z > 7 ||
            transform.position.z < -7)
        {
            ObjectPooler.Instance.ReturnToPool(gameObject);
        }

    }
    
}
