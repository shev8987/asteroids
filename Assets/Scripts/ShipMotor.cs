using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMotor
{
 private IShipInput _shipInput;
 private ShipSettings _shipSettings;
 private Transform _transform;

 public ShipMotor(IShipInput shipInput, Transform transform, ShipSettings shipSettings)
 {
   _shipInput = shipInput;
   _shipSettings = shipSettings;
   _transform = transform;
 }

 public void Move()
 {
     _transform.Translate(_shipInput.Route * _shipInput.Thrust * _shipSettings.MoveSpeed * Time.deltaTime);
     _transform.Rotate(Vector3.up * _shipInput.Rotation * _shipSettings.TurnSpeed * Time.deltaTime);
 }
}
