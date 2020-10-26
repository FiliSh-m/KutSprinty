using System;
using System.Collections.Generic;

namespace TridyVstupVypocetVystup
{
    class Program
    {
        static void Main(string[] args)
        {
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
    /// <summary>
    /// Původní vstup. Nekomunikuje s uživatelem, podstrkuje string jako vstup.
    /// </summary>
    class Vstup : IVstup
    {
        private readonly IData _hodnota;
        private string hlaska;

        public IData Hodnota
        {
            get { return _hodnota; }
        }

        public Vstup(IData ulozisteDat)
        {
            _hodnota = ulozisteDat;
            do { }
            while (_hodnota.ZkusZpracovatVstup(PodstrcVstup(), out hlaska) != true);

        }
        string PodstrcVstup()
        {
            return "123456";
        }

    }

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

    /// <summary>
    /// Třída obsahující hlášky, v budoucnu bude využita za pomoci asi eventů, teď jsem je tam zatím dal natvrdo
    /// </summary>
    class HlaskaConsole
    {

        public string VyrobPrompt(string hlaska)
        {
            if (hlaska == null)
            {
                return null;
            }
            
            else
            {
                return string.Format("Nezadali jste platný vstup, {0}", hlaska);
            }

        }
    }

    /// <summary>
    /// Třída pro zpracování a je nosičem dat typu int
    /// </summary>
    class DataInt : IData
    {
        private int _hodnota;

        public string TypDat
        {
            get { return "číslo"; }
        }

        KontrolaInt kontrolaInt;

        public DataInt(int[] platnaCisla)
        {
            kontrolaInt = new KontrolaInt(platnaCisla);
        }

        public int Hodnota
        {
            get { return _hodnota; }
        }

        public bool ZkusKontrolu()
        {
            return kontrolaInt.ProvedKontrolu(this);
        }

        public bool ZkusZpracovatVstup(string hodnotaStr, out string hlaska)
        {
            if (!PrevodInt.GetInstance.ZkusPrevod(hodnotaStr, out _hodnota))
            {
                hlaska = "nebylo možné provést převod";
                return false;
            }
               
            if (!ZkusKontrolu()) 
            {
                hlaska = "neprosla kontrola";
                return false;
            }
            hlaska = null;
            return true;
        }

    }
    /// <summary>
    /// Třída pro zpracování a je nosičem dat typu string
    /// </summary>
    class DataTxt : IData
    {
        private string _hodnota;

        public string TypDat
        {
            get { return "text"; }
        }

        KontrolaTxt kontrolaTxt;

        public DataTxt(string platneZnaky)
        {
            kontrolaTxt = new KontrolaTxt(platneZnaky);
        }

        public string Hodnota
        {
            get { return _hodnota; }
        }

        public bool ZkusKontrolu()
        {
            return kontrolaTxt.ProvedKontrolu(this);
        }

        public bool ZkusZpracovatVstup(string hodnotaStr, out string hlaska)
        {
            if (!PrevodTxt.GetInstance.ZkusPrevod(hodnotaStr, out _hodnota))
            {
                hlaska = "nebylo možné provést převod";
                return false;
            }
               
            if (!ZkusKontrolu()) 
            {
                hlaska = "neprošla kontrola";
                return false;
            }

            hlaska = null;
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

    interface IData
    {
        public string TypDat { get; }
        public bool ZkusZpracovatVstup(string hodnotaStr, out string hlaska);
        public bool ZkusKontrolu();
    }

    interface IVstup
    {
        public IData Hodnota { get; }
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
    /// Třída pro kontrolu dat ve formátu string
    /// </summary>
    class KontrolaTxt
    {
        private readonly string _platneZnaky;

        public KontrolaTxt(string zadanePlatneZnaky)
        {
            _platneZnaky = zadanePlatneZnaky;
        }

        public bool ProvedKontrolu(DataTxt kontrolovanaData)
        {
            foreach (char pismeno in kontrolovanaData.Hodnota)
            {
                if (!_platneZnaky.Contains(pismeno))
                {
                    return false;
                }
            }
            return true;
        }
    }

    /// <summary>
    /// Třída pro kontrolu dat ve formátu int
    /// </summary>
    class KontrolaInt
    {
        private readonly int[] _platnaCisla = new int[2];

        public KontrolaInt(int[] zadanaPlatnaCisla)
        {
            _platnaCisla = zadanaPlatnaCisla;
        }

        public bool ProvedKontrolu(DataInt kontrolovanaData)
        {
            return _platnaCisla[0] <= kontrolovanaData.Hodnota && _platnaCisla[1] >= kontrolovanaData.Hodnota;
        }
    }

}
