using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using KutSprinty;

namespace KutSprintyWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private VstupRadek _mujVstTxt;
        private VstupRadek _mujVstInt;
        private DataTxt _ziskanyTxt;
        private DataInt _ziskanyInt;
        public App()
        {
            MainWindow wpfOkno = VyrobOkno();

            //Vytvoreni trid s kriterii kontroly
            KriteriaTxt kriteriaTxt = new KriteriaTxt();
            KriteriaInt kriteriaInt = new KriteriaInt();

            //Vytvoreni trid pro data a prirazeni trid pro kontrolu a kriteria
            DataTxt txtData = new DataTxt(new KontrolaTxt(kriteriaTxt.Kriteria));
            DataInt intData = new DataInt(new KontrolaInt(kriteriaInt.Kriteria));

            //Vytvoreni tridy obsahujici prompty
            VstupPrompty vstupPrompty = new VstupPrompty();

            //Vytvoreni vstupu pro kazdy radek
            //TODO: Tady by taky bylo potreba to nejak zautomatizovat + zbavit se atributu jmeno u radku?
            _mujVstTxt = new VstupRadek(txtData);
            _mujVstInt = new VstupRadek(intData);

            wpfOkno.RadkyStackPanel.Children.Add(_mujVstTxt);
            wpfOkno.RadkyStackPanel.Children.Add(_mujVstInt);

            //Prirazovani event handleru
            _mujVstTxt.ZiskanyVstup += mujVstTxt_ZiskanyVstup;
            _mujVstInt.ZiskanyVstup += mujVstInt_ZiskanyVstup;

            wpfOkno.StisknutoPotvrdit += wpfOkno_StisknutoPotvrdit;
        }

        private void wpfOkno_StisknutoPotvrdit(object sender, UIElementCollection vstupRadky)
        {
            foreach (VstupRadek vstupRadek in vstupRadky)
            {
                vstupRadek.ProvedZiskaniDat();
            }
        }

        /// <summary>
        /// Vyrobi nove MainWindow a ukaze ho
        /// </summary>
        /// <returns>MainWindow</returns>
        MainWindow VyrobOkno()
        {
            MainWindow window = new MainWindow();
            window.Show();
            return window;
        }

        //Metody pro eventy na ulozeni ziskaneho vstupu
        //TODO: Predelat, abych nemusel delat novou metodu pro kazdy radek
        void mujVstInt_ZiskanyVstup(object sender, IData poslanaData)
        {
            _ziskanyInt = (DataInt)poslanaData;
        }

        void mujVstTxt_ZiskanyVstup(object sender, IData poslanaData)
        {
            _ziskanyTxt = (DataTxt)poslanaData;
        }
    }
}
