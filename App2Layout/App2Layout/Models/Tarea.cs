using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using SQLite;
namespace App2Layout.Models
{
    public class Tarea
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string IdCedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
