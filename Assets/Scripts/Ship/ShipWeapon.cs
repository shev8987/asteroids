using UnityEngine;

public class ShipWeapon : MonoBehaviour
{
    [SerializeField] 
    private Transform _projectilePrefab;

    [SerializeField] 
    private Transform _firePoint;

    [SerializeField] 
    private float _fireRate = 1f;
    
    private PlayerInput _playerInput;

    private float nextFire = 0f;
    
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
            if (_playerInput.FireWeapon && Time.time > nextFire)
            {
                nextFire = Time.time + _fireRate;
                HandleFire();
            }
        }
        private void HandleFire()
        {
            var projectile = ObjectPooler.Instance.GetObjectFromPool(_projectilePrefab.name);
            projectile.transform.SetPositionAndRotation(_firePoint.position, _firePoint.rotation);
        }
        
}
