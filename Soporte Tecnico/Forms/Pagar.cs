using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Datos;

namespace Forms
{
    public partial class Pagar : Form
    {
        public Pagar()
        {
            InitializeComponent();
        }
         TicketDB ticketDB = new TicketDB();
        public Ticket ticket = new Ticket();


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Pagar_Load(object sender, EventArgs e)
        {
            DetalleDataGridView.DataSource = ticketDB.DevolverTickets();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Menu form1 = new Menu();
            this.Hide();
            form1.Show();
        }

        private void DetalleDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          try
            {
                txtusuario.Text = DetalleDataGridView.CurrentRow.Cells[3].Value.ToString();
                txtid.Text = DetalleDataGridView.CurrentRow.Cells[0].Value.ToString();
                txtcliente.Text = DetalleDataGridView.CurrentRow.Cells[2].Value.ToString();
                FechaDateTimePicker.Text = DetalleDataGridView.CurrentRow.Cells[1].Value.ToString();
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             
            double ISV, Des, Total;
            double presio = double.Parse(txtpresio.Text);


            ISV = presio * 0.12;
            Des = presio * 0.05;
            Total = presio - Des + ISV;
  
            imp.Text = ISV.ToString();
            des.Text = Des.ToString();
            tot.Text = Total.ToString();
        }
    }
}
