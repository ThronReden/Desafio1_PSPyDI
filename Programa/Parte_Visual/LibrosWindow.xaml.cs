using System.Windows;
using System.Windows.Controls;

namespace Parte_Visual
{
    public partial class LibrosWindow : Window
    {
        public LibrosWindow()
        {
            InitializeComponent();
            dgDatos.ItemsSource = DatosBiblioteca.Libros;
            cmbAutor.ItemsSource = DatosBiblioteca.Autores;
            cmbGenero.ItemsSource = Enum.GetValues(typeof(Genero));
        }

        private void dgDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgDatos.SelectedItem is Libro l)
            {
                txtTitulo.Text = l.Titulo;
                cmbAutor.SelectedItem = l.Autor;
                txtISBN.Text = l.ISBN;
                cmbGenero.SelectedItem = l.Genero;
                dpFechaPublicacion.SelectedDate = l.FechaPublicacion;
                txtEdicion.Text = l.Edicion?.ToString() ?? "";
                txtEditorial.Text = l.Editorial;
            }
        }

        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            dgDatos.SelectedItem = null;
            LimpiarFormulario();
            txtTitulo.Focus();
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            string titulo = txtTitulo.Text.Trim();
            string isbn = txtISBN.Text.Trim();
            string editorial = txtEditorial.Text.Trim();

            if (titulo.Length == 0 || !(cmbAutor.SelectedItem is Autor autor) ||
                !(cmbGenero.SelectedItem is Genero genero) || !dpFechaPublicacion.SelectedDate.HasValue)
            {
                MessageBox.Show("Título, autor, género y fecha de publicación son obligatorios.",
                                "Datos incompletos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int? edicion = null;
            if (txtEdicion.Text.Trim().Length > 0)
            {
                if (!int.TryParse(txtEdicion.Text.Trim(), out int ed) || ed <= 0)
                {
                    MessageBox.Show("La edición debe ser un número entero mayor que 0.",
                                    "Dato incorrecto", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                edicion = ed;
            }

            var actual = dgDatos.SelectedItem as Libro;

            // El ISBN es único
            if (isbn.Length > 0 && DatosBiblioteca.Libros.Any(l => l != actual && l.ISBN == isbn))
            {
                MessageBox.Show("Ya existe un libro con ese ISBN.", "ISBN repetido",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (actual != null)
            {
                actual.Titulo = titulo;
                actual.Autor = autor;
                actual.AutorId = autor.Id;
                actual.ISBN = isbn.Length == 0 ? null : isbn;
                actual.Genero = genero;
                actual.FechaPublicacion = dpFechaPublicacion.SelectedDate.Value;
                actual.Edicion = edicion;
                actual.Editorial = editorial.Length == 0 ? null : editorial;
                dgDatos.Items.Refresh();
            }
            else
            {
                int nuevoId = DatosBiblioteca.Libros.Count == 0 ? 1 : DatosBiblioteca.Libros.Max(x => x.Id) + 1;
                var nuevo = new Libro
                {
                    Id = nuevoId,
                    Titulo = titulo,
                    Autor = autor,
                    AutorId = autor.Id,
                    ISBN = isbn.Length == 0 ? null : isbn,
                    Genero = genero,
                    FechaPublicacion = dpFechaPublicacion.SelectedDate.Value,
                    Edicion = edicion,
                    Editorial = editorial.Length == 0 ? null : editorial
                };
                DatosBiblioteca.Libros.Add(nuevo);
                dgDatos.Items.Refresh();
                dgDatos.SelectedItem = nuevo;
                dgDatos.ScrollIntoView(nuevo);
            }
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (!(dgDatos.SelectedItem is Libro libro))
            {
                MessageBox.Show("Selecciona un libro de la lista.", "Eliminar",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (DatosBiblioteca.Ejemplares.Any(x => x.LibroId == libro.Id))
            {
                MessageBox.Show("No se puede eliminar un libro que tiene ejemplares registrados.",
                                "Eliminar", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var r = MessageBox.Show($"¿Eliminar el libro \"{libro.Titulo}\"?", "Confirmar",
                                    MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (r != MessageBoxResult.Yes) return;

            DatosBiblioteca.Libros.Remove(libro);
            dgDatos.Items.Refresh();
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtTitulo.Clear();
            cmbAutor.SelectedItem = null;
            txtISBN.Clear();
            cmbGenero.SelectedItem = null;
            dpFechaPublicacion.SelectedDate = null;
            txtEdicion.Clear();
            txtEditorial.Clear();
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
