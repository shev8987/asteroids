using UnityEngine;

namespace Ship
{
    public interface IShipInput
    {
        /// <summary>
        /// Поворот
        /// </summary>
        float Rotation { get; }
    
        /// <summary>
        /// Движение
        /// </summary>
        float Thrust { get; }
    
        /// <summary>
        /// Направление движения
        /// </summary>
        Vector3 Route { get; }
   
        /// <summary>
        /// Метод чтения клавиш ввода
        /// </summary>
        void ReadInput();
    }
}
