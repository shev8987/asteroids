using UnityEngine;

public interface IShipInput
{
    float Rotation { get; }
    
    float Thrust { get; }
    
    Vector3 Route { get; }
    void ReadInput();
}
