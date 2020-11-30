﻿using KutSprinty;
using System;
using System.Collections.Generic;

namespace TridyVstupVypocetVystup
{
    class Program
    {
        //Testovací text pro Git
        static void Main(string[] args)
        {
            KriteriaTxt kriteriaTxt = new KriteriaTxt();
            KriteriaInt kriteriaInt = new KriteriaInt();
            DataTxt txtData = new DataTxt(new KontrolaTxt(kriteriaTxt.Kriteria));
            DataInt intData = new DataInt(new KontrolaInt(kriteriaInt.Kriteria));
            DataTxt ziskanyTxt;
            DataInt ziskanyInt;
            VstupPrompty vstupPrompty = new VstupPrompty();
            VstupConsole mujVstTxt = new VstupConsole(txtData, vstupPrompty);
            VstupConsole mujVstInt = new VstupConsole(intData, vstupPrompty);
            
            //Prirazovani event handleru
            mujVstTxt.ZiskanyVstup += mujVstTxt_ZiskanyVstup;
            mujVstInt.ZiskanyVstup += mujVstInt_ZiskanyVstup;

            //Ziskani vstupu
            mujVstTxt.ProvedZiskaniDat();
            mujVstInt.ProvedZiskaniDat();

            //Dalsi prace s daty
            ////string vyslTxt =textData.Hodnota ;
            //DataTxt vyslTxt = (DataTxt)mujVstTxt.Hodnota;
            ////vyslTxt = (DataTxt)mujVstTxt.Vystup();
            //string a = vyslTxt.Hodnota;
            //string b = ((DataTxt)mujVstTxt.Hodnota).Hodnota;

            //int vyslInt = intData.Hodnota;
            Console.ReadKey();
            void mujVstInt_ZiskanyVstup(object sender, IData poslanaData)
            {
                ziskanyInt = (DataInt)poslanaData;
            }
            void mujVstTxt_ZiskanyVstup(object sender, IData poslanaData)
            {
                ziskanyTxt = (DataTxt)poslanaData;
            }
        }




    }

}
