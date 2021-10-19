using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] 
    private List<GameObject> enemyPrefab;
    
    [SerializeField] 
    private GameObject playerInput;
    
    [SerializeField] 
    private List<Transform> listSpawnPosition;

    public void Launch()
    {
        Instantiate(playerInput);
        InvokeRepeating("Spawn", 1f, 10f);
    }

    public void Spawn()
    {
        foreach (var t in enemyPrefab)
        {
            var i = Random.Range(0, enemyPrefab.Count - 1);
            CreateObject(1, enemyPrefab[i].gameObject);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        var  point = Random.Range(0, listSpawnPosition.Count-1);
        
        return listSpawnPosition[point].position;
    }

    private void CreateObject(int count, GameObject prefab)
    {
        for (int i = 0; i < count; i++)
        {
            var point = GenerateSpawnPosition();
            Instantiate(prefab, point, prefab.transform.rotation);
        }
    }
}
