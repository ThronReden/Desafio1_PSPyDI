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
    /// Lógica de interacción para EjemplaresWindow.xaml
    /// </summary>
    public partial class EjemplaresWindow : Window
    {
        public EjemplaresWindow()
        {
            
                InitializeComponent();
                dgDatos.ItemsSource = DatosBiblioteca.Ejemplares;
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
