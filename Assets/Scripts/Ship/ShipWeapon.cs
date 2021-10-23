using UnityEngine;

public class ShipWeapon
{
    private WeaponSettings _weaponSettings;

    private Transform _firePoint;

    public ShipWeapon(WeaponSettings weaponSettings, Transform firePoint)
    {
        _weaponSettings = weaponSettings;
        _firePoint = firePoint;
    }

    public GameObject InitProjectile()
    {
        var projectile = ObjectPooler.Instance.GetObjectFromPool(_weaponSettings.ProjectilePrefab.name);
        projectile.transform.SetPositionAndRotation(_firePoint.position, _firePoint.rotation);

        return projectile;
    }
}
