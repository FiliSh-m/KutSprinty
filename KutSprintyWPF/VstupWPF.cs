using System;
using System.Collections.Generic;
using System.Text;
using KutSprinty;

namespace KutSprintyWPF
{
    class VstupWPF : IVstup
    {
        //Vytvoreni tridnich promennych, ktere jsou sdilene mezi metodami
        private IData _hodnota;
        private VstupPrompty _prompty;
        private MainWindow _wpfOkno;

        public IData Hodnota { get; }

        //Event handler pro posilani uz hotovych dat ven
        public event EventHandler<IData> ZiskanyVstup;

        public VstupWPF(IData prichoziData, VstupPrompty prichoziPrompty, MainWindow wpfOkno, string jmenoRadku)
        {
            _hodnota = prichoziData;
            _prompty = prichoziPrompty;
            _wpfOkno = wpfOkno;

            //Vyrobeni radku v okne
            _wpfOkno.VyrobRadek(prichoziData, prichoziPrompty, jmenoRadku);
        }


        /// <summary>
        /// Vezme z radku obsah textboxu a provede s nim vse nezbytne, aby sel ulozit od DataX. Eventy oznami uspesnost a poslou data, nebo chybovou hlasku
        /// </summary>
        public void ProvedZiskaniDat(object sender, VstupRadek vstupRadek)
        {
            string hlaska;
            if (_hodnota.ZkusZpracovatVstup(vstupRadek.VstupTextBox.Text, out hlaska) != true)
            {
                _wpfOkno.VypisChybu(hlaska, vstupRadek);

            }

            else
            {
                ZiskanyVstup.Invoke(this, _hodnota);
            }
            
        }

    }
}
