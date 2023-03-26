using Entidades;
using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class Loginf : Form
    {
        public Loginf()
        {
            InitializeComponent();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == string.Empty)
            {
                errorProvider1.SetError(txtUsuario, "Ingrese un usuario");
                return;
            }
            errorProvider1.Clear();
            if (txtcontraseña.Text == "")
            {
                errorProvider1.SetError(txtcontraseña, "Ingrese una contraseña");
                return;
            }
            errorProvider1.Clear();

            //Validar usuario en la base de datos
            Login login = new Login(txtUsuario.Text, txtcontraseña.Text);

            UsuarioDB usuarioDB = new UsuarioDB();
            Usuario usuario = new Usuario();

            usuario = usuarioDB.Autenticar(login);

            if (usuario != null)
            {
                if (usuario.EstaActivo)
                {
                    //Crea la Sesión
                    System.Security.Principal.GenericIdentity identidad = new System.Security.Principal.GenericIdentity(usuario.CodigoUsuario);
                    System.Security.Principal.GenericPrincipal principal = new System.Security.Principal.GenericPrincipal(identidad, new string[] { usuario.Rol });
                    System.Threading.Thread.CurrentPrincipal = principal;

                    //Mandar al menu
                    Menu form1 = new Menu();
                    this.Hide();
                    form1.Show();
                }
                else
                {
                    MessageBox.Show("El usuario esta inactivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Datos de usuario incorrectos");
            }


        }

        private void MostrarButton_Click(object sender, EventArgs e)
        {
            if (txtcontraseña.PasswordChar == '*')
            {
                txtcontraseña.PasswordChar = '\0';
            }
            else
            {
                txtcontraseña.PasswordChar = '*';
            }
        }
    }
}
