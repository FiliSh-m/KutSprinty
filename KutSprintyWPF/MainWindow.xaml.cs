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

        public EventHandler<UIElementCollection> StisknutoPotvrdit;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StisknutoPotvrdit.Invoke(sender, RadkyStackPanel.Children);
        }
    }


}
