using System;
using UnityEngine;

public class PlayerInput: MonoBehaviour, IShipInput
{
    
    public float Rotation { get; private set; }
    public float Thrust { get; private set; }
    public Vector3 Route { get; private set; }
    public bool FireWeapon { get; private set; }
    
    public event Action OnFire = delegate {  };
    

    private void Update()
    {
        FireWeapon = Input.GetButtonDown("Fire1");
        
        if (FireWeapon)
        {
            OnFire();
        }
    }

    public void ReadInput()
    {
        Rotation = Input.GetAxis("Horizontal");
        Thrust = Input.GetAxis("Vertical");
        Route = Vector3.forward;
    }

}
