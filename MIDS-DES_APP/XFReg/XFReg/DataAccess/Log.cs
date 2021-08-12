using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XFReg.DataAccess
{
    [Table("Log")]
    public class Log
    {
        [PrimaryKey, AutoIncrement]
        public int LogID { get; set; }

        public DateTime Date { get; set; }

        [MaxLength(100)]
        public string Module { get; set; }

        [MaxLength(100)]
        public string Operation { get; set; }

    }
}
