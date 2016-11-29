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
using System.Windows.Shapes;

namespace Pi_
{
    /// <summary>
    /// Logique d'interaction pour Hangar.xaml
    /// </summary>
    public partial class Hangar : Window
    {
        public Hangar()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MV_Add ajout = new MV_Add(boxName.Text, boxCity.Text, boxLength.Text, boxWidth.Text);
            ajout.Add_hangar();
        }
    }
}
