using System.Windows;
using System.Windows.Controls;

namespace Parte_Visual
{
    public partial class AutoresWindow : Window
    {
        public AutoresWindow()
        {
            InitializeComponent();
            dgDatos.ItemsSource = DatosBiblioteca.Autores;
        }

        private void dgDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgDatos.SelectedItem is Autor a)
            {
                txtNombre.Text = a.Nombre;
                txtApellidos.Text = a.Apellidos;
                txtNacionalidad.Text = a.Nacionalidad;
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
            string nacionalidad = txtNacionalidad.Text.Trim();

            if (nombre.Length == 0 || apellidos.Length == 0 || nacionalidad.Length == 0)
            {
                MessageBox.Show("Nombre, apellidos y nacionalidad son obligatorios.",
                                "Datos incompletos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (dgDatos.SelectedItem is Autor existente)
            {
                existente.Nombre = nombre;
                existente.Apellidos = apellidos;
                existente.Nacionalidad = nacionalidad;
                dgDatos.Items.Refresh();
            }
            else
            {
                int nuevoId = DatosBiblioteca.Autores.Count == 0 ? 1 : DatosBiblioteca.Autores.Max(x => x.Id) + 1;
                var nuevo = new Autor { Id = nuevoId, Nombre = nombre, Apellidos = apellidos, Nacionalidad = nacionalidad };
                DatosBiblioteca.Autores.Add(nuevo);
                dgDatos.Items.Refresh();
                dgDatos.SelectedItem = nuevo;
                dgDatos.ScrollIntoView(nuevo);
            }
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (!(dgDatos.SelectedItem is Autor autor))
            {
                MessageBox.Show("Selecciona un autor de la lista.", "Eliminar",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (DatosBiblioteca.Libros.Any(l => l.AutorId == autor.Id))
            {
                MessageBox.Show("No se puede eliminar un autor que tiene libros registrados.",
                                "Eliminar", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var r = MessageBox.Show($"¿Eliminar a {autor.NombreCompleto}?", "Confirmar",
                                    MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (r != MessageBoxResult.Yes) return;

            DatosBiblioteca.Autores.Remove(autor);
            dgDatos.Items.Refresh();
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellidos.Clear();
            txtNacionalidad.Clear();
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
