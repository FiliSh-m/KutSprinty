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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string promptVstupText = "Zadejte vstup (_text)";
        string promptVstupInt = "Zadejte vstup (_cislo)";
        string promptVystup;
        string toolTipText = "Pouze malá písmena bez diakritiky";
        string toolTipInt= "Číslice 0-9, rozsah 0-999999";
        public MainWindow()
        {
            InitializeComponent();
            Vstup1Label.Content = promptVstupText;
            Vstup2Label.Content = promptVstupInt;
            Vstup1TextBox.ToolTip = toolTipText;
            Vstup2TextBox.ToolTip = toolTipInt;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Zde bude kód spuštěný po stisknutí tlačítka
        }
    }


}
