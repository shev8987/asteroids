using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] 
    private float borderX;

    [SerializeField] 
    private float borderZ;

    /// <summary>
    /// Граница игрового поля по X
    /// </summary>
    public float BorderX => borderX;

    /// <summary>
    /// Граница игрового поля по Z
    /// </summary>
    public float BorderZ => borderZ;
    
    /// <summary>
    /// Событие обновления очков
    /// </summary>
    public event EventHandler<int> EUpdateScore;
    
    /// <summary>
    /// Событие конца игры
    /// </summary>
    public event EventHandler EGameOver;
    
    private int _score;
    
    public static GameManager Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    public virtual void OnEUpdateScore(int e)
    {
        _score += e;
        EUpdateScore?.Invoke(this, _score);
    }

    public virtual void OnEGameOver()
    {
        EGameOver?.Invoke(this, EventArgs.Empty);
    }
}
