using System;

namespace TridyVstupVypocetVystup
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTxt textData; //= new DataTxt();
            DataInt intData = new DataInt();

            Vstup mujVstTxt = new Vstup(new DataTxt());
            Vstup mujVstInt = new Vstup(intData);



            //string vyslTxt =textData.Hodnota ;

            DataTxt vyslTxt = (DataTxt)mujVstTxt.Vystup();
            //vyslTxt = (DataTxt)mujVstTxt.Vystup();
            string a = vyslTxt.Hodnota;
            string b = ((DataTxt)mujVstTxt.Vystup()).Hodnota;

            int vyslInt = intData.Hodnota;
        }
    }
    /// <summary>
    /// Vstup pro hodnoty. Implementuje rozhraní IVstup a tím se zajistí různé zdroje vstupů
    /// např. default (použito), Console, WPF 
    /// </summary>
    class Vstup : IVstup
    {
        IData hodnota;
        public Vstup(IData hodnota)
        {
            this.hodnota = hodnota;
            do { }
            while (!this.hodnota.Prevod(VlastniVstup()));
        }
        string VlastniVstup()
        {
            return "123456";
        }
        public IData Vystup()
        {
            return hodnota;
        }
    }
    /// <summary>
    /// Třída pro zpracování a je nosičem dat typu int
    /// </summary>
    class DataInt : IData
    {
        int hodnota;
        public DataInt() { }
        public bool Prevod(string hodnotaStr)
        {
            return PrevodInt.GetInstance.Prevod(hodnotaStr, out hodnota);
        }
        public int Hodnota
        {
            get { return hodnota; }
        }
    }
    /// <summary>
    /// Třída pro zpracování a je nosičem dat typu string
    /// </summary>
    class DataTxt : IData
    {
        string hodnota;
        public DataTxt()
        {
        }
        public bool Prevod(string hodnotaStr)
        {
            return PrevodTxt.GetInstance.Prevod(hodnotaStr, out hodnota);
        }
        public string Hodnota
        {
            get { return hodnota; }
        }
    }
    /// <summary>
    /// Třída pro převod řetězce na řetězec. Nic nepřevádí
    /// </summary>
    class PrevodTxt
    {
        static PrevodTxt implementace = new PrevodTxt();
        private PrevodTxt() { }
        public static PrevodTxt GetInstance { get { return implementace; } }

        public bool Prevod(string hodnotaStr, out string hodnota)
        {
            hodnota = hodnotaStr;
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
        public bool Prevod(string hodnotaStr, out int hodnota)
        {
            return int.TryParse(hodnotaStr, out hodnota);
        }
    }
    interface IVstup
    {
        public IData Vystup();
    }

    interface IData
    {
        public bool Prevod(string hodnotaStr);
    }

    /// <summary>
    /// Nepoužito
    /// </summary>
    interface IPrevod
    {
        public static PrevodInt GetInstance;
        public bool Prevod(string hodnotaStr);
    }
    
    interface IKontrola
    {
        public bool ProvedKontrolu
    }
}
