using System.Windows;
using InventarioApp.Services;

namespace InventarioApp.Views
{
    public partial class VerificacionWindow : Window
    {
        private AuthService _authService;
        private string _email;

        public VerificacionWindow(string email)
        {
            InitializeComponent();
            _authService = new AuthService();
            _email = email;
            CargarMensaje();
        }

        private void CargarMensaje()
        {
            lblMensajeVerificacion.Text = $"Hemos enviado un código de verificación de 6 dígitos a:\n{_email}\n\nPor favor, ingresa el código para completar tu registro.";
        }

        private void btnVerificar_Click(object sender, RoutedEventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();

            if (string.IsNullOrEmpty(codigo))
            {
                MostrarMensaje("Por favor, ingresa el código de verificación.");
                return;
            }

            if (codigo.Length != 6)
            {
                MostrarMensaje("El código debe tener 6 dígitos.");
                return;
            }

            if (_authService.VerificarCodigo(_email, codigo))
            {
                MostrarMensaje("¡Verificación exitosa! Tu cuenta ha sido activada.", false);
                
                // Esperar un momento y luego abrir ventana de login
                System.Threading.Tasks.Task.Delay(2000).ContinueWith(_ => 
                {
                    Dispatcher.Invoke(() =>
                    {
                        var ventanaLogin = new LoginWindow();
                        ventanaLogin.Show();
                        this.Close();
                    });
                });
            }
            else
            {
                MostrarMensaje("Código incorrecto. Por favor, verifica e intenta nuevamente.");
            }
        }

        private void btnReenviar_Click(object sender, RoutedEventArgs e)
        {
            _authService.GenerarCodigoVerificacion(_email);
            MostrarMensaje("Código reenviado. Revisa tu correo electrónico.", false);
        }

        private void MostrarMensaje(string mensaje, bool esError = true)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.Foreground = esError ? System.Windows.Media.Brushes.Red : System.Windows.Media.Brushes.Green;
        }
    }
}
