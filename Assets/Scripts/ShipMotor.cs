using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMotor
{
 private IShipInput _shipInput;
 private ShipSettings _shipSettings;
 private Transform _transform;
 private Rigidbody _rigidbody;

 public ShipMotor(IShipInput shipInput, Transform transform, Rigidbody rigidbody, ShipSettings shipSettings)
 {
   _shipInput = shipInput;
   _shipSettings = shipSettings;
   _transform = transform;
   _rigidbody = rigidbody;
 }

 public void Move()
 {
     _rigidbody.AddForce(_transform.forward * _shipInput.Thrust * _shipSettings.MoveSpeed * Time.deltaTime, ForceMode.Force);
     _rigidbody.AddTorque(_transform.up * _shipInput.Rotation * _shipSettings.TurnSpeed * Time.deltaTime, ForceMode.Force);
 }
}
