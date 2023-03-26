using Datos;
using Entidades;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Forms
{
    public partial class NTicket : Form
    {
        public NTicket()
        {
            InitializeComponent();
        }
        string tipoOperacion = string.Empty;
        TicketDB usuarioDB = new TicketDB();
        Ticket user = new Ticket();
        private void gradientLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void LimpiarControles()
        {
            txtusu.Clear();
            FechaDateTimePicker.Value = DateTime.Now;
            txtnom.Clear();
            txtid.Clear();
            txtcorre.Clear();
            txtdirec.Clear();
            txttipo.Clear();
            rbxasunto.Clear();
            richTextBoxdescripcion.Clear();


        }
        private void AceptarButton_Click(object sender, EventArgs e)
        {
          
                if (string.IsNullOrEmpty(txtusu.Text))
                {
                    errorProvider1.SetError(txtusu, "Ingrese Usuario");
                    txtusu.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(FechaDateTimePicker.Text))
                {
                    errorProvider1.SetError(FechaDateTimePicker, "Ingrese un nombre");
                    FechaDateTimePicker.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(txtnom.Text))
                {
                    errorProvider1.SetError(txtnom, "Ingrese una contraseña");
                    txtnom.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(txtid.Text))
                {
                    errorProvider1.SetError(txtid, "Seleccione un rol");
                    txtid.Focus();
                    return;
                }
                errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtcorre.Text))
            {
                errorProvider1.SetError(txtcorre, "Seleccione un rol");
                txtcorre.Focus();
                return;
            }
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtdirec.Text))
            {
                errorProvider1.SetError(txtdirec, "Seleccione un rol");
                txtdirec.Focus();
                return;
            }
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txttipo.Text))
            {
                errorProvider1.SetError(txttipo, "Seleccione un rol");
                txttipo.Focus();
                return;
            }
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(rbxasunto.Text))
            {
                errorProvider1.SetError(rbxasunto, "Seleccione un rol");
                rbxasunto.Focus();
                return;
            }
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(richTextBoxdescripcion.Text))
            {
                errorProvider1.SetError(richTextBoxdescripcion, "Seleccione un rol");
                richTextBoxdescripcion.Focus();
                return;
            }
            errorProvider1.Clear();

                user.Id = txtid.Text;
                user.Fecha = FechaDateTimePicker.Value;
                user.Cliente = txtnom.Text;
                user.Usuario = txtusu.Text;
                user.Correo = txtcorre.Text;
                user.TipoSoporte = txttipo.Text;
            user.Asunto = rbxasunto.Text;
            user.Descripcion = richTextBoxdescripcion.Text;


            //Insertar en la base de datos

            bool inserto = usuarioDB.Insertar(user);
                if (inserto)
                {
                    LimpiarControles(); 
                    MessageBox.Show("Registro guardado");
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el registro");
                }
            }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu form1 = new Menu();
            this.Hide();
            form1.Show();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }
    }
    }

