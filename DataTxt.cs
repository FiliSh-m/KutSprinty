namespace TridyVstupVypocetVystup
{
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

}
