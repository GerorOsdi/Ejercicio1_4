using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Ejercicio1_4.Models
{
    public class Photos
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string nombrePhoto { get; set; }
        public string descPhoto { get; set; }
        public Byte[] bytePhoto { get; set; }
    }
}
