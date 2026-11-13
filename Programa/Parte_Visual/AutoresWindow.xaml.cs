using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Biblioteca_V2
{
    /// <summary>
    /// Lógica de interacción para AutoresWindow.xaml
    /// </summary>
    public partial class AutoresWindow : Window
    {
        public AutoresWindow()
        {
            InitializeComponent();
            dgDatos.ItemsSource = DatosBiblioteca.Autores;
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
