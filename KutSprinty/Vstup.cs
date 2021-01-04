namespace KutSprinty
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
        }


        public IData Hodnota
        {
            get { return _hodnota; }
        }

        public void ProvedZiskaniDat()
        {
            do { }
            while (_hodnota.ZkusZpracovatVstup(ZiskejVstup(), out hlaska) != true);
        }

        string ZiskejVstup()
        {
            return "123456";
        }

    }

}
