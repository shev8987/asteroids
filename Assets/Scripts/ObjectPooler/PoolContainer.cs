using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контейнер пула
/// </summary>
public class PoolContainer : MonoBehaviour
{
    /// <summary>
    /// Родительский контейнер
    /// </summary>
    public Transform Container { get; private set; }

    /// <summary>
    /// Очередь объектов
    /// </summary>
    public Queue<GameObject> Objects { get; set; }

    /// <summary>
    /// Конструктор пула объектов
    /// </summary>
    /// <param name="container">Куда поместить созданные объекты</param>
    public PoolContainer(Transform container)
    {
        Container = container;
        Objects = new Queue<GameObject>();
    }
    
}
