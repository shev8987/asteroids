using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyInput : MonoBehaviour, IShipInput
{
    public float Rotation { get; private set; }
    public float Thrust { get; private set; }
    
    public void ReadInput()
    {
        Rotation = Random.Range(-1f, 1f);
        Thrust = Random.Range(0, 1f);
    }
    
}
