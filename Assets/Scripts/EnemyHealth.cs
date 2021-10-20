using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Fraction _fraction;

    private void Awake()
    {
        _fraction = GetComponent<Fraction>();
    }

    public void Die()
    {
        ObjectPooler.Instance.ReturnToPool(gameObject);
        GameManager.Instance.UpdateToScore(1);
        
        if (_fraction)
        {
            _fraction.SplitOnFraction(transform.position);
        }
    }
}
