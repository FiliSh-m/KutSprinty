using System;
using System.Collections.Generic;
using System.Text;

namespace TridyVstupVypocetVystup
{
    class VstupWPF : IVstup
    {
        public KutSprintyWPF.MainWindow MainWindow;
        private IData _hodnota;
        public event EventHandler<IData> ZiskanyVstup;

        public IData Hodnota { get; }

        public VstupWPF()
        {
            MainWindow = new KutSprintyWPF.MainWindow();
        }

        public void ProvedZiskaniDat()
        {
            //while (_hodnota.ZkusZpracovatVstup(ZiskejVstup(_hodnota), out hlaska) != true)
            //{
            //    hlaskaConsole.VypisChybu(hlaska);
            //}

            ZiskanyVstup.Invoke(this, _hodnota);
        }

        private string ZiskejVstup(IData hodnota)
        {
            return MainWindow.RadekText1;
        }
    }
}
