namespace TridyVstupVypocetVystup
{
    /// <summary>
    /// Původní vstup. Nekomunikuje s uživatelem, podstrkuje string jako vstup.
    /// </summary>
    class Vstup : IVstup
    {
        private readonly IData _hodnota;
        private string hlaska;

        public IData Hodnota
        {
            get { return _hodnota; }
        }

        public Vstup(IData ulozisteDat)
        {
            _hodnota = ulozisteDat;
            do { }
            while (_hodnota.ZkusZpracovatVstup(PodstrcVstup(), out hlaska) != true);

        }
        string PodstrcVstup()
        {
            return "123456";
        }

    }

}
