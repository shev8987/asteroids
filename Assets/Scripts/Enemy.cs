using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRB;
    
    private GameObject _playerController;

    [SerializeField] 
    private float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.Find("Player");
        enemyRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerController != null)
        {
            var lookDirection = (_playerController.transform.position - transform.position).normalized;
            enemyRB.AddForce( lookDirection* speed);
        }
        else
        {
            enemyRB.velocity = new Vector3(0, 0, 0);
        }

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
