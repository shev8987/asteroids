using System;
using Ship;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

/// <summary>
/// Класс управления астероидом
/// </summary>
public class AsteroidInput : MonoBehaviour, IShipInput
{
    /// <summary>
    /// Время смены позиции
    /// </summary>
    [SerializeField] 
    private float changeTime = 5f;

    
    public float Rotation { get; private set; }
    public float Thrust { get; private set; }
    public Vector3 Route { get; private set; }

    /// <summary>
    /// Следуюущая возможность сменить позицию
    /// </summary>
    private float _nextChange = 0f;
    
    private Vector3[] _routes = new Vector3[]
    {
        Vector3.forward, // вперед
        Vector3.forward + Vector3.left, // диагональ вперед и налево
        Vector3.forward + Vector3.right, // диагональ вперед и направо
        Vector3.back + Vector3.left, // диагональ назад и налево
        Vector3.back + Vector3.right, // диагональ назад и направо
        Vector3.back, // назад
        Vector3.left, // влево
        Vector3.right // враво
    };
    
    public void ReadInput()
    {
        Rotation = Random.Range(-1f, 1f);
        Thrust = 1f;
        ChangeRoute();
    }

    /// <summary>
    /// Сменить позицию рандомно
    /// </summary>
    private void ChangeRoute()
    {
        if (!(Time.time > _nextChange)) return;
        
        _nextChange = Time.time + changeTime;
        
        var angle = Random.Range(5, 30);
        var index = Random.Range(0, _routes.Length - 1);
        Route = _routes[index] * Mathf.Sign(angle);
    }
}
