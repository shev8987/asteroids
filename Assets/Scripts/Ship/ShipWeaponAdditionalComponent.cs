using UnityEngine;

namespace Ship
{
    public class ShipWeaponAdditionalComponent : MonoBehaviour
    {
        [SerializeField] 
        private WeaponSettings weaponSettings;
        
        [SerializeField] 
        private Transform firePoint;
        
        private PlayerInput _playerInput;
        
        private ShipWeapon _shipWeapon;
        
        private float _nextFire = 0f;
    
        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _shipWeapon = new ShipWeapon(weaponSettings, firePoint);
            
            if (_playerInput != null)
            {
                _playerInput.OnFireAdditional += HandleFireAdditional;
            }
        }
        
        private void Update()
        {
            if (_playerInput.FireClickAdditional && Time.time > _nextFire)
            {
                _nextFire = Time.time + weaponSettings.FireRate;
                HandleFireAdditional();
            }
        }
        private void HandleFireAdditional()
        {
           var projectile = _shipWeapon.InitProjectile();
           projectile.transform.SetParent(firePoint);
        }
        
    }
}
