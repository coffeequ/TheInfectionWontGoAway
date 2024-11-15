using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epidemiology
{
    /// <summary>
    /// Коллекция состояний клетки.
    /// </summary>
    public enum KletkaState
    {
        Helthy,
        Infected,
        Immune
    }

    /// <summary>
    /// Класс, который содержит свойства: клетки, статус инфекции, статус иммунитета
    ///
    /// </summary>
    public class Kletka
    {
        public KletkaState State { get; set; } // Текущее состояние клетки 

        public int StatusInfection { get; private set; } // Инфекционный статус клетки

        public int StatusImmune { get; private set; } // Иммунный статус клетки

        /// <summary>
        /// Конструктор, который будет устанавливать состояние клетки на здоровую при создании объекта класса
        /// </summary>
        public Kletka()
        {
            State = KletkaState.Helthy;

        }

        /// <summary>
        /// Метод для обновления статуса клетки на инфекционную
        /// </summary>
        public void InfectionUpdate()
        {
            State = KletkaState.Infected;
        }

        /// <summary>
        /// Метод для смены статуса клетки с инфекционной на иммунную
        /// </summary>
        public void SwapStatusInfectionToImmune()
        {
            StatusInfection++;

            if (StatusInfection == 6)
            {
                State = KletkaState.Immune;
            }
        }

        /// <summary>
        /// Метод для смены статуса клетки с иммунной на здоровую
        /// </summary>
        public void SwapStatusImmuneToHealthy()
        {
            StatusImmune++;

            if (StatusImmune == 4)
            {
                State = KletkaState.Helthy;
                StatusInfection = 0;
                StatusImmune = 0;
            }
        }
    }
}
