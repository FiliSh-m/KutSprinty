using System;
using System.Collections.Generic;

namespace TridyVstupVypocetVystup
{
    class Program
    {
        static void Main(string[] args)
        {
            DataInt intData = new DataInt();

            //Ziskavani platnych dat ze vstupu
            VstupConsole mujVstTxt = new VstupConsole(new DataTxt());
            VstupConsole mujVstInt = new VstupConsole(intData);

            mujVstTxt.VratHodnotu().ZkusKontrolu();
            mujVstInt.VratHodnotu().ZkusKontrolu();

            //Dalsi prace s daty
            //string vyslTxt =textData.Hodnota ;
            DataTxt vyslTxt = (DataTxt)mujVstTxt.VratHodnotu();
            //vyslTxt = (DataTxt)mujVstTxt.Vystup();
            string a = vyslTxt.Hodnota;
            string b = ((DataTxt)mujVstTxt.VratHodnotu()).Hodnota;

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
        public Vstup(IData ulozisteDat)
        {
            _hodnota = ulozisteDat;
            do { }
            while (_hodnota.ZkusZpracovatVstup(PodstrcVstup()) != true);

        }
        string PodstrcVstup()
        {
            return "123456";
        }
        public IData VratHodnotu()  //Nešlo by tohle nahradit property?
        {
            return _hodnota;
        }
    }

    /// <summary>
    /// Vstup pro konzoli
    /// </summary>
    class VstupConsole : IVstup
    {
        private readonly IData _hodnota;
        public VstupConsole(IData ulozisteDat) //Nešla by ta část kódy, která je v obou vstupech stejná dát do interface?
        {
            _hodnota = ulozisteDat;

            do
            {
                //Nenapadá mě, jak jinak získávat ty interní hlášky, nez pomocí eventů. Nechávám na příště.
            }
            while (_hodnota.ZkusZpracovatVstup(ZiskejVstup()) != true);


        }
        string ZiskejVstup()
        {
            Console.Write("Zadejte číslo: ");
            return Console.ReadLine();
        }
        public IData VratHodnotu()  //Nešlo by tohle nahradit property?
        {
            return _hodnota;
        }
    }

    /// <summary>
    /// Třída obsahující hlášky, v budoucnu bude využita za pomoci asi eventů, teď jsem je tam zatím dal natvrdo
    /// </summary>
    class ConsoleHlasky
    {
        private readonly Dictionary<string, string> kodHlasky = new Dictionary<string, string>();

        public ConsoleHlasky()
        {
            kodHlasky.Add("nic", "");
            kodHlasky.Add("neplatne znaky", "Nezadali jste vstup pomocí platných znaků.");
        }

        public string VratHlasku(string kod)
        {
            string hlaska;
            kodHlasky.TryGetValue(kod, out hlaska);
            return hlaska;
        }
    }

    /// <summary>
    /// Třída pro zpracování a je nosičem dat typu int
    /// </summary>
    class DataInt : IData
    {
        private int _hodnota;
        private readonly int[] _platnaCisla = new int[] { 0, 999999 };
        KontrolaInt kontrolaInt;

        public DataInt()
        {
            kontrolaInt = new KontrolaInt(_platnaCisla);
        }

        public int Hodnota
        {
            get { return _hodnota; }
        }

        public bool ZkusKontrolu()
        {
            return kontrolaInt.ProvedKontrolu(this);
        }

        public bool ZkusZpracovatVstup(string hodnotaStr)
        {
            return PrevodInt.GetInstance.ZkusPrevod(hodnotaStr, out _hodnota) && ZkusKontrolu();
        }

    }
    /// <summary>
    /// Třída pro zpracování a je nosičem dat typu string
    /// </summary>
    class DataTxt : IData
    {
        private string _hodnota;
        private readonly string _platneZnaky = "0123456789";
        KontrolaTxt kontrolaTxt;

        public DataTxt()
        {
            kontrolaTxt = new KontrolaTxt(_platneZnaky);
        }

        public string Hodnota
        {
            get { return _hodnota; }
        }

        public bool ZkusKontrolu()
        {
            return kontrolaTxt.ProvedKontrolu(this);
        }

        public bool ZkusZpracovatVstup(string hodnotaStr)
        {
            return PrevodTxt.GetInstance.ZkusPrevod(hodnotaStr, out _hodnota) && ZkusKontrolu();
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
        public bool ZkusZpracovatVstup(string hodnotaStr);
        public bool ZkusKontrolu();
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
    class KontrolaTxt //Chtěl jsem použít interface, aby se automaticky zvolil typ kontroly, ale vypada to, ze tohle uz nejde, takze nemelo cenu ho pouzivat
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
