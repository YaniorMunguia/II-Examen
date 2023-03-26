using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ticket
    {
        public string Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public string Correo { get; set; }
        public string Asunto { get; set; }
        public string Descripcion { get; set; }
        public string TipoSoporte { get; set; }
        public string Usuario { get; set; }


        public Ticket()
        {
        }
        public Ticket(string id, DateTime fecha, string cliente, string correo, string asunto, string descripcion, string tipoSoporte, string usuario)
        {
            Id = id;
            Fecha = fecha;
            Cliente = cliente;
            Correo = correo;
            Asunto = asunto;
            Descripcion = descripcion;
            TipoSoporte = tipoSoporte;
            Usuario = usuario;
        }
    }
    }


