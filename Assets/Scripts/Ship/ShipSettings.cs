using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[CreateAssetMenu(fileName = "ShipSettings", menuName = "ScriptableObjects/ShipSettings")]
public class ShipSettings : ScriptableObject
{
    [SerializeField] private float _turnSpeed = 25;
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private bool _useAI = false;

    public float TurnSpeed => _turnSpeed;
    public float MoveSpeed => _moveSpeed;
    public bool UseAI => _useAI;

}
