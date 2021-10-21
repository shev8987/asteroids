using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Пулл объектов
/// </summary>
public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance { get; private set; }

    [Serializable]
    public struct ObjectInfo
    {
        /// <summary>
        /// Объект создания
        /// </summary>
        public GameObject Prefab;
        
        /// <summary>
        /// Количество копий
        /// </summary>
        public int Count;
    }

    /// <summary>
    /// Список пулов для создания
    /// </summary>
    [SerializeField]
    private List<ObjectInfo> ObjectInfos;

    /// <summary>
    /// Список созданных пулов
    /// </summary>
    private List<PoolContainer> _poolContainers = new List<PoolContainer>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        InitPool();
    }

    /// <summary>
    /// Метод создания пула объектов
    /// </summary>
    private void InitPool()
    {
        var emptyGO = new GameObject();
        foreach (var info in ObjectInfos)
        {
            // создаем контейенер на основе имени объекта
            var container = Instantiate(emptyGO, transform, false);
            container.name = info.Prefab.name.ToUpper();
            var pool = new PoolContainer(container.transform);

            // создаем объекты и помещаем их в контейнер
            for (int i = 0; i < info.Count; i++)
            {
                var go = InstantiateObject(info, pool.Container);
                pool.Objects.Enqueue(go);
            }
            
            _poolContainers.Add(pool);
        }
        
        Destroy(emptyGO);
    }

    /// <summary>
    /// Создание объекта для пула
    /// </summary>
    /// <param name="prefab">Префаб</param>
    /// <param name="parent">Родительский контейнер</param>
    /// <returns></returns>
    private GameObject InstantiateObject(ObjectInfo info, Transform parent)
    {
        var go = Instantiate(info.Prefab, parent);
        go.SetActive(false);

        return go;
    }

    /// <summary>
    /// Получаем объект из пула
    /// </summary>
    /// <param name="nameObject">Имя объекта</param>
    /// <returns></returns>
    public GameObject GetObjectFromPool(string nameObject)
    {
        // todo переделать на dictionary чтобы так не искать каждый раз
        var pool = _poolContainers.Find(x => x.Container.name == nameObject.ToUpper());
        var info = ObjectInfos.Find(x => x.Prefab.name == nameObject);
        
        var obj = pool.Objects.Count > 0 ? 
            pool.Objects.Dequeue() : 
            InstantiateObject(info, pool.Container);
        
        obj.SetActive(true);

        return obj;
    }

    /// <summary>
    /// Возвращаем объект в пулл
    /// </summary>
    /// <param name="obj"></param>
    public void ReturnToPool(GameObject obj)
    {
        // todo переделать на dictionary чтобы так не искать каждый раз
        var pool = _poolContainers.Find(x => obj.name.ToUpper().Contains(x.Container.name));
        pool.Objects.Enqueue(obj);
        obj.SetActive(false);
    }

    public void ReturnAllObjectsToPoll()
    {
        foreach (var pool in _poolContainers)
        {
            foreach (var obj in pool.Objects.Where(x => x.activeSelf))
            {
                pool.Objects.Enqueue(obj);
                obj.SetActive(false);
            }
        }
    }
}
