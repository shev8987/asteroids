using System;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _speed;
    
    [SerializeField] private float _turnSpeed;
    
    private Rigidbody _rbRigidbody;

    private CapsuleCollider _boxCollider;

    private bool _isPressedHorizontal;
    private bool _isPressedVertical;

    private PlayerInput _playerInput;
    
    
    private void Awake()
    {
        _rbRigidbody = transform.GetComponent<Rigidbody>();
        _boxCollider = transform.GetComponent<CapsuleCollider>();
        _playerInput = GetComponent<PlayerInput>();
    }

    public void Update()
    {
        _isPressedHorizontal = Input.GetAxis("Horizontal") != 0;

        _isPressedVertical = Input.GetAxis("Vertical") > 0;
    }

    private void FixedUpdate()
    {
        if (_isPressedVertical)
        {
            _rbRigidbody.AddRelativeForce(0,0,_playerInput.VerticalInput * _speed);
        }
        
        if(_isPressedHorizontal)
        {
            _rbRigidbody.AddRelativeTorque(0,_playerInput.HorizontalInput * _turnSpeed,0);
        }
    }
    
}
