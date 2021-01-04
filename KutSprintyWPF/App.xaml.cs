using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using KutSprinty;

namespace KutSprintyWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private VstupWPF _mujVstTxt;
        private VstupWPF _mujVstInt;
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
            _mujVstTxt = new VstupWPF(txtData, vstupPrompty, wpfOkno, "Radek1");
            _mujVstInt = new VstupWPF(intData, vstupPrompty, wpfOkno, "Radek2");
            
            //Prirazovani event handleru
            _mujVstTxt.ZiskanyVstup += mujVstTxt_ZiskanyVstup;
            _mujVstInt.ZiskanyVstup += mujVstInt_ZiskanyVstup;
            wpfOkno.PoslanVstup += WpfOkno_PoslanVstup;
        }

        /// <summary>
        /// Prevezme collection radku a provede pro kazdy z nich ziskani dat
        /// </summary>
        //TODO: Predelat nejak elegantneji, aby to nebylo zavisle na poradi radku
        private void WpfOkno_PoslanVstup(object sender, System.Windows.Controls.UIElementCollection VstupRadky)
        {
            _mujVstTxt.ProvedZiskaniDat(sender, (VstupRadek)VstupRadky[0]);
            _mujVstInt.ProvedZiskaniDat(sender, (VstupRadek)VstupRadky[1]);
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
