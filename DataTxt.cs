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

        public DataTxt(KontrolaTxt predanaKontrolaTxt)
        {
            kontrolaTxt = predanaKontrolaTxt;
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
            bool uspech;
            hlaska = null;
            if (PrevodTxt.GetInstance.ZkusPrevod(hodnotaStr, out _hodnota))
            {

                if (ZkusKontrolu()) 
                {                    
                    uspech =  true;
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
                hlaska = "nebylo možné provést převod";;
            }

            return uspech;
        }
    }

}
