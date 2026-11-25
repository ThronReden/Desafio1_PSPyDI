using System.Windows;
using System.Windows.Controls;

namespace Parte_Visual
{
    public partial class PrestamosWindow : Window
    {
        public PrestamosWindow()
        {
            InitializeComponent();
            dgDatos.ItemsSource = DatosBiblioteca.Prestamos;
            cmbEjemplar.ItemsSource = DatosBiblioteca.Ejemplares;
            cmbSocio.ItemsSource = DatosBiblioteca.Socios;
        }

        private void dgDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgDatos.SelectedItem is Prestamo p)
            {
                cmbEjemplar.SelectedItem = p.Ejemplar;
                cmbSocio.SelectedItem = p.Socio;
                dpFechaPrestamo.SelectedDate = p.FechaPrestamo;
                dpFechaEsperada.SelectedDate = p.FechaEsperadaEntrega;
                dpFechaEntrega.SelectedDate = p.FechaEntrega;
            }
        }

        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            dgDatos.SelectedItem = null;
            LimpiarFormulario();
            dpFechaPrestamo.SelectedDate = DateTime.Today;
            dpFechaEsperada.SelectedDate = DateTime.Today.AddDays(15);
            cmbEjemplar.Focus();
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            if (!(cmbEjemplar.SelectedItem is Ejemplar ejemplar) ||
                !(cmbSocio.SelectedItem is Socio socio) ||
                !dpFechaPrestamo.SelectedDate.HasValue ||
                !dpFechaEsperada.SelectedDate.HasValue)
            {
                MessageBox.Show("Ejemplar, socio, fecha de préstamo y fecha esperada de entrega son obligatorios.",
                                "Datos incompletos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DateTime fPrestamo = dpFechaPrestamo.SelectedDate.Value;
            DateTime fEsperada = dpFechaEsperada.SelectedDate.Value;
            DateTime? fEntrega = dpFechaEntrega.SelectedDate;

            if (fEsperada < fPrestamo || (fEntrega.HasValue && fEntrega.Value < fPrestamo))
            {
                MessageBox.Show("Las fechas de entrega no pueden ser anteriores a la fecha del préstamo.",
                                "Fechas incorrectas", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var actual = dgDatos.SelectedItem as Prestamo;

            // Un ejemplar no puede estar prestado dos veces a la vez
            if (!fEntrega.HasValue &&
                DatosBiblioteca.Prestamos.Any(p => p != actual && p.EjemplarId == ejemplar.Id && !p.FechaEntrega.HasValue))
            {
                MessageBox.Show("Ese ejemplar ya está prestado y todavía no se ha devuelto.",
                                "Ejemplar no disponible", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (actual != null)
            {
                actual.Ejemplar = ejemplar;
                actual.EjemplarId = ejemplar.Id;
                actual.Socio = socio;
                actual.SocioId = socio.Id;
                actual.FechaPrestamo = fPrestamo;
                actual.FechaEsperadaEntrega = fEsperada;
                actual.FechaEntrega = fEntrega;
                dgDatos.Items.Refresh();
            }
            else
            {
                int nuevoId = DatosBiblioteca.Prestamos.Count == 0 ? 1 : DatosBiblioteca.Prestamos.Max(x => x.Id) + 1;
                var nuevo = new Prestamo
                {
                    Id = nuevoId,
                    Ejemplar = ejemplar,
                    EjemplarId = ejemplar.Id,
                    Socio = socio,
                    SocioId = socio.Id,
                    FechaPrestamo = fPrestamo,
                    FechaEsperadaEntrega = fEsperada,
                    FechaEntrega = fEntrega
                };
                DatosBiblioteca.Prestamos.Add(nuevo);
                dgDatos.Items.Refresh();
                dgDatos.SelectedItem = nuevo;
                dgDatos.ScrollIntoView(nuevo);
            }
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (!(dgDatos.SelectedItem is Prestamo prestamo))
            {
                MessageBox.Show("Selecciona un préstamo de la lista.", "Eliminar",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var r = MessageBox.Show($"¿Eliminar el préstamo {prestamo.Id}?", "Confirmar",
                                    MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (r != MessageBoxResult.Yes) return;

            DatosBiblioteca.Prestamos.Remove(prestamo);
            dgDatos.Items.Refresh();
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            cmbEjemplar.SelectedItem = null;
            cmbSocio.SelectedItem = null;
            dpFechaPrestamo.SelectedDate = null;
            dpFechaEsperada.SelectedDate = null;
            dpFechaEntrega.SelectedDate = null;
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
