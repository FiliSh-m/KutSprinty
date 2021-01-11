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
        public int[] Kriteria
        {
            get
            {
                return new int[] { 0, 999999 };
            }
        }
    }
}
