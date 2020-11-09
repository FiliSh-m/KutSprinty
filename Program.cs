using KutSprinty;
using System;
using System.Collections.Generic;

namespace TridyVstupVypocetVystup
{
    class Program
    {
        static void Main(string[] args)
        {
            KriteriaTxt kriteriaTxt = new KriteriaTxt();
            KriteriaInt kriteriaInt = new KriteriaInt();
            DataTxt txtData = new DataTxt(kriteriaTxt.Kriteria);
            DataInt intData = new DataInt(kriteriaInt.Kriteria);
            VstupPrompty vstupPrompty = new VstupPrompty();

            //Ziskavani platnych dat ze vstupu
            VstupConsole mujVstTxt = new VstupConsole(txtData, vstupPrompty);
            VstupConsole mujVstInt = new VstupConsole(intData, vstupPrompty);

            //Dalsi prace s daty
            //string vyslTxt =textData.Hodnota ;
            DataTxt vyslTxt = (DataTxt)mujVstTxt.Hodnota;
            //vyslTxt = (DataTxt)mujVstTxt.Vystup();
            string a = vyslTxt.Hodnota;
            string b = ((DataTxt)mujVstTxt.Hodnota).Hodnota;

            int vyslInt = intData.Hodnota;
            Console.ReadKey();
        }
    }

}
