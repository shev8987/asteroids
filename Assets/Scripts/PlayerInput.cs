using System;
using UnityEngine;

/// <summary>
/// Класс обработки ввода игрока
/// </summary>
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

        // todo Ограничение позиции корабля. Можно обойтись и колайдером, но пока сделал так.
        if (transform.position.z >= GameManager.Instance.BorderZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, GameManager.Instance.BorderZ);
        }
        else if (transform.position.z <= - GameManager.Instance.BorderZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -GameManager.Instance.BorderZ);
        }

        if (transform.position.x >= GameManager.Instance.BorderX)
        {
            transform.position = new Vector3(GameManager.Instance.BorderX, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= - GameManager.Instance.BorderX)
        {
            transform.position = new Vector3(-GameManager.Instance.BorderX, transform.position.y, transform.position.z);
        }
        
    }

    public void ReadInput()
    {
        Rotation = Input.GetAxis("Horizontal");
        Thrust =  Input.GetAxis("Vertical") > 0 ? 1 : 0;
        Route = Vector3.forward;
    }
    

}
