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
    /// Code behind pro MainWindow, po stisknuti tlacitka Potvrdit posle pres event sve radky do App
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public List<VstupRadek> PridejRadky(KutSprinty.IData[] datas)
        {
            var radky = new List<VstupRadek>();
            foreach (KutSprinty.IData data in datas)
            {
                VstupRadek novyRadek = new VstupRadek(data);
                RadkyStackPanel.Children.Add(novyRadek);
                radky.Add(novyRadek);
            }
            return radky;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (VstupRadek vstupRadek in RadkyStackPanel.Children)
            {
                vstupRadek.ProvedZiskaniDat();
            }

        }
    }


}
