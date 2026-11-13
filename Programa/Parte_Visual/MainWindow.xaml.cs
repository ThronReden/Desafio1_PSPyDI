using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Biblioteca_V2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
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

    
