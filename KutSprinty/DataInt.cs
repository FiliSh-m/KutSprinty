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

        public DataInt(KontrolaInt predanaKontrolaInt)
        {
            kontrolaInt = predanaKontrolaInt;
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
            bool uspech;
            hlaska = null;
            if (PrevodInt.GetInstance.ZkusPrevod(hodnotaStr, out _hodnota))
            {

                if (ZkusKontrolu())
                {
                    uspech = true;
                }
                else
                {
                    uspech = false;
                    hlaska = "neprošla kontrola";
                }

            }
            else
            {
                uspech = false;
                hlaska = "nebylo možné provést převod"; ;
            }

            return uspech;
        }

    }

}
