using System.Windows;
using InventarioApp.Services;

namespace InventarioApp.Views
{
    public partial class RegistroWindow : Window
    {
        private AuthService _authService;

        public RegistroWindow()
        {
            InitializeComponent();
            _authService = new AuthService();
        }


        private void btnRegistrarse_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string contraseña = txtContraseña.Password;
            string confirmarContraseña = txtConfirmarContraseña.Password;

            // Validaciones
            if (string.IsNullOrEmpty(email) || 
                string.IsNullOrEmpty(contraseña) || 
                string.IsNullOrEmpty(confirmarContraseña))
            {
                MostrarMensaje("Por favor, complete todos los campos.");
                return;
            }

            if (!_authService.ValidarEmail(email))
            {
                MostrarMensaje("Por favor, ingrese un correo electrónico válido.");
                return;
            }

            if (contraseña != confirmarContraseña)
            {
                MostrarMensaje("Las contraseñas no coinciden.");
                return;
            }

            if (contraseña.Length < 6)
            {
                MostrarMensaje("La contraseña debe tener al menos 6 caracteres.");
                return;
            }

            if (!chkTerminos.IsChecked.HasValue || !chkTerminos.IsChecked.Value)
            {
                MostrarMensaje("Debe aceptar los términos y condiciones.");
                return;
            }

            // Intentar registrar usuario
            if (_authService.RegistrarUsuario(email, contraseña))
            {
                // Generar código de verificación
                _authService.GenerarCodigoVerificacion(email);
                
                // Abrir ventana de verificación
                var ventanaVerificacion = new VerificacionWindow(email);
                ventanaVerificacion.Show();
                this.Close();
            }
            else
            {
                MostrarMensaje("El correo electrónico ya está registrado.");
            }
        }

        private void txtEmail_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            ValidarFormulario();
        }

        private void txtContraseña_PasswordChanged(object sender, RoutedEventArgs e)
        {
            LimpiarMensaje();
            ValidarFormulario();
        }

        private void txtConfirmarContraseña_PasswordChanged(object sender, RoutedEventArgs e)
        {
            LimpiarMensaje();
            ValidarFormulario();
        }

        private void chkTerminos_Checked(object sender, RoutedEventArgs e)
        {
            ValidarFormulario();
        }

        private void chkTerminos_Unchecked(object sender, RoutedEventArgs e)
        {
            ValidarFormulario();
        }

        private void Terminos_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show("Términos y Condiciones:\n\n" +
                          "1. Al registrarte, aceptas nuestros términos de servicio.\n" +
                          "2. Tu información será protegida según nuestra política de privacidad.\n" +
                          "3. Te comprometes a usar la aplicación de manera responsable.\n" +
                          "4. Nos reservamos el derecho de suspender cuentas que violen estos términos.\n\n" +
                          "Para más información, contacta a soporte@inventarios.com", 
                          "Términos y Condiciones", 
                          MessageBoxButton.OK, 
                          MessageBoxImage.Information);
        }

        private void IniciarSesion_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var ventanaLogin = new LoginWindow();
            ventanaLogin.Show();
            this.Close();
        }

        private void ValidarFormulario()
        {
            bool emailValido = !string.IsNullOrEmpty(txtEmail.Text.Trim()) && _authService.ValidarEmail(txtEmail.Text.Trim());
            bool contraseñaValida = !string.IsNullOrEmpty(txtContraseña.Password) && txtContraseña.Password.Length >= 6;
            bool contraseñasCoinciden = txtContraseña.Password == txtConfirmarContraseña.Password;
            bool terminosAceptados = chkTerminos.IsChecked.HasValue && chkTerminos.IsChecked.Value;

            btnRegistrarse.IsEnabled = emailValido && contraseñaValida && contraseñasCoinciden && terminosAceptados;
        }

        private void LimpiarMensaje()
        {
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

