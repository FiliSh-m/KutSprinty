using KutSprinty;
using System;

namespace KutSprinty
{
    /// <summary>
    /// Vstup pro konzoli
    /// </summary>
    public class VstupConsole : IVstup
    {
        private  IData _hodnota;
        private string hlaska;
        private HlaskaConsole hlaskaConsole = new HlaskaConsole();
        private readonly VstupPrompty _prompty;
        //public delegate void Oznam(IData data);
        public event EventHandler<IData> ZiskanyVstup;
        public VstupConsole(IData ulozisteDat, VstupPrompty prichoziPrompty)
        {
            _prompty = prichoziPrompty;
            _hodnota = ulozisteDat;           
                       
        }

        public void ProvedZiskaniDat()
        {
            while (_hodnota.ZkusZpracovatVstup(ZiskejVstup(_hodnota), out hlaska) != true)
            {
                hlaskaConsole.VypisChybu(hlaska);
            }

            ZiskanyVstup.Invoke(this, _hodnota);

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
