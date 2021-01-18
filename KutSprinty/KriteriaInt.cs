using System;
using System.Collections.Generic;
using System.Text;

namespace KutSprinty
{
    /// <summary>
    /// Obsahuje kriteria kontroly dat typu integer
    /// </summary>
    public class KriteriaInt : IKriteria
    {
        private readonly int _maxHodnota;

        public int[] Kriteria
        {
            get
            {
                return new int[] { 0, _maxHodnota };
            }
        }

        public KriteriaInt(int delka)
        {
            _maxHodnota = (int)(Math.Pow(10, delka) - 1);
        }
    }
}
