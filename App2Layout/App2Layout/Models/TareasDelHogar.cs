using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App2Layout.Models
{
    public class TareasDelHogar
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinalizacion { get; set; }
        public bool EstaTerminada { get; set; }
    }
}
