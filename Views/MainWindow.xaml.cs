using System.Windows;
using InventarioApp.Models;

namespace InventarioApp.Views
{
    public partial class MainWindow : Window
    {
        private Usuario _usuarioActual;

        public MainWindow(Usuario usuario)
        {
            InitializeComponent();
            _usuarioActual = usuario;
            CargarInformacionUsuario();
        }


        private void CargarInformacionUsuario()
        {
            lblUsuario.Text = $"Usuario: {_usuarioActual.NombreCompleto} ({_usuarioActual.NombreUsuario})";
            lblBienvenida.Text = $"¡Bienvenido, {_usuarioActual.NombreCompleto}!";
        }

        private void btnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            var resultado = MessageBox.Show(
                "¿Está seguro de que desea cerrar sesión?", 
                "Cerrar Sesión", 
                MessageBoxButton.YesNo, 
                MessageBoxImage.Question);

            if (resultado == MessageBoxResult.Yes)
            {
                var ventanaLogin = new LoginWindow();
                ventanaLogin.Show();
                this.Close();
            }
        }
    }
}

