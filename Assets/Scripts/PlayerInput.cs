using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput: MonoBehaviour
{
    public float HorizontalInput { get; private set; }
    
    public float VerticalInput { get; private set; }
    
    public bool FireWeapon { get; private set; }
    
    public event Action OnFire = delegate {  };
    

    private void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        FireWeapon = Input.GetButtonDown("Fire1");

        if (FireWeapon)
        {
            OnFire();
        }

    }
}
