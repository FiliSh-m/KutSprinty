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
    /// Hlavni cast programu. Vyrobi okno a s radky podle vyzadovanych dat a ceka na jejich uspesne ziskani
    /// </summary>
    public partial class App : Application
    {
        //TODO: Protoze mam jen dva typy DataX, nemuzu zobrazovat konkretni texty pro zadani PSC, Jmena atd... Je potreba nejak chytre vyrobit dalsi typy - dedicnost?
        private DataTxt _ziskanJmeno;
        private DataTxt _ziskanPrijmeni;
        private DataInt _ziskanPSC;
        private DataInt _ziskanTelefon;
        public App()
        {
            List<VstupRadek> vstupRadky;

            //Vytvoreni trid s kriterii kontroly
            KriteriaTxt kriteriaObecnyText = new KriteriaTxt();
            KriteriaInt kriteriaInt = new KriteriaInt(6);
            KriteriaInt kriteriaPSC = new KriteriaInt(5);
            KriteriaInt kriteriaTelefon = new KriteriaInt(9);

            //Vytvoreni trid pro data a prirazeni trid pro kontrolu a kriteria
            DataTxt jmenoData = new DataTxt(new KontrolaTxt(kriteriaObecnyText.Kriteria));
            DataTxt prijmeniData = new DataTxt(new KontrolaTxt(kriteriaObecnyText.Kriteria));
            DataInt pscData = new DataInt(new KontrolaInt(kriteriaPSC.Kriteria));
            DataInt telefonData = new DataInt(new KontrolaInt(kriteriaTelefon.Kriteria));

            //TODO: Tohle cele zavani neefektivitou, musi jit nejak lip tvorit velke mnozstvi radku a chytat z nich eventy
            MainWindow wpfOkno = VyrobOkno(new IData[] { jmenoData, prijmeniData, pscData, telefonData}, out vstupRadky);

            //TODO: Jsou ty radky takhle nahore vubec potreba?
            VstupRadek _mujVstJmeno = vstupRadky.ElementAt(0);
            VstupRadek _mujVstPrijmeni = vstupRadky.ElementAt(1);
            VstupRadek _mujVstPSC = vstupRadky.ElementAt(2);
            VstupRadek _mujVstTelefon = vstupRadky.ElementAt(3);

            //wpfOkno.RadkyStackPanel.Children.Add(_mujVstTxt);
            //wpfOkno.RadkyStackPanel.Children.Add(_mujVstInt);

            //Prirazovani event handleru
            _mujVstJmeno.ZiskanyVstup += mujVstJmeno_ZiskanyVstup;
            _mujVstPrijmeni.ZiskanyVstup += _mujVstPrijmeni_ZiskanyVstup;
            _mujVstPSC.ZiskanyVstup += mujVstPSC_ZiskanyVstup;
            _mujVstTelefon.ZiskanyVstup += _mujVstTelefon_ZiskanyVstup;
        }

        /// <summary>
        /// Vyrobi nove MainWindow a ukaze ho
        /// </summary>
        /// <returns>MainWindow</returns>
        MainWindow VyrobOkno(KutSprinty.IData[] datas, out List<VstupRadek> radkyList)
        {
            MainWindow window = new MainWindow();
            radkyList = window.PridejRadky(datas);
            window.Show();
            return window;
        }

        //Metody pro eventy na ulozeni ziskaneho vstupu
        //TODO: Predelat, abych nemusel delat novou metodu pro kazdy radek
        void mujVstJmeno_ZiskanyVstup(object sender, IData poslanaData)
        {
            _ziskanJmeno = (DataTxt)poslanaData;
        }

        private void _mujVstPrijmeni_ZiskanyVstup(object sender, IData poslanaData)
        {
            _ziskanPrijmeni = (DataTxt)poslanaData;
        }

        void mujVstPSC_ZiskanyVstup(object sender, IData poslanaData)
        {
            _ziskanPSC = (DataInt)poslanaData;
        }

        private void _mujVstTelefon_ZiskanyVstup(object sender, IData poslanaData)
        {
            _ziskanTelefon = (DataInt)poslanaData;
        }
    }
}
