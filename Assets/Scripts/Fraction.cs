using UnityEngine;

/// <summary>
/// Класс разделения на фракции
/// </summary>
public class Fraction : MonoBehaviour
{
    [SerializeField]
    private int countFraction;

    [SerializeField]
    private GameObject fract;
    
    /// <summary>
    /// Разделение на фракции
    /// </summary>
    /// <param name="position">Позиция спавна фракций</param>
    public void SplitOnFraction(Vector3 position)
    {
        for (var i = 0; i < countFraction; i++)
        {
           var obj = ObjectPooler.Instance.GetObjectFromPool(fract.name);
           obj.transform.position = position;
        }
    }
}
