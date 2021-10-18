using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Vector2 = UnityEngine.Vector2;

public class ShipEngene : MonoBehaviour
{

    [SerializeField] private ShipSettings _shipSettings;
    
    private PlayerInput _playerInput;

    private Rigidbody _rigidbody;

    private IShipInput _shipInput;

    private ShipMotor _shipMotor;
    
    
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody>();
        _shipInput = _shipSettings.UseAI? (IShipInput) new EnemyInput() : new PlayerInput();
        _shipMotor = new ShipMotor(_shipInput, transform, _rigidbody, _shipSettings);
    }

    private void Update()
    {
        _shipInput.ReadInput();
    }

    private void FixedUpdate()
    {
        if (_playerInput != null && _playerInput.Thrust >= 0)
        {
            _shipMotor.Move();
        }
        else
        {
            _shipMotor.Move();
        }
    }
}
