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

        public IData Hodnota
        {
            get { return _hodnota; }
        }

        public VstupConsole(IData ulozisteDat)
        {
            _hodnota = ulozisteDat;

            do
            {
                Console.WriteLine(hlaskaConsole.VyrobPrompt(hlaska));
            }
            while (_hodnota.ZkusZpracovatVstup(ZiskejVstup(ulozisteDat), out hlaska) != true);


        }
        string ZiskejVstup(IData ulozisteDat)
        {
            Console.Write(string.Format("Zadejte vstup ({0}): ", ulozisteDat.TypDat));
            return Console.ReadLine();
        }

    }

}
