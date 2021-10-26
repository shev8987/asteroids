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

        /// <summary>
        /// Временная переменная возможности стрелять
        /// </summary>
        private bool _IsCanFire;
        
        /// <summary>
        /// Временная переменная количества выстрелов
        /// </summary>
        private int _countShot;
        
        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _shipWeapon = new ShipWeapon(weaponSettings, firePoint);
        }

        private void Start()
        {
            _IsCanFire = true;
            _countShot = countShot;
        }

        private void Update()
        {
            if (_countShot <= 0)
            {
                _IsCanFire = false;
                Debug.Log("Нельзя");
            }
            
            if (_IsCanFire)
            {
                Debug.Log("Можно");
                if (_playerInput.FireClickAdditional && Time.time > _nextFire && _countShot  > 0)
                {
                    _nextFire = Time.time + weaponSettings.FireRate;

                    _countShot --;
                    HandleFireAdditional();
                }
            }
            else
            {
                GameManager.Instance.OnEUpdateTime(reloadingTime);
                StartCoroutine(ReloadCoroutine(reloadingTime));
            }

        }

        /// <summary>
        /// Корутина перезарядки
        /// </summary>
        /// <returns></returns>
        private IEnumerator ReloadCoroutine(float time)
        {
            Debug.Log("перезардка");
            
            while (time > 0)
            {
                time -= Time.deltaTime;
                yield return null;
            }

            if (time <= 0)
            {
                _IsCanFire = true;
                _countShot = countShot;
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
