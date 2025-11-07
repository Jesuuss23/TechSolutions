using TechSolutions.BLL;
using TechSolutions.Entidades;
using System;
using System.Windows.Forms;
namespace TechSolutions.Presentacion
{
    public partial class frmLogin : Form
    {
        private readonly UsuarioBLL _usuarioBLL = new UsuarioBLL();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. Obtener los datos del formulario
            string nombreUsuario = txtUsuario.Text;
            string password = txtPassword.Text;

            try
            {
                // 2. Llamar a la BLL (el "gerente")
                //    No sabemos qué pasa "detrás", solo pedimos el login.
                Usuario usuarioValidado = _usuarioBLL.Login(nombreUsuario, password);

                // 3. Evaluar la respuesta de la BLL
                if (usuarioValidado != null)
                {
                    // ¡ÉXITO!
                    MessageBox.Show(
                        $"¡Bienvenido, {usuarioValidado.NombreUsuario}! (Rol: {usuarioValidado.NombreRol})",
                        "Login Exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Aquí es donde abrirías el formulario principal (Menu)
                    // y cerrarías este formulario de login.
                    // Ejemplo:
                    //   frmMenuPrincipal menu = new frmMenuPrincipal(usuarioValidado);
                    //   menu.Show();
                    //   this.Hide(); 
                }
                else
                {
                    // FRACASO: El login falló (usuario o clave incorrectos)
                    MessageBox.Show(
                        "Usuario o contraseña incorrectos.",
                        "Error de Login",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // ERROR: Ocurrió un error (ej. se cayó la BD)
                MessageBox.Show(
                    "Error al intentar conectar: " + ex.Message,
                    "Error Crítico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
            }
        }

        // (Opcional) Programa el botón Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario de login
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
