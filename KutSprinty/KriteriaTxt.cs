using System;
using System.Collections.Generic;
using System.Text;

namespace KutSprinty
{
    /// <summary>
    /// Obsahuje kriteria kontroly dat typu integer
    /// </summary
    public class KriteriaTxt : IKriteria
    {
        public string Kriteria
        {
            get
            {
                return "aábcčdďeéěfghiíjklmnňoópqrřsštťuúůvwxyýzžAÁBCČDEĚÉFGHIÍJKLMNŇOÓPQŘSŠTŤUÚŮVWXYÝZŽ";
            }
        }
    }
}
