using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Класс снаряда
/// </summary>
public class Projectile : MonoBehaviour
{
    [SerializeField] 
    private float speed = 5f;
    
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
        RayCastOnObject();

        // если снаряд вылетает за границы игрового поля. уничтожаем его
        if (transform.position.x > GameManager.Instance.BorderX || transform.position.x < - GameManager.Instance.BorderX || 
            transform.position.z > GameManager.Instance.BorderZ || transform.position.z < - GameManager.Instance.BorderZ)
        {
            ObjectPooler.Instance.ReturnToPool(gameObject);
        }

    }

    private void RayCastOnObject()
    {
        RaycastHit hit;
        var fwd = transform.TransformDirection ( Vector3.forward );
        if (Physics.Raycast(transform.position, fwd, out hit, 0.1f))
        {
            if (hit.collider.CompareTag("Asteroid") || hit.collider.CompareTag("Enemy"))
            {
                ObjectPooler.Instance.ReturnToPool(gameObject);
                hit.collider.GetComponent<EnemyHealth>().Die();
            }
        }
    }
    
}
