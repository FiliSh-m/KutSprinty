using System;
using System.Collections.Generic;

namespace TridyVstupVypocetVystup
{
    class Program
    {
        static void Main(string[] args)
        {
            double test = 1.0;
            string platneZnaky = "abcdefghijklmnopqrstuvwxyz";
            int[] platnaCisla = new int[] { 0, 999999 };
            DataTxt txtData = new DataTxt(platneZnaky);
            DataInt intData = new DataInt(platnaCisla);

            //Ziskavani platnych dat ze vstupu
            VstupConsole mujVstTxt = new VstupConsole(txtData);
            VstupConsole mujVstInt = new VstupConsole(intData);

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
