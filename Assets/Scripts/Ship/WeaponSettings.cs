using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSettings", menuName = "ScriptableObjects/WeaponSettings")]
public class WeaponSettings : ScriptableObject
{
    [SerializeField] 
    private Transform projectilePrefab;
    
    [SerializeField] 
    private float fireRate = 1f;
    
    public Transform ProjectilePrefab => projectilePrefab;
    public float FireRate => fireRate;

}
