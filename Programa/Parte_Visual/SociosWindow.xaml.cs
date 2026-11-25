using System.Windows;
using System.Windows.Controls;

namespace Parte_Visual
{
    public partial class SociosWindow : Window
    {
        public SociosWindow()
        {
            InitializeComponent();
            dgDatos.ItemsSource = DatosBiblioteca.Socios;
        }

        private void dgDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgDatos.SelectedItem is Socio s)
            {
                txtNombre.Text = s.Nombre;
                txtApellidos.Text = s.Apellidos;
                dpFechaNacimiento.SelectedDate = s.FechaNacimiento;
            }
        }

        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            dgDatos.SelectedItem = null;
            LimpiarFormulario();
            txtNombre.Focus();
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();

            if (nombre.Length == 0 || apellidos.Length == 0 || !dpFechaNacimiento.SelectedDate.HasValue)
            {
                MessageBox.Show("Nombre, apellidos y fecha de nacimiento son obligatorios.",
                                "Datos incompletos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (dgDatos.SelectedItem is Socio existente)
            {
                existente.Nombre = nombre;
                existente.Apellidos = apellidos;
                existente.FechaNacimiento = dpFechaNacimiento.SelectedDate.Value;
                dgDatos.Items.Refresh();
            }
            else
            {
                int nuevoId = DatosBiblioteca.Socios.Count == 0 ? 1 : DatosBiblioteca.Socios.Max(x => x.Id) + 1;
                var nuevo = new Socio
                {
                    Id = nuevoId,
                    Nombre = nombre,
                    Apellidos = apellidos,
                    FechaNacimiento = dpFechaNacimiento.SelectedDate.Value
                };
                DatosBiblioteca.Socios.Add(nuevo);
                dgDatos.Items.Refresh();
                dgDatos.SelectedItem = nuevo;
                dgDatos.ScrollIntoView(nuevo);
            }
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (!(dgDatos.SelectedItem is Socio socio))
            {
                MessageBox.Show("Selecciona un socio de la lista.", "Eliminar",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (DatosBiblioteca.Prestamos.Any(p => p.SocioId == socio.Id))
            {
                MessageBox.Show("No se puede eliminar un socio que tiene préstamos registrados.",
                                "Eliminar", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var r = MessageBox.Show($"¿Eliminar a {socio.NombreCompleto}?", "Confirmar",
                                    MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (r != MessageBoxResult.Yes) return;

            DatosBiblioteca.Socios.Remove(socio);
            dgDatos.Items.Refresh();
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellidos.Clear();
            dpFechaNacimiento.SelectedDate = null;
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
