using System.Windows;
using Parte_Visual;

namespace Gestor_Procesos
{
    /// <summary>
    /// Menú principal: abre las pantallas de gestión de la biblioteca.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AbrirAutores_Click(object sender, RoutedEventArgs e)
        {
            new AutoresWindow { Owner = this }.ShowDialog();
        }

        private void AbrirLibros_Click(object sender, RoutedEventArgs e)
        {
            new LibrosWindow { Owner = this }.ShowDialog();
        }

        private void AbrirEjemplares_Click(object sender, RoutedEventArgs e)
        {
            new EjemplaresWindow { Owner = this }.ShowDialog();
        }

        private void AbrirSocios_Click(object sender, RoutedEventArgs e)
        {
            new SociosWindow { Owner = this }.ShowDialog();
        }

        private void AbrirPrestamos_Click(object sender, RoutedEventArgs e)
        {
            new PrestamosWindow { Owner = this }.ShowDialog();
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
