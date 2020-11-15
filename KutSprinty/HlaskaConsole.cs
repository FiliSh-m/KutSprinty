using System;

namespace TridyVstupVypocetVystup
{
    class HlaskaConsole
    {

        public void VypisChybu(string hlaska)
        {
            if (hlaska != null)
            {
                Console.WriteLine(string.Format("Nezadali jste platný vstup, {0}", hlaska));
            }

        }
    }

}
