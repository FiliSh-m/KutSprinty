namespace KutSprinty
{
    /// <summary>
    /// Třída pro kontrolu dat ve formátu string
    /// </summary>
    public class KontrolaTxt
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
                if (!_platneZnaky.Contains(pismeno.ToString()))
                {
                    return false;
                }
            }
            return true;
        }
    }

}
