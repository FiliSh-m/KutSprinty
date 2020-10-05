using System;

namespace TridyVstupVypocetVystup
{
    class Program
    {
        static void Main(string[] args)
        {
            DataInt intData = new DataInt();

            //Ziskavani platnych dat ze cstupu
            Vstup mujVstTxt = new Vstup(new DataTxt());
            Vstup mujVstInt = new Vstup(intData);

            //Dalsi prace s daty
            //string vyslTxt =textData.Hodnota ;
            DataTxt vyslTxt = (DataTxt)mujVstTxt.VratHodnotu();
            //vyslTxt = (DataTxt)mujVstTxt.Vystup();
            string a = vyslTxt.Hodnota;
            string b = ((DataTxt)mujVstTxt.VratHodnotu()).Hodnota;

            int vyslInt = intData.Hodnota;
        }
    }
    /// <summary>
    /// Vstup pro hodnoty. Implementuje rozhraní IVstup a tím se zajistí různé zdroje vstupů
    /// např. default (použito), Console, WPF 
    /// </summary>
    class Vstup : IVstup
    {
        private readonly IData _hodnota;
        public Vstup(IData prichoziHodnota)
        {
            _hodnota = prichoziHodnota;
            do { }
            while (_hodnota.ZkusPrevod(VlastniVstup()) != true || _hodnota.ProvedKontrolu() != true);

            //TODO: Sem patri spusteni kontroly dat
        }
        string VlastniVstup()
        {
            return "123456";
        }
        public IData VratHodnotu()
        {
            return _hodnota;
        }
    }
    /// <summary>
    /// Třída pro zpracování a je nosičem dat typu int
    /// </summary>
    class DataInt : IData
    {
        private int _hodnota;

        public int Hodnota
        {
            get { return _hodnota; }
        }

        public bool ZkusPrevod(string hodnotaStr)
        {
            return PrevodInt.GetInstance.ZkusPrevod(hodnotaStr, out _hodnota);
        }

        public bool ProvedKontrolu()
        {
            if(_hodnota < 999999)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    /// <summary>
    /// Třída pro zpracování a je nosičem dat typu string
    /// </summary>
    class DataTxt : IData
    {
        private string _hodnota;
        private readonly string _abeceda = "abcdefghijklmnopqrstuvwxyz";    //Nejsem si jisty, jestli by abeceda nebo cislice mely byt v teto tride anebo by mely byt predane shora
        private readonly string _cislice = "0123456789";
        public string Hodnota
        {
            get { return _hodnota; }
        }

        public bool ZkusPrevod(string hodnotaStr)
        {
            return PrevodTxt.GetInstance.ZkusPrevod(hodnotaStr, out _hodnota);
        }

        public bool ProvedKontrolu()
        {
            foreach(char pismeno in _hodnota)
            {
                if (!_cislice.Contains(pismeno))
                {
                    return false;
                }                
            }
            return true;
        }
    }
    /// <summary>
    /// Třída pro převod řetězce na řetězec. Nic nepřevádí
    /// </summary>
    class PrevodTxt
    {
        static PrevodTxt implementace = new PrevodTxt();

        public static PrevodTxt GetInstance { get { return implementace; } }

        public bool ZkusPrevod(string prevadenyStr, out string hodnota)
        {
            hodnota = prevadenyStr;
            return true;
        }
    }

    /// <summary>
    /// Singleton - existuje jen jedna instance třídy. Oproti statické třídě, umožňuje dědění
    /// Třída pro převod řetězce na int.
    /// </summary>
    class PrevodInt   //:IPrevod, nelze implementovat Prevod()
    {
        /// <summary>
        /// Zajistí, že třída se implementuje jen jednou
        /// </summary>
        static PrevodInt implementace = new PrevodInt();

        /// <summary>
        /// privátní konstruktor zajišťuje jen instanci třídy jen z "vlastní třídy"
        /// </summary>
        private PrevodInt() { }

        /// <summary>
        /// Umožňuje přístup k implementaci třídy
        /// </summary>
        public static PrevodInt GetInstance { get { return implementace; } }
        public bool ZkusPrevod(string prevadenyStr, out int hodnota)
        {
            return int.TryParse(prevadenyStr, out hodnota);
        }
    }
    interface IVstup
    {
        public IData VratHodnotu();
    }

    interface IData
    {
        public bool ZkusPrevod(string hodnotaStr);
        public bool ProvedKontrolu();
    }

    /// <summary>
    /// Nepoužito
    /// </summary>
    interface IPrevod
    {
        public static PrevodInt GetInstance;
        public bool Prevod(string hodnotaStr);
    }

    /// <summary>
    /// Interface pro kontrolu dat
    /// </summary>
}
