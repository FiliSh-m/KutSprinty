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
        private string promptVstupText = "Zadejte vstup (_text)";
        private string promptVstupInt = "Zadejte vstup (_cislo)";
        string promptVystup;
        private string toolTipText = "Pouze malá písmena bez diakritiky";
        private string toolTipInt= "Číslice 0-9, rozsah 0-999999";
        private string radekText1;
        private string radekText2;

        public string RadekText1
        {
            get
            {
                return radekText1;
            }
        }

        public string RadekText2
        {
            get
            {
                return radekText2;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            VstupRadek1.VstupLabel.Content = promptVstupText;
            VstupRadek2.VstupLabel.Content = promptVstupInt;
            VstupRadek1.VstupTextBox.ToolTip = toolTipText;
            VstupRadek2.VstupTextBox.ToolTip = toolTipInt;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            radekText1 = VstupRadek1.VstupTextBox.Text;
            radekText2 = VstupRadek2.VstupTextBox.Text;
        }
    }


}
