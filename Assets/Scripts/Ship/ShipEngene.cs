using System;
using Ship;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Vector2 = UnityEngine.Vector2;

/// <summary>
/// Класс здоровья корабля
/// </summary>
public class ShipEngene : MonoBehaviour
{

    [SerializeField] private ShipSettings _shipSettings;
    
    private PlayerInput _playerInput;

    private IShipInput _shipInput;

    private ShipMotor _shipMotor;
    
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        // если установлен чекбокс AI то объект сам по себе управляется иначе управоляет игрок
        _shipInput = _shipSettings.UseAI? (IShipInput) new AsteroidInput() : new PlayerInput();
        _shipMotor = new ShipMotor(_shipInput, transform, _shipSettings);
    }

    private void Update()
    {
        _shipInput.ReadInput();
        _shipMotor.Move();
    }
}
