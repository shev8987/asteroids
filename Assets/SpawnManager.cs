using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] 
    private Enemy enemyPrefab;

    [SerializeField]
    private int countEnemy = 2;
    
    [SerializeField] 
    private List<Asteroid> asteroidsPrefab;
    
    [SerializeField] 
    private List<Transform> _listSpawnPosition;

    private void Start()
    {
        foreach (var t in asteroidsPrefab)
        {
            var i = Random.Range(0, asteroidsPrefab.Count - 1);
            var randomCount = Random.Range(2, 5);
            Spawn(randomCount, asteroidsPrefab[i].gameObject);
        }
        
        Spawn(2, enemyPrefab.gameObject);
    }

    private Vector3 GenerateSpawnPosition()
    {
        var  point = Random.Range(0, _listSpawnPosition.Count-1);
        
        return _listSpawnPosition[point].position;
    }

    private void Spawn(int count, GameObject prefab)
    {
        for (int i = 0; i < count; i++)
        {
            var point = GenerateSpawnPosition();
            Instantiate(prefab, point, prefab.transform.rotation);
        }
    }
}
