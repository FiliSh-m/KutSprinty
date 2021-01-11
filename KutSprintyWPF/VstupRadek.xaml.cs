using KutSprinty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KutSprintyWPF
{
    /// <summary>
    /// Trida pro zpracovani vstupu z radku ve WPF okne
    /// </summary>
    public partial class VstupRadek : UserControl, KutSprinty.IVstup
    {
        //Vytvoreni tridnich promennych, ktere jsou sdilene mezi metodami
        private IData _hodnota;

        public IData Hodnota { get; }

        //Event handler pro posilani uz hotovych dat ven
        public event EventHandler<IData> ZiskanyVstup;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DataX, kam bude ukladat ziskany vstup"></param>
        public VstupRadek(KutSprinty.IData prichoziData)
        {
            _hodnota = prichoziData;

            InitializeComponent();
            VstupLabel.Content = _hodnota.PromptZadaniVstupu;
        }

        /// <summary>
        /// Vezme z radku obsah textboxu a provede s nim vse nezbytne, aby sel ulozit od DataX. Eventy oznami uspesnost a poslou data, nebo chybovou hlasku
        /// </summary>
        public void ProvedZiskaniDat()
        {
            string hlaska;
            ChybaTextBlock.Visibility = Visibility.Collapsed;
            if (_hodnota.ZkusZpracovatVstup(VstupTextBox.Text, out hlaska) != true)
            {
                ChybaTextBlock.Text = hlaska;
                ChybaTextBlock.Visibility = Visibility.Visible;
            }

            else
            {
                ZiskanyVstup.Invoke(this, _hodnota);
            }
        }
    }
}
