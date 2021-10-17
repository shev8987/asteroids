using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ShipWeapon : MonoBehaviour
{
    [SerializeField] 
    private Transform _projectilePrefab;

    [SerializeField] 
    private Transform _firePoint;

    [SerializeField] 
    private float _fireRate = 1f;
    
    private PlayerInput _playerInput;

    private float _nextFire = 0f;
    
        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();

            if (_playerInput != null)
            {
                _playerInput.OnFire += HandleFire;
            }
        }
        
        private void Update()
        {

            if (_playerInput.FireWeapon && Time.time >= _nextFire)
            {
                _nextFire = 1f / _fireRate;
                HandleFire();
            }
        }
        private void HandleFire()
        {
            var bullet = Instantiate(_projectilePrefab);
            bullet.position = _firePoint.position;
        }
        
}
