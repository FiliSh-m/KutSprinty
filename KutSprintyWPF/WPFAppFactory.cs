using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutSprintyWPF
{
    public class WPFAppFactory
    {
        readonly App wpfApp;
        public App WpfApp { get { return wpfApp; } }
        public WPFAppFactory()
        {
            wpfApp = new App();
        }
        public void VyrobOkno()
        {
            
        }
    }
}
