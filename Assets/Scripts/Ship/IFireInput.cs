using System;
using UnityEngine;

namespace Ship
{
    public interface IFireInput
    {
        bool FireClick { get; }
        
        bool FireClickAdditional { get; }
        
        /// <summary>
        /// Метод чтения клавиш ввода
        /// </summary>
        void ReadInputFire();
    }
}
