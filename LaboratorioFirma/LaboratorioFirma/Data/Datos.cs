using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LaboratorioFirma.Data
{
    public class Datos
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(250)]
        public String nombre { get; set; }

        [MaxLength(250)]
        public String descripcion { get; set; }

        public byte[] image { get; set; }
    }
}
