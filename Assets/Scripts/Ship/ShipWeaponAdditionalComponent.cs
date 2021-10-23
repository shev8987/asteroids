using System;
using System.Collections;
using UnityEngine;

namespace Ship
{
    public class ShipWeaponAdditionalComponent : MonoBehaviour
    {
        [SerializeField] 
        private WeaponSettings weaponSettings;
        
        [SerializeField] 
        private Transform firePoint;

        [SerializeField] 
        private int countShot = 2;

        [SerializeField] 
        private float reloadingTime = 5f;
        
        private PlayerInput _playerInput;
        
        private ShipWeapon _shipWeapon;
        
        private float _nextFire = 0f;

        private bool _IsCanFire;
        
        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _shipWeapon = new ShipWeapon(weaponSettings, firePoint);
            
            if (_playerInput != null)
            {
                _playerInput.OnFireAdditional += HandleFireAdditional;
            }
        }

        private void Start()
        {
            _IsCanFire = true;
        }

        private void Update()
        {
            if (!_IsCanFire) return;
            
            if (_playerInput.FireClickAdditional && Time.time > _nextFire)
            {
                _nextFire = Time.time + weaponSettings.FireRate;
                Fire(countShot);
            }
        }

        private void Fire(float countFire)
        {
            if (countFire > 0)
            {
                countFire--;
                HandleFireAdditional();
            }
            else
            {
                _IsCanFire = false;
                StartCoroutine(CanFireCoroutine());
            }
        }

        private IEnumerator CanFireCoroutine()
        {
            yield return new WaitForSeconds(reloadingTime);
            _IsCanFire = true;
        }

        private IEnumerator TimerCoroutine()
        {
            while (reloadingTime > 0)
            {
                reloadingTime -= Time.deltaTime;
                yield return null;
            }
        }
        
        private void HandleFireAdditional()
        {
           var projectile = _shipWeapon.InitProjectile();
           projectile.transform.SetParent(firePoint);

           if (projectile.GetComponent<Laser>() != null)
           {
               projectile.GetComponent<Laser>().Draw();
           }
           
        }
        
    }
}
