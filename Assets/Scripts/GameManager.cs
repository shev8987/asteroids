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

    public event EventHandler<float> EUpdateTime;
 
    /// <summary>
    /// Событие конца игры
    /// </summary>
    public event EventHandler EGameOver;
    
    private int _scoreTotal;
    
    public static GameManager Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void ResetScore()
    {
        _scoreTotal = 0;
        EUpdateScore?.Invoke(this, _scoreTotal);
    }
    
    public virtual void OnEUpdateScore(int e)
    {
        _scoreTotal += e;
        EUpdateScore?.Invoke(this, _scoreTotal);
    }

    public virtual void OnEGameOver()
    {
        EGameOver?.Invoke(this, EventArgs.Empty);
    }

    public virtual void OnEUpdateTime(float e)
    {
        EUpdateTime?.Invoke(this, e);
    }
}
