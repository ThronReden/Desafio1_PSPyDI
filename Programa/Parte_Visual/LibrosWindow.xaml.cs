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

namespace Parte_Visual
{
    /// <summary>
    /// Lógica de interacción para LibrosWindow.xaml
    /// </summary>
    public partial class LibrosWindow : Window
    {
        public LibrosWindow()
        {
            InitializeComponent();
            dgLibros.ItemsSource = DatosBiblioteca.Libros;
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
