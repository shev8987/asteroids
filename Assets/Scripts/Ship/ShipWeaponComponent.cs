using UnityEngine;

namespace Ship
{
    public class ShipWeaponComponent : MonoBehaviour
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
                _playerInput.OnFire += HandleFire;
            }
        }
        
        private void HandleFire()
        {
            if (_playerInput.FireClick && Time.time > _nextFire)
            {
                _nextFire = Time.time + weaponSettings.FireRate;
                _shipWeapon.InitProjectile();
            }
        }
        
    }
}
