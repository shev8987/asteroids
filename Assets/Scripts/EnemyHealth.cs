using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Bullet") || other.collider.CompareTag("Laser"))
        {
            Destroy(gameObject);
        }
    }
}
