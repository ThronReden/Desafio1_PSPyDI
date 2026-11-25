using System.Windows;
using System.Windows.Controls;

namespace Parte_Visual
{
    public partial class EjemplaresWindow : Window
    {
        public EjemplaresWindow()
        {
            InitializeComponent();
            dgDatos.ItemsSource = DatosBiblioteca.Ejemplares;
            cmbLibro.ItemsSource = DatosBiblioteca.Libros;
        }

        private void dgDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgDatos.SelectedItem is Ejemplar ej)
            {
                cmbLibro.SelectedItem = ej.Libro;
                dpFechaIncorporacion.SelectedDate = ej.FechaIncorporacion;
            }
        }

        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            dgDatos.SelectedItem = null;
            LimpiarFormulario();
            cmbLibro.Focus();
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            if (!(cmbLibro.SelectedItem is Libro libro) || !dpFechaIncorporacion.SelectedDate.HasValue)
            {
                MessageBox.Show("Libro y fecha de incorporación son obligatorios.",
                                "Datos incompletos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (dgDatos.SelectedItem is Ejemplar existente)
            {
                existente.Libro = libro;
                existente.LibroId = libro.Id;
                existente.FechaIncorporacion = dpFechaIncorporacion.SelectedDate.Value;
                dgDatos.Items.Refresh();
            }
            else
            {
                int nuevoId = DatosBiblioteca.Ejemplares.Count == 0 ? 1 : DatosBiblioteca.Ejemplares.Max(x => x.Id) + 1;
                var nuevo = new Ejemplar
                {
                    Id = nuevoId,
                    Libro = libro,
                    LibroId = libro.Id,
                    FechaIncorporacion = dpFechaIncorporacion.SelectedDate.Value
                };
                DatosBiblioteca.Ejemplares.Add(nuevo);
                dgDatos.Items.Refresh();
                dgDatos.SelectedItem = nuevo;
                dgDatos.ScrollIntoView(nuevo);
            }
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (!(dgDatos.SelectedItem is Ejemplar ej))
            {
                MessageBox.Show("Selecciona un ejemplar de la lista.", "Eliminar",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (DatosBiblioteca.Prestamos.Any(p => p.EjemplarId == ej.Id))
            {
                MessageBox.Show("No se puede eliminar un ejemplar que tiene préstamos registrados.",
                                "Eliminar", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var r = MessageBox.Show($"¿Eliminar el ejemplar {ej.Id}?", "Confirmar",
                                    MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (r != MessageBoxResult.Yes) return;

            DatosBiblioteca.Ejemplares.Remove(ej);
            dgDatos.Items.Refresh();
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            cmbLibro.SelectedItem = null;
            dpFechaIncorporacion.SelectedDate = null;
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
