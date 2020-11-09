namespace TridyVstupVypocetVystup
{
    /// <summary>
    /// Třída obsahující hlášky, v budoucnu bude využita za pomoci asi eventů, teď jsem je tam zatím dal natvrdo
    /// </summary>
    class HlaskaConsole
    {

        public string VyrobPrompt(string hlaska)
        {
            if (hlaska == null)
            {
                return null;
            }
            
            else
            {
                return string.Format("Nezadali jste platný vstup, {0}", hlaska);
            }

        }
    }

}
