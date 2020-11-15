namespace TridyVstupVypocetVystup
{
    /// <summary>
    /// Singleton - existuje jen jedna instance třídy. Oproti statické třídě, umožňuje dědění
    /// Třída pro převod řetězce na int.
    /// </summary>
    class PrevodInt   //:IPrevod, nelze implementovat Prevod()
    {
        /// <summary>
        /// Zajistí, že třída se implementuje jen jednou
        /// </summary>
        static PrevodInt implementace = new PrevodInt();

        /// <summary>
        /// privátní konstruktor zajišťuje jen instanci třídy jen z "vlastní třídy"
        /// </summary>
        private PrevodInt() { }

        /// <summary>
        /// Umožňuje přístup k implementaci třídy
        /// </summary>
        public static PrevodInt GetInstance { get { return implementace; } }
        public bool ZkusPrevod(string prevadenyStr, out int hodnota)
        {
            return int.TryParse(prevadenyStr, out hodnota);
        }
    }

}
