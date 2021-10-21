using System;
using UnityEngine;

/// <summary>
/// Здоровье врага
/// </summary>
public class EnemyHealth : MonoBehaviour
{
    private Fraction _fraction;

    private void Awake()
    {
        _fraction = GetComponent<Fraction>();
    }

    
    /// <summary>
    /// Объект уничтожен
    /// </summary>
    public void Die()
    {
        ObjectPooler.Instance.ReturnToPool(gameObject);
        GameManager.Instance.OnEUpdateScore(1);
        
        // есть ли у врага возможность разделяться на фракции
        if (_fraction)
        {
            _fraction.SplitOnFraction(transform.position);
        }
    }
}
