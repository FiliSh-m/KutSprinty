﻿using System;
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
    /// Interaction logic for VstupRadek.xaml
    /// </summary>
    public partial class VstupRadek : UserControl
    {
        public VstupRadek(KutSprinty.IData vstupData, KutSprinty.VstupPrompty vstupPrompty, string jmenoRadku)
        {
            Name = jmenoRadku;           
            InitializeComponent();
            VstupLabel.Content = String.Format(vstupPrompty.PromptZadaniVstupu, vstupData.TypDat);
        }
    }
}
