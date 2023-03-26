using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Datos
{
    public class TicketDB
    {
        string cadena = "server=localhost; user=root; database=soporte_tecnico; password=yanior199709;";
        public bool Insertar(Ticket user)
        {
            bool inserto = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO ticket VALUES ");
                sql.Append(" (@Id, @Fecha, @Cliente, @Usuario, @Correo, @TipoSoporte, @Asunto, @Descripcion);");

                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Id", MySqlDbType.VarChar,25).Value = user.Id;
                        comando.Parameters.Add("@Fecha", MySqlDbType.DateTime).Value = DateTime.Now;
                        comando.Parameters.Add("@Cliente", MySqlDbType.VarChar, 25).Value = user.Cliente;
                        comando.Parameters.Add("@Usuario", MySqlDbType.VarChar, 25).Value = user.Usuario;
                        comando.Parameters.Add("@Correo", MySqlDbType.VarChar, 50).Value = user.Correo;
                        comando.Parameters.Add("@TipoSoporte", MySqlDbType.VarChar, 25).Value = user.TipoSoporte;
                        comando.Parameters.Add("@Asunto", MySqlDbType.VarChar, 80).Value = user.Asunto;
                        comando.Parameters.Add("@Descripcion", MySqlDbType.VarChar, 100).Value = user.Descripcion;
                        comando.ExecuteNonQuery();
                        inserto = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return inserto;
        }

        public DataTable DevolverTickets()
        {
            DataTable dataTable = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM ticket ");
                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        MySqlDataReader dr = comando.ExecuteReader();
                        dataTable.Load(dr);
                    }
                }
            }
            catch (Exception)
            {
            }
            return dataTable;
        }
    }
}
