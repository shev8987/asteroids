using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Класс спавна объектов
/// </summary>
public class SpawnManager : MonoBehaviour
{
    /// <summary>
    /// Объект врага
    /// </summary>
    [SerializeField] 
    private List<GameObject> enemyPrefab;
    
    /// <summary>
    /// Объект игрока
    /// </summary>
    [SerializeField] 
    private GameObject playerInput;
    
    /// <summary>
    /// Список позиций спавна
    /// </summary>
    [SerializeField] 
    private List<Transform> listSpawnPosition;

    /// <summary>
    /// Запуск
    /// </summary>
    public void Launch()
    {
        Instantiate(playerInput);
        InvokeRepeating("Spawn", 1f, 10f);
    }

    /// <summary>
    /// Спавн рандомного объекта
    /// </summary>
    public void Spawn()
    {
        foreach (var t in enemyPrefab)
        {
            var i = Random.Range(0, enemyPrefab.Count - 1);
            CreateObject(1, enemyPrefab[i].gameObject);
        }
    }

    /// <summary>
    /// Перезапуск спавна
    /// </summary>
    public void ReSpawn()
    {
        ClearPlane();
        Launch();
    }

    /// <summary>
    /// Очистить поле
    /// </summary>
    public void ClearPlane()
    {
        CancelInvoke("Spawn");
        ObjectPooler.Instance.ReturnAllObjectsToPoll();
    }
    
    
    /// <summary>
    ///  Генерация позиции спавна
    /// </summary>
    /// <returns></returns>
    private Vector3 GenerateSpawnPosition()
    {
        var  point = Random.Range(0, listSpawnPosition.Count-1);
        
        return listSpawnPosition[point].position;
    }

    /// <summary>
    /// Создание объекта
    /// </summary>
    /// <param name="count">Количество копий</param>
    /// <param name="prefab">объект</param>
    private void CreateObject(int count, GameObject prefab)
    {
        for (int i = 0; i < count; i++)
        {
            var point = GenerateSpawnPosition();
            var obj = ObjectPooler.Instance.GetObjectFromPool(prefab.name);
            obj.transform.position = point;
        }
    }
}
