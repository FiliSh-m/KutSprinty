namespace TridyVstupVypocetVystup
{
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

}
