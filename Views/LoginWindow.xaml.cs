using System.Windows;
using InventarioApp.Services;

namespace InventarioApp.Views
{
    public partial class LoginWindow : Window
    {
        private AuthService _authService;

        public LoginWindow()
        {
            InitializeComponent();
            _authService = new AuthService();
        }


        private void btnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string contraseña = txtContraseña.Password;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contraseña))
            {
                MostrarMensaje("Por favor, complete todos los campos.");
                return;
            }

            if (!_authService.ValidarEmail(email))
            {
                MostrarMensaje("Por favor, ingrese un correo electrónico válido.");
                return;
            }

            var usuario = _authService.IniciarSesion(email, contraseña);
            if (usuario != null)
            {
                MostrarMensaje("¡Inicio de sesión exitoso!", false);
                
                // Abrir ventana principal
                var ventanaPrincipal = new MainWindow(usuario);
                ventanaPrincipal.Show();
                
                // Cerrar ventana de login
                this.Close();
            }
            else
            {
                MostrarMensaje("Correo o contraseña incorrectos, o cuenta no verificada.");
            }
        }

        private void Registrarse_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var ventanaRegistro = new RegistroWindow();
            ventanaRegistro.Show();
            this.Close();
        }

        private void txtContraseña_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Limpiar mensaje de error cuando el usuario empiece a escribir
            if (lblMensaje.Text != "")
            {
                lblMensaje.Text = "";
            }
        }

        private void MostrarMensaje(string mensaje, bool esError = true)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.Foreground = esError ? System.Windows.Media.Brushes.Red : System.Windows.Media.Brushes.Green;
        }
    }
}

