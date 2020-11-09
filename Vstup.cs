namespace TridyVstupVypocetVystup
{
    /// <summary>
    /// Původní vstup. Nekomunikuje s uživatelem, podstrkuje string jako vstup.
    /// </summary>
    class Vstup : IVstup
    {
        private readonly IData _hodnota;
        private string hlaska;

        public Vstup(IData ulozisteDat)
        {
            _hodnota = ulozisteDat;
            do { }
            while (_hodnota.ZkusZpracovatVstup(ZiskejVstup(), out hlaska) != true);

        }

        public IData Hodnota
        {
            get { return _hodnota; }
        }

        string ZiskejVstup()
        {
            return "123456";
        }

    }

}
