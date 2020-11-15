namespace TridyVstupVypocetVystup
{
    /// <summary>
    /// Třída pro převod řetězce na řetězec. Nic nepřevádí
    /// </summary>
    class PrevodTxt
    {
        static PrevodTxt implementace = new PrevodTxt();

        public static PrevodTxt GetInstance { get { return implementace; } }

        public bool ZkusPrevod(string prevadenyStr, out string hodnota)
        {
            hodnota = prevadenyStr;
            return true;
        }
    }

}
