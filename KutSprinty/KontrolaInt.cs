namespace KutSprinty
{
    /// <summary>
    /// Třída pro kontrolu dat ve formátu int
    /// </summary>
    public class KontrolaInt
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
