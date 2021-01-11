namespace KutSprinty
{
    /// <summary>
    /// Třída pro zpracování a je nosičem dat typu string
    /// </summary>
    public class DataTxt : IData
    {
        private string _hodnota;

        public string PromptZadaniVstupu
        {
            get { return "Zadejte vstup (text)"; }
        }

        public string TypDat
        {
            get { return "text"; }
        }

        KontrolaTxt kontrolaTxt;

        /// <param name="predanaKontrolaTxt">
        /// Trida, ve ktere probehne kontrola dat pred ulozenim
        /// </param>
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
