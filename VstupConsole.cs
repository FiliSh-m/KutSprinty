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
            do
            {
                hlaskaConsole.VypisChybu(hlaska);
            }
            while (_hodnota.ZkusZpracovatVstup(ZiskejVstup(ulozisteDat), out hlaska) != true);

            _hodnota = ulozisteDat;
        }

        public IData Hodnota
        {
            get { return _hodnota; }
        }

        string ZiskejVstup(IData ulozisteDat)
        {
            Console.Write(string.Format(_prompty.PromptZadaniVstupu, ulozisteDat.TypDat));
            return Console.ReadLine();
        }

    }

}
