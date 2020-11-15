using KutSprinty;
using System;

namespace TridyVstupVypocetVystup
{
    /// <summary>
    /// Vstup pro konzoli
    /// </summary>
    class VstupConsole : IVstup
    {
        private readonly IData _hodnota;
        private string hlaska;
        private HlaskaConsole hlaskaConsole = new HlaskaConsole();
        private readonly VstupPrompty _prompty;

        public VstupConsole(IData ulozisteDat, VstupPrompty prichoziPrompty)
        {
            _prompty = prichoziPrompty;
            _hodnota = ulozisteDat;

            while (_hodnota.ZkusZpracovatVstup(ZiskejVstup(ulozisteDat), out hlaska) != true)
            {
                hlaskaConsole.VypisChybu(hlaska);
            }
                       
        }

        public IData Hodnota
        {
            get { return _hodnota; }
        }

        string ZiskejVstup(IData ulozisteDat)
        {
            Console.Write(string.Format(_prompty.PromptZadaniVstupu, ulozisteDat.TypDat)); //Podle mě tohle má cenu, protože pak můžu mít přizpůsobený ty na základě požadovaného typu dat
            return Console.ReadLine();
        }

    }

}
