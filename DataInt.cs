namespace TridyVstupVypocetVystup
{
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
                hlaska = "neprošla kontrola";
                return false;
            }
            hlaska = null;
            return true;
        }

    }

}
