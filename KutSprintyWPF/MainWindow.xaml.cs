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
        //Event handler na posilani radku se vstupem
        //TODO: posilani celych radku je mozna zbytecne, ale zase je to jednoduche
        public event EventHandler<UIElementCollection> PoslanVstup;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Vypise hlasku na radek, ktere obdrzi
        /// </summary>
        internal void VypisChybu(string hlaska, VstupRadek vstupRadek)
        {
            vstupRadek.ChybaTextBlock.Text = hlaska;
            vstupRadek.ChybaTextBlock.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Vyrobi novy radek a da ho do StackPanelu v MainWindow
        /// </summary>
        /// <param name="jmenoRadku">unikatni jmeno pro identifikaci - asi nepotrebne</param>
        public void VyrobRadek(KutSprinty.IData vstupData, KutSprinty.VstupPrompty vstupPrompty, string jmenoRadku)
        {
            RadkyStackPanel.Children.Add(new VstupRadek(vstupData, vstupPrompty, jmenoRadku));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach(VstupRadek vstupRadek in RadkyStackPanel.Children)
            {
                vstupRadek.ChybaTextBlock.Visibility = Visibility.Collapsed;
            }
            PoslanVstup.Invoke(this, RadkyStackPanel.Children);
        }
    }


}
